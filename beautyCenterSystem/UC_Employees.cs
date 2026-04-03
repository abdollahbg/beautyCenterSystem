using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_Employees : UserControl
    {
        private readonly EmployeeRepository _employeeRepo;
        // قائمة نحتفظ بها محلياً لعمليات البحث السريع بدون الرجوع لقاعدة البيانات كل مرة
        private List<EmployeeViewModel> _allEmployees;

        public UC_Employees()
        {
            // 1. تهيئة الريبو أولاً وقبل كل شيء لضمان عدم وجود Null
            _employeeRepo = new EmployeeRepository(new DbConnectionFactory());

            InitializeComponent();

            // 2. ربط الأحداث (Events)
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvEmployees.CellValidating += DgvEmployees_CellValidating;
            this.dgvEmployees.CellEndEdit += DgvEmployees_CellEndEdit;
            this.btnAddEmployee.Click += BtnAddEmployee_Click;
            this.btnDeactivateEmployee.Click += BtnDeactivateEmployee_Click;
            this.btnPayCommission.Click += BtnPayCommission_Click;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                AppTheme.Apply(this); // تطبيق ألوان الثيم

                // التأكد من أن الأعمدة والبيانات يتم تحميلها بالتتابع
                await SetupGridColumns();
                await LoadEmployeesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل واجهة الموظفات: {ex.Message}", "خطأ في التحميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SetupGridColumns()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.Columns.Clear();

            // 1. عمود الآيدي (مخفي)
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmployeeID",
                DataPropertyName = "EmployeeID",
                Visible = false
            });

            // 2. عمود الاسم
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmployeeName",
                HeaderText = "اسم الموظفة",
                DataPropertyName = "EmployeeName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 3. عمود الهاتف
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                HeaderText = "رقم الهاتف",
                DataPropertyName = "Phone",
                Width = 150
            });

            // 4. عمود النسبة
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CommissionRate",
                HeaderText = "النسبة %",
                DataPropertyName = "CommissionRate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                Width = 100
            });

            // 5. عمود الغرفة
            // جلب البيانات من الريبو (الذي تم تهيئته في المشيد)
            var roomsData = await _employeeRepo.GetRoomsForComboAsync();

            var roomColumn = new DataGridViewComboBoxColumn
            {
                Name = "RoomID",
                HeaderText = "الغرفة",
                DataPropertyName = "RoomID",
                DataSource = roomsData?.ToList() ?? new List<Room>(),
                DisplayMember = "RoomName",
                ValueMember = "RoomID",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                Width = 150
            };
            dgvEmployees.Columns.Add(roomColumn);
        }

        private async Task LoadEmployeesData()
        {
            try
            {
                var data = await _employeeRepo.GetAllEmployeesAsync();

                _allEmployees = data.Select(d => new EmployeeViewModel
                {
                    EmployeeID = (int)d.EmployeeID,
                    EmployeeName = d.EmployeeName != null ? d.EmployeeName.ToString() : "",
                    Phone = d.Phone != null ? d.Phone.ToString() : "",
                    CommissionRate = d.CommissionRate != null ? (decimal)d.CommissionRate : 0,
                    RoomID = d.RoomID != null ? (int)d.RoomID : (int?)null
                }).ToList();

                dgvEmployees.DataSource = _allEmployees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات الموظفات: {ex.Message}");
            }
        }

        // --- أحداث الواجهة ---

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                dgvEmployees.DataSource = _allEmployees;
            }
            else
            {
                var filteredData = _allEmployees.Where(emp =>
                    (emp.EmployeeName != null && emp.EmployeeName.ToLower().Contains(query)) ||
                    (emp.Phone != null && emp.Phone.Contains(query))
                ).ToList();

                dgvEmployees.DataSource = filteredData;
            }
        }

        private async void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            using (var frmAdd = new AddEmployeeForm())
            {
                // 2. إظهار الفورم كـ Dialog (نافذة منبثقة تمنع التفاعل مع ما خلفها)
                // وننتظر نتيجة الإغلاق، هل ضغط المستخدم على "حفظ" (OK)؟
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    // 3. إذا كانت النتيجة OK، نقوم بتحديث جدول البيانات فوراً
                    await LoadEmployeesData();

                    // اختيارياً: إظهار رسالة تأكيد بسيطة في شريط الحالة أو MessageBox
                }
            }
        }

        private void BtnPayCommission_Click(object sender, EventArgs e)
        {
            // 1. التأكد من اختيار موظفة من الجدول
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد موظفة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. الحصول على بيانات الموظفة المختارة
            var emp = dgvEmployees.CurrentRow.DataBoundItem as EmployeeViewModel;

            if (emp != null)
            {
               
                var paymentForm = new EmployeePaymentForm(CurrentSession.UserID);

                paymentForm.SelectedEmployeeId = emp.EmployeeID; 

                paymentForm.ShowDialog();

                // 4. بعد إغلاق شاشة الصرف، قد ترغب في تحديث بيانات الجدول الرئيسي
                LoadEmployeesData();
            }
        }

        private async void BtnDeactivateEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد موظفة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var emp = dgvEmployees.CurrentRow.DataBoundItem as EmployeeViewModel;
            if (emp != null)
            {
                var confirmResult = MessageBox.Show($"هل أنت متأكد من إيقاف الموظفة ({emp.EmployeeName})؟", "تأكيد الإيقاف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    bool success = await _employeeRepo.DeleteEmployeeAsync(emp.EmployeeID);
                    if (success)
                    {
                        MessageBox.Show("تم الإيقاف بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadEmployeesData();
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء الإيقاف.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- أحداث التعديل المباشر ---

        private void DgvEmployees_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgvEmployees.IsCurrentCellDirty) return;

            string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue.ToString().Trim();

            if (columnName == "EmployeeName" && string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("اسم الموظفة لا يمكن أن يكون فارغاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }

            if (columnName == "CommissionRate")
            {
                if (!decimal.TryParse(newValue, out decimal rate) || rate < 0 || rate > 100)
                {
                    MessageBox.Show("يرجى إدخال نسبة صحيحة (من 0 إلى 100).", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private async void DgvEmployees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var empVm = dgvEmployees.Rows[e.RowIndex].DataBoundItem as EmployeeViewModel;
            if (empVm != null)
            {
                var employeeToUpdate = new Employee
                {
                    EmployeeID = empVm.EmployeeID,
                    EmployeeName = empVm.EmployeeName,
                    Phone = empVm.Phone,
                    CommissionRate = empVm.CommissionRate,
                    RoomID = empVm.RoomID
                };

                try
                {
                    bool success = await _employeeRepo.UpdateEmployeeAsync(employeeToUpdate);
                    if (!success)
                    {
                        MessageBox.Show("فشل تحديث البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await LoadEmployeesData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadEmployeesData();
                }
            }
        }
    }

    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Phone { get; set; }
        public decimal CommissionRate { get; set; }
        public int? RoomID { get; set; }
    }
}