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
                // إخفاء الأعمدة التقنية
                dgvServices.Columns["ServiceID"].Visible = false;
                dgvServices.Columns["RoomID"].Visible = false;
                dgvServices.Columns["IsActive"].Visible = false;

                // تسمية الأعمدة وتنسيقها
                dgvServices.Columns["ServiceName"].HeaderText = "الخدمة";
                dgvServices.Columns["Price"].HeaderText = "السعر النهائي";

                // العمود الجديد: سعر الموظفة
                dgvServices.Columns["EmployeeBasePrice"].HeaderText = "سعر الموظفة";

                dgvServices.Columns["DurationMinutes"].HeaderText = "المدة (دقائق)";
                dgvServices.Columns["RoomName"].HeaderText = "الغرفة";

                // منع تعديل اسم الغرفة (لأنها Join)
                dgvServices.Columns["RoomName"].ReadOnly = true;

                // تنسيق العملات (رقمين بعد الفاصلة)
                dgvServices.Columns["Price"].DefaultCellStyle.Format = "N2";
                dgvServices.Columns["EmployeeBasePrice"].DefaultCellStyle.Format = "N2";

                // تحسين المظهر
                dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            if (dgvServices.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد الخدمة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var service = dgvServices.CurrentRow.DataBoundItem as Service;

            if (service != null)
            {
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
                        bool isDeactivated = await _serviceRepo.DeleteAsync(service.ServiceID);

                        if (isDeactivated)
                        {
                            await LoadServices();
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
                dgvServices.CurrentCell = dgvServices.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvServices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // إذا كان المستخدم لم يغير القيمة الأصلية، لا داعي للتحقق
            if (!dgvServices.IsCurrentCellDirty) return;

            string columnName = dgvServices.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue.ToString().Trim();

            // التحقق من الأسعار (السعر النهائي وسعر الموظفة)
            if (columnName == "Price" || columnName == "EmployeeBasePrice")
            {
                if (!decimal.TryParse(newValue, out decimal price) || price < 0)
                {
                    MessageBox.Show("يرجى إدخال مبلغ صحيح (0 أو أكثر).", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // هنا يمنع الخروج، لكن فقط إذا حاول إدخال قيمة خاطئة فعلياً
                }
            }
        }

        private async void dgvServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var service = dgvServices.Rows[e.RowIndex].DataBoundItem as Service;

            if (service != null)
            {
                try
                {
                    bool isUpdated = await _serviceRepo.UpdateAsync(service);

                    if (!isUpdated)
                    {
                        MessageBox.Show("فشل تحديث البيانات في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await LoadServices();
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