using beautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;


namespace beautyCenterSystem.data.Repositories
{

    public partial class UC_Services : UserControl
    {

        private readonly ServiceRepository _serviceRepo;


        public UC_Services()
        {
            _serviceRepo = new ServiceRepository(new DbConnectionFactory());
            InitializeComponent();
        }
        private async Task LoadServices()
        {
            var services = await _serviceRepo.GetAllWithRoomNamesAsync();
            dgvServices.DataSource = services.ToList();

        }



        private void FormatGrid()
        {
            if (dgvServices.Columns.Count > 0)
            {
                dgvServices.Columns["ServiceID"].Visible = false;
                dgvServices.Columns["RoomID"].Visible = false; // نخفي الآيدي ونبقي الاسم

                dgvServices.Columns["ServiceName"].HeaderText = "الخدمة";
                dgvServices.Columns["Price"].HeaderText = "السعر";
                dgvServices.Columns["DurationMinutes"].HeaderText = "المدة (دقائق)";
                dgvServices.Columns["RoomName"].HeaderText = "الغرفة";

                // منع تعديل اسم الغرفة من جدول الخدمات مباشرة (لأنها مرتبطة بآيدي)
                dgvServices.Columns["RoomName"].ReadOnly = true;
                dgvServices.Columns["Price"].DefaultCellStyle.Format = "N2";
            }
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddService.FlatStyle = FlatStyle.Flat;
                btnAddService.FlatAppearance.BorderSize = 1;
                btnAddService.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddService.BackColor = Color.White;
            });

            await LoadServices();
            FormatGrid();
        }

        private async void btnDeleteService_Click(object sender, EventArgs e)
        {
            // 1. التأكد من تحديد صف
            if (dgvServices.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد الخدمة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. الحصول على كائن الخدمة
            var service = dgvServices.CurrentRow.DataBoundItem as Service;

            if (service != null)
            {
                // 3. رسالة تأكيد احترافية (توضح أن البيانات القديمة لن تتأثر)
                var confirmResult = MessageBox.Show(
                    $"هل أنت متأكد من إيقاف خدمة ({service.ServiceName})؟\n\n" +
                    "ملاحظة: الخدمة لن تظهر في الحجوزات الجديدة، ولكنها ستبقى في التقارير القديمة.",
                    "تأكيد إيقاف الخدمة",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // 4. استدعاء الريبو (الذي ينفذ UPDATE IsActive = 0)
                        bool isDeactivated = await _serviceRepo.DeleteAsync(service.ServiceID);

                        if (isDeactivated)
                        {
                            // 5. تحديث الجدول فوراً (سيختفي السطر لأن GetAll تجلب IsActive = 1 فقط)
                            await LoadServices();

                            // إشعار نجاح بسيط
                            MessageBox.Show("تم إيقاف الخدمة بنجاح.", "تم الإجراء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("فشل تنفيذ الإجراء، يرجى المحاولة لاحقاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"حدث خطأ أثناء الاتصال بقاعدة البيانات: {ex.Message}", "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvServices_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvServices.ClearSelection();
                dgvServices.Rows[e.RowIndex].Selected = true;
                // جعل الصف الذي ضغطنا عليه هو الـ CurrentRow
                dgvServices.CurrentCell = dgvServices.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvServices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvServices.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue.ToString().Trim();

            // التحقق من اسم الخدمة (لا يجب أن يكون فارغاً)
            if (columnName == "ServiceName")
            {
                if (string.IsNullOrEmpty(newValue))
                {
                    MessageBox.Show("اسم الخدمة لا يمكن أن يكون فارغاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // منع الخروج من الخلية
                }
            }

            // التحقق من السعر (يجب أن يكون رقماً عشرياً أكبر من صفر)
            if (columnName == "Price")
            {
                if (!decimal.TryParse(newValue, out decimal price) || price <= 0)
                {
                    MessageBox.Show("يرجى إدخال سعر صحيح أكبر من الصفر.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }

            // التحقق من المدة (يجب أن تكون رقماً صحيحاً أكبر من صفر)
            if (columnName == "DurationMinutes")
            {
                if (!int.TryParse(newValue, out int duration) || duration <= 0)
                {
                    MessageBox.Show("يرجى إدخال مدة صحيحة بالدقائق.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private async void dgvServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // الحصول على كائن الخدمة من الصف الذي تم تعديله
            var service = dgvServices.Rows[e.RowIndex].DataBoundItem as Service;

            if (service != null)
            {
                try
                {
                    // إرسال التحديث لقاعدة البيانات عبر الريبوستري
                    bool isUpdated = await _serviceRepo.UpdateAsync(service);

                    if (!isUpdated)
                    {
                        MessageBox.Show("فشل تحديث البيانات في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await LoadServices(); // إعادة تحميل البيانات الأصلية في حال الفشل
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadServices();
                }
            }
        }

        private async void btnAddService_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddServiceForm())
            {
                AppTheme.Apply(addForm);

                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadServices();

                }

            }
        }
    }


}
