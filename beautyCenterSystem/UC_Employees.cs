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
        private List<EmployeeViewModel> _allCommissionEmployees = new List<EmployeeViewModel>();
        private List<EmployeeViewModel> _allSalaryEmployees = new List<EmployeeViewModel>();
        private DataGridView dgvSalaryEmployees = new DataGridView();
        private TabControl tcEmployees = new TabControl();
        private TabPage tabCommission = new TabPage("موظفات النسبة");
        private TabPage tabSalary = new TabPage("موظفات الراتب الثابت");

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
            this.btnPaySalary.Click += BtnPaySalary_Click;
            this.btnPaymentHistory.Click += BtnPaymentHistory_Click;
            this.tcEmployees.SelectedIndexChanged += TcEmployees_SelectedIndexChanged;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                AppTheme.Apply(this); // تطبيق ألوان الثيم

                // Setup UI structure
                tcEmployees.Dock = DockStyle.Fill;
                tcEmployees.RightToLeftLayout = true;
                tcEmployees.RightToLeft = RightToLeft.Yes;
                tcEmployees.Font = new Font("Segoe UI", 12F);
                
                dgvEmployees.Dock = DockStyle.Fill;
                tabCommission.Controls.Add(dgvEmployees);

                dgvSalaryEmployees.Dock = DockStyle.Fill;
                dgvSalaryEmployees.BackgroundColor = Color.White;
                dgvSalaryEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSalaryEmployees.AllowUserToAddRows = false;
                dgvSalaryEmployees.RightToLeft = RightToLeft.Yes;
                dgvSalaryEmployees.CellValidating += DgvEmployees_CellValidating;
                dgvSalaryEmployees.CellEndEdit += DgvEmployees_CellEndEdit;
                tabSalary.Controls.Add(dgvSalaryEmployees);

                tcEmployees.TabPages.Add(tabCommission);
                tcEmployees.TabPages.Add(tabSalary);
                
                // Add tab control to pnlMain (will cover existing dgvEmployees location)
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(tcEmployees);

                await SetupGridColumns();
                await LoadEmployeesData();
                TcEmployees_SelectedIndexChanged(null, EventArgs.Empty); // set initial button visibility
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

            // عمود المستحقات الحالية
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentDues",
                HeaderText = "المستحقات الحالية",
                DataPropertyName = "CurrentDues",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                Width = 120,
                ReadOnly = true
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

            // --- Setup dgvSalaryEmployees ---
            dgvSalaryEmployees.AutoGenerateColumns = false;
            dgvSalaryEmployees.Columns.Clear();
            dgvSalaryEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmployeeID", DataPropertyName = "EmployeeID", Visible = false });
            dgvSalaryEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmployeeName", HeaderText = "اسم الموظفة", DataPropertyName = "EmployeeName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvSalaryEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "رقم الهاتف", DataPropertyName = "Phone", Width = 150 });
            dgvSalaryEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "BaseSalary", HeaderText = "الراتب الأساسي", DataPropertyName = "BaseSalary", DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }, Width = 150 });
        }

        private async Task LoadEmployeesData()
        {
            try
            {
                var data = await _employeeRepo.GetAllEmployeesAsync();

                var allViewModels = data.Select(d => new EmployeeViewModel
                {
                    EmployeeID = (int)d.EmployeeID,
                    EmployeeName = d.EmployeeName != null ? d.EmployeeName.ToString() : "",
                    Phone = d.Phone != null ? d.Phone.ToString() : "",
                    CommissionRate = d.CommissionRate,
                    EmployeeType = d.EmployeeType != null ? d.EmployeeType.ToString() : "Commission",
                    BaseSalary = d.BaseSalary,
                    RoomID = d.RoomID,
                    CurrentDues = d.CurrentDues
                }).ToList();

                _allCommissionEmployees = allViewModels.Where(e => e.EmployeeType == "Commission").ToList();
                _allSalaryEmployees = allViewModels.Where(e => e.EmployeeType == "Salary").ToList();

                dgvEmployees.DataSource = _allCommissionEmployees;
                dgvSalaryEmployees.DataSource = _allSalaryEmployees;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات الموظفات: {ex.Message}");
            }
        }

        // --- أحداث الواجهة ---

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                dgvEmployees.DataSource = _allCommissionEmployees;
                dgvSalaryEmployees.DataSource = _allSalaryEmployees;
            }
            else
            {
                var filteredComm = _allCommissionEmployees.Where(emp =>
                    (emp.EmployeeName != null && emp.EmployeeName.ToLower().Contains(query)) ||
                    (emp.Phone != null && emp.Phone.Contains(query))
                ).ToList();

                var filteredSal = _allSalaryEmployees.Where(emp =>
                    (emp.EmployeeName != null && emp.EmployeeName.ToLower().Contains(query)) ||
                    (emp.Phone != null && emp.Phone.Contains(query))
                ).ToList();

                dgvEmployees.DataSource = filteredComm;
                dgvSalaryEmployees.DataSource = filteredSal;
            }
        }

        private async void BtnAddEmployee_Click(object? sender, EventArgs e)
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

        private void BtnPayCommission_Click(object? sender, EventArgs e)
        {
            DataGridView activeGrid = tcEmployees.SelectedIndex == 0 ? dgvEmployees : dgvSalaryEmployees;

            // 1. التأكد من اختيار موظفة من الجدول
            if (activeGrid.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد موظفة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. الحصول على بيانات الموظفة المختارة
            var emp = activeGrid.CurrentRow.DataBoundItem as EmployeeViewModel;

            if (emp != null)
            {
               
                var paymentForm = new EmployeePaymentForm(CurrentSession.UserID);

                paymentForm.SelectedEmployeeId = emp.EmployeeID; 

                paymentForm.ShowDialog();

                // 4. بعد إغلاق شاشة الصرف، قد ترغب في تحديث بيانات الجدول الرئيسي
                _ = LoadEmployeesData();
            }
        }

        private void TcEmployees_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tcEmployees.SelectedTab == tabCommission)
            {
                btnPayCommission.Visible = true;
                btnPaySalary.Visible = false;
            }
            else
            {
                btnPayCommission.Visible = false;
                btnPaySalary.Visible = true;
            }
        }

        private void BtnPaySalary_Click(object? sender, EventArgs e)
        {
            if (dgvSalaryEmployees.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد موظفة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var emp = dgvSalaryEmployees.CurrentRow.DataBoundItem as EmployeeViewModel;
            if (emp != null)
            {
                var paymentForm = new EmployeePaymentForm(CurrentSession.UserID);
                paymentForm.SelectedEmployeeId = emp.EmployeeID;
                paymentForm.ShowDialog();
                _ = LoadEmployeesData();
            }
        }

        private void BtnPaymentHistory_Click(object? sender, EventArgs e)
        {
            var type = tcEmployees.SelectedTab == tabCommission 
                ? PaymentHistoryType.EmployeeCommission 
                : PaymentHistoryType.EmployeeSalary;
            var historyForm = new PaymentHistoryForm(type);
            historyForm.ShowDialog();
        }

        private async void BtnDeactivateEmployee_Click(object? sender, EventArgs e)
        {
            DataGridView activeGrid = tcEmployees.SelectedIndex == 0 ? dgvEmployees : dgvSalaryEmployees;

            if (activeGrid.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد موظفة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var emp = activeGrid.CurrentRow.DataBoundItem as EmployeeViewModel;
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

        private void DgvEmployees_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null || !grid.IsCurrentCellDirty) return;

            string columnName = grid.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue?.ToString()?.Trim() ?? "";

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
            
            if (columnName == "BaseSalary")
            {
                if (!decimal.TryParse(newValue, out decimal salary) || salary < 0)
                {
                    MessageBox.Show("يرجى إدخال راتب صحيح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private async void DgvEmployees_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid == null) return;

            var empVm = grid.Rows[e.RowIndex].DataBoundItem as EmployeeViewModel;
            if (empVm != null)
            {
                var employeeToUpdate = new Employee
                {
                    EmployeeID = empVm.EmployeeID,
                    EmployeeName = empVm.EmployeeName,
                    Phone = empVm.Phone,
                    EmployeeType = empVm.EmployeeType,
                    BaseSalary = empVm.BaseSalary,
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
        public string EmployeeType { get; set; }
        public decimal BaseSalary { get; set; }
        public int? RoomID { get; set; }
        public decimal CurrentDues { get; set; }
    }
}