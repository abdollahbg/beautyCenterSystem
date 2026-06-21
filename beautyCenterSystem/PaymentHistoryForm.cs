using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data;
using Dapper;

namespace beautyCenterSystem
{
    public enum PaymentHistoryType
    {
        Trainer,
        EmployeeCommission,
        EmployeeSalary
    }

    public partial class PaymentHistoryForm : Form
    {
        private readonly PaymentHistoryType _historyType;
        private readonly DbConnectionFactory _dbFactory;

        public PaymentHistoryForm(PaymentHistoryType historyType)
        {
            InitializeComponent();
            _historyType = historyType;
            _dbFactory = new DbConnectionFactory();

            this.Load += PaymentHistoryForm_Load;
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            cmbEntities.SelectedIndexChanged += CmbEntities_SelectedIndexChanged;
        }

        private async void PaymentHistoryForm_Load(object? sender, EventArgs e)
        {
            AppTheme.Apply(this);
            SetTitle();
            await LoadEntitiesAsync();
            await LoadHistoryAsync(null);
        }

        private void SetTitle()
        {
            switch (_historyType)
            {
                case PaymentHistoryType.Trainer:
                    lblTitle.Text = "سجل صرف مستحقات المدربات";
                    lblFilter.Text = "اسم المدربة";
                    break;
                case PaymentHistoryType.EmployeeCommission:
                    lblTitle.Text = "سجل صرف عمولات الموظفات";
                    lblFilter.Text = "اسم الموظفة";
                    break;
                case PaymentHistoryType.EmployeeSalary:
                    lblTitle.Text = "سجل صرف رواتب الموظفات";
                    lblFilter.Text = "اسم الموظفة";
                    break;
            }
        }

        private async Task LoadEntitiesAsync()
        {
            try
            {
                using var db = _dbFactory.CreateConnection();
                if (_historyType == PaymentHistoryType.Trainer)
                {
                    var trainers = await db.QueryAsync("SELECT TrainerID as Id, TrainerName as Name FROM Trainers");
                    cmbEntities.DataSource = trainers.ToList();
                }
                else
                {
                    string empType = _historyType == PaymentHistoryType.EmployeeCommission ? "Commission" : "Salary";
                    var employees = await db.QueryAsync("SELECT EmployeeID as Id, EmployeeName as Name FROM Employees WHERE EmployeeType = @Type", new { Type = empType });
                    cmbEntities.DataSource = employees.ToList();
                }

                cmbEntities.DisplayMember = "Name";
                cmbEntities.ValueMember = "Id";
                cmbEntities.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل القائمة: {ex.Message}");
            }
        }

        private async Task LoadHistoryAsync(int? entityId)
        {
            try
            {
                using var db = _dbFactory.CreateConnection();
                string sql = "";

                if (_historyType == PaymentHistoryType.Trainer)
                {
                    sql = @"
                        SELECT 
                            TP.PaymentID AS [رقم العملية],
                            T.TrainerName AS [اسم المدربة],
                            S.SafeName AS [الخزنة],
                            TP.AmountPaid AS [المبلغ المصروف],
                            TP.PaymentDate AS [تاريخ الصرف],
                            TP.Notes AS [ملاحظات]
                        FROM TrainerPayments TP
                        JOIN Trainers T ON TP.TrainerID = T.TrainerID
                        JOIN Safes S ON TP.SafeID = S.SafeID
                        WHERE (@EntityId IS NULL OR TP.TrainerID = @EntityId)
                        ORDER BY TP.PaymentDate DESC";
                }
                else
                {
                    // Since both salary and commission employees are in EmployeePayments, we filter by EmployeeType
                    string empType = _historyType == PaymentHistoryType.EmployeeCommission ? "Commission" : "Salary";
                    sql = @"
                        SELECT 
                            EP.PaymentID AS [رقم العملية],
                            E.EmployeeName AS [اسم الموظفة],
                            S.SafeName AS [الخزنة],
                            EP.AmountPaid AS [المبلغ المصروف],
                            EP.PaymentDate AS [تاريخ الصرف],
                            EP.Notes AS [ملاحظات]
                        FROM EmployeePayments EP
                        JOIN Employees E ON EP.EmployeeID = E.EmployeeID
                        JOIN Safes S ON EP.SafeID = S.SafeID
                        WHERE (@EntityId IS NULL OR EP.EmployeeID = @EntityId)
                        AND E.EmployeeType = @Type
                        ORDER BY EP.PaymentDate DESC";
                }

                object param = _historyType == PaymentHistoryType.Trainer 
                    ? (object)new { EntityId = entityId } 
                    : new { EntityId = entityId, Type = _historyType == PaymentHistoryType.EmployeeCommission ? "Commission" : "Salary" };

                var data = await db.QueryAsync(sql, param);
                dgvHistory.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل السجل: {ex.Message}");
            }
        }

        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            if (cmbEntities.SelectedValue != null)
            {
                int id = (int)cmbEntities.SelectedValue;
                await LoadHistoryAsync(id);
            }
        }

        private async void BtnReset_Click(object? sender, EventArgs e)
        {
            cmbEntities.SelectedIndex = -1;
            await LoadHistoryAsync(null);
        }

        private async void CmbEntities_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbEntities.SelectedIndex == -1)
            {
                await LoadHistoryAsync(null);
            }
        }
    }
}
