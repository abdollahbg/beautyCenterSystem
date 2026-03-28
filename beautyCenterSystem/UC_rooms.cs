using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Models; // تم إضافة الموديلات

namespace beautyCenterSystem
{
    public partial class UC_rooms : UserControl
    {
        private readonly RoomRepository _roomRepo;
        public UC_rooms()
        {
            InitializeComponent();
            _roomRepo = new RoomRepository(new DbConnectionFactory());

            // ربط حدث الضغط المزدوج برمجياً لضمان عمله
            this.dgvRooms.CellDoubleClick += dgvRooms_CellDoubleClick;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddRoom.FlatStyle = FlatStyle.Flat;
                btnAddRoom.FlatAppearance.BorderSize = 1;
                btnAddRoom.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddRoom.BackColor = Color.White;
            });
            dgvRooms.ContextMenuStrip = contextMenuStrip1;
            await LoadRooms();
            FormatGrid();
        }

        public async Task LoadRooms()
        {
            var rooms = await _roomRepo.GetAllAsync();
            dgvRooms.DataSource = rooms.ToList();
        }

        private void FormatGrid()
        {
            if (dgvRooms.Columns.Count > 0)
            {
                // إخفاء الأعمدة غير الضرورية
                if (dgvRooms.Columns.Contains("RoomID")) dgvRooms.Columns["RoomID"].Visible = false;
                if (dgvRooms.Columns.Contains("IsActive")) dgvRooms.Columns["IsActive"].Visible = false;

                dgvRooms.Columns["RoomName"].HeaderText = "اسم الغرفة";
                dgvRooms.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // --- التعديل الجديد: إضافة تنسيق عمود الأيقونة ---
                if (dgvRooms.Columns.Contains("IconPath"))
                {
                    dgvRooms.Columns["IconPath"].HeaderText = "مسار الأيقونة (نقر مزدوج للتغيير)";
                    dgvRooms.Columns["IconPath"].Width = 200;
                    dgvRooms.Columns["IconPath"].ReadOnly = true; // للقراءة فقط لإجبار المستخدم على اختيار ملف
                }
            }
        }

        // --- التعديل الجديد: دالة اختيار الأيقونة عند النقر المزدوج ---
        private async void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد من أن النقر تم على صف حقيقي وليس العنوان، وعلى عمود الأيقونة
            if (e.RowIndex >= 0 && dgvRooms.Columns[e.ColumnIndex].Name == "IconPath")
            {
                var room = dgvRooms.Rows[e.RowIndex].DataBoundItem as Room;
                if (room == null) return;

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "اختر أيقونة للغرفة";
                    ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        room.IconPath = ofd.FileName;

                        // تحديث قاعدة البيانات
                        bool success = await _roomRepo.UpdateAsync(room);
                        if (success)
                        {
                            await LoadRooms(); // إعادة تحميل البيانات لتحديث المسار في الجدول
                        }
                    }
                }
            }
        }

        private void dgvRooms_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvRooms.ClearSelection();
                dgvRooms.Rows[e.RowIndex].Selected = true;
            }
        }

        private async void dgvRooms_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var room = dgvRooms.Rows[e.RowIndex].DataBoundItem as Room;
            if (room != null)
            {
                if (string.IsNullOrWhiteSpace(room.RoomName))
                {
                    MessageBox.Show("لا يمكن ترك اسم الغرفة فارغاً");
                    await LoadRooms();
                    return;
                }

                await _roomRepo.UpdateAsync(room);
            }
        }

        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            // 1. التأكد من اختيار غرفة من الجدول
            if (dgvRooms.CurrentRow == null) return;

            var room = dgvRooms.CurrentRow.DataBoundItem as Room;
            if (room == null) return;

            try
            {
                // 2. فحص الأمان: هل توجد خدمات نشطة مرتبطة؟
                bool hasServices = await _roomRepo.HasActiveServicesAsync(room.RoomID);

                if (hasServices)
                {
                    MessageBox.Show(
                        $"لا يمكن إيقاف غرفة ({room.RoomName}) حالياً!\n\n" +
                        "يوجد خدمات نشطة مرتبطة بهذه الغرفة. يرجى حذف تلك الخدمات أو تغيير غرفتها أولاً من قسم الخدمات.",
                        "إجراء غير مسموح",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    return;
                }

                // 3. إذا كانت الغرفة فارغة من الخدمات النشطة، نسأل للتأكيد
                var confirm = MessageBox.Show(
                    $"هل أنت متأكد من إيقاف غرفة ({room.RoomName})؟\n" +
                    "لن تظهر هذه الغرفة عند إضافة خدمات جديدة، ولكن ستبقى مسجلة في التقارير القديمة.",
                    "تأكيد الإيقاف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // تنفيذ الـ Soft Delete (تغيير IsActive إلى 0)
                    bool success = await _roomRepo.DeleteAsync(room.RoomID);

                    if (success)
                    {
                        await LoadRooms(); // تحديث الجدول
                        MessageBox.Show("تم إيقاف الغرفة بنجاح.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        private async void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddRoomForm())
            {
                AppTheme.Apply(addForm);

                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadRooms();
                }
            }
        }
    }
}