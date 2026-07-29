using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using beautyCenterSystem.data.Repositories;

namespace beautyCenterSystem
{
    public partial class UC_Trainers : UserControl
    {
        private readonly TrainerRepository _trainerRepo;
        private List<TrainerViewModel> _allTrainers = new List<TrainerViewModel>();

        public UC_Trainers()
        {
            _trainerRepo = new TrainerRepository(new DbConnectionFactory());

            InitializeComponent();

            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvTrainers.CellValidating += DgvTrainers_CellValidating;
            this.dgvTrainers.CellEndEdit += DgvTrainers_CellEndEdit;
            this.btnAddTrainer.Click += BtnAddTrainer_Click;
            this.btnDeactivateTrainer.Click += BtnDeactivateTrainer_Click;
            this.btnPayCommission.Click += BtnPayCommission_Click;
            this.btnPaymentHistory.Click += BtnPaymentHistory_Click;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                AppTheme.Apply(this);
                SetupGridColumns();
                await LoadTrainersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل واجهة المدربات: {ex.Message}", "خطأ في التحميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGridColumns()
        {
            dgvTrainers.AutoGenerateColumns = false;
            dgvTrainers.Columns.Clear();

            dgvTrainers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrainerID",
                DataPropertyName = "TrainerID",
                Visible = false
            });

            dgvTrainers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrainerName",
                HeaderText = "اسم المدربة",
                DataPropertyName = "TrainerName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvTrainers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                HeaderText = "رقم الهاتف",
                DataPropertyName = "Phone",
                Width = 150
            });

            // عمود المستحقات الحالية
            dgvTrainers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentDues",
                HeaderText = "المستحقات الحالية",
                DataPropertyName = "CurrentDues",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                Width = 120,
                ReadOnly = true
            });
        }

        private async Task LoadTrainersData()
        {
            try
            {
                var data = await _trainerRepo.GetAllAsync();

                _allTrainers = data.Select(d => new TrainerViewModel
                {
                    TrainerID = d.TrainerID,
                    TrainerName = d.TrainerName,
                    Phone = d.Phone,
                    CurrentDues = d.CurrentDues
                }).ToList();

                dgvTrainers.DataSource = _allTrainers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب بيانات المدربات: {ex.Message}");
            }
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                dgvTrainers.DataSource = _allTrainers;
            }
            else
            {
                var filtered = _allTrainers.Where(t =>
                    (t.TrainerName != null && t.TrainerName.ToLower().Contains(query)) ||
                    (t.Phone != null && t.Phone.Contains(query))
                ).ToList();

                dgvTrainers.DataSource = filtered;
            }
        }

        private void BtnAddTrainer_Click(object? sender, EventArgs e)
        {
            using (var frmAdd = new AddTrainerForm())
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadTrainersData();
                }
            }
        }

        private void BtnPayCommission_Click(object? sender, EventArgs e)
        {
            if (dgvTrainers.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد مدربة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var trainer = dgvTrainers.CurrentRow.DataBoundItem as TrainerViewModel;

            if (trainer != null)
            {
                var paymentForm = new TrainerPaymentForm(CurrentSession.UserID);
                paymentForm.SelectedTrainerId = trainer.TrainerID;
                paymentForm.ShowDialog();

                // تحديث البيانات بعد إغلاق شاشة الصرف
                _ = LoadTrainersData();
            }
        }

        private void BtnPaymentHistory_Click(object? sender, EventArgs e)
        {
            var historyForm = new PaymentHistoryForm(PaymentHistoryType.Trainer);
            historyForm.ShowDialog();
        }

        private async void BtnDeactivateTrainer_Click(object? sender, EventArgs e)
        {
            if (dgvTrainers.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد مدربة من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var trainer = dgvTrainers.CurrentRow.DataBoundItem as TrainerViewModel;
            if (trainer != null)
            {
                var confirmResult = MessageBox.Show($"هل أنت متأكد من إيقاف المدربة ({trainer.TrainerName})؟", "تأكيد الإيقاف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    await _trainerRepo.DeleteAsync(trainer.TrainerID);
                    MessageBox.Show("تم الإيقاف بنجاح.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTrainersData();
                }
            }
        }

        private void DgvTrainers_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgvTrainers.IsCurrentCellDirty) return;

            string columnName = dgvTrainers.Columns[e.ColumnIndex].Name;
            string newValue = e.FormattedValue?.ToString()?.Trim() ?? "";

            if (columnName == "TrainerName" && string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("اسم المدربة لا يمكن أن يكون فارغاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private async void DgvTrainers_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            var vm = dgvTrainers.Rows[e.RowIndex].DataBoundItem as TrainerViewModel;
            if (vm != null)
            {
                var t = new Trainer
                {
                    TrainerID = vm.TrainerID,
                    TrainerName = vm.TrainerName,
                    Phone = vm.Phone
                };

                try
                {
                    await _trainerRepo.UpdateAsync(t);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadTrainersData();
                }
            }
        }
    }

    public class TrainerViewModel
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public string Phone { get; set; }
        public decimal CurrentDues { get; set; }
    }
}
