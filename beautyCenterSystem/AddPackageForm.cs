using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Models;
using beautyCenterSystem.data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class AddPackageForm : Form
    {
        private readonly GymRepository _gymRepo;
        private readonly TrainerRepository _trainerRepo;
        private BindingList<GymPackageTrainer> _packageTrainers;

        public AddPackageForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "إضافة باقة جديدة";
            _gymRepo = new GymRepository(new DbConnectionFactory());
            _trainerRepo = new TrainerRepository(new DbConnectionFactory());
            _packageTrainers = new BindingList<GymPackageTrainer>();
            
            chkIsSessionBased.CheckedChanged += ChkIsSessionBased_CheckedChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnAddTrainer.Click += BtnAddTrainer_Click;
            this.Load += AddPackageForm_Load;
        }

        private void AddPackageForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            try
            {
                var trainers = await _trainerRepo.GetAllAsync();
                cmbTrainers.DisplayMember = "TrainerName";
                cmbTrainers.ValueMember = "TrainerID";
                cmbTrainers.DataSource = trainers.ToList();
                
                dgvTrainers.DataSource = _packageTrainers;
                if (dgvTrainers.Columns.Contains("PackageID")) dgvTrainers.Columns["PackageID"].Visible = false;
                if (dgvTrainers.Columns.Contains("TrainerID")) dgvTrainers.Columns["TrainerID"].Visible = false;
                
                if (dgvTrainers.Columns.Contains("TrainerName")) dgvTrainers.Columns["TrainerName"].HeaderText = "اسم المدربة";
                if (dgvTrainers.Columns.Contains("BaseAmount")) dgvTrainers.Columns["BaseAmount"].HeaderText = "حصة المدربة (إن وجدت)";
                if (dgvTrainers.Columns.Contains("CommissionRate")) dgvTrainers.Columns["CommissionRate"].HeaderText = "النسبة %";
                
                SetupTrainersContextMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل المدربات: {ex.Message}");
            }
        }

        private void BtnAddTrainer_Click(object sender, EventArgs e)
        {
            if (cmbTrainers.SelectedItem == null) return;
            
            if (!decimal.TryParse(txtBaseAmount.Text, out decimal baseAmount))
            {
                MessageBox.Show("يرجى إدخال مبلغ أساسي صحيح.");
                return;
            }
            if (!decimal.TryParse(txtCommissionRate.Text, out decimal commissionRate))
            {
                MessageBox.Show("يرجى إدخال نسبة صحيحة.");
                return;
            }

            var selectedTrainer = (Trainer)cmbTrainers.SelectedItem;
            
            if (_packageTrainers.Any(t => t.TrainerID == selectedTrainer.TrainerID))
            {
                MessageBox.Show("المدربة مضافة مسبقاً لهذه الباقة.");
                return;
            }

            _packageTrainers.Add(new GymPackageTrainer
            {
                TrainerID = selectedTrainer.TrainerID,
                TrainerName = selectedTrainer.TrainerName,
                BaseAmount = baseAmount,
                CommissionRate = commissionRate
            });

            txtBaseAmount.Clear();
            txtCommissionRate.Clear();
        }

        private void SetupTrainersContextMenu()
        {
            var menu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("حذف المدربة");
            deleteItem.Click += (s, ev) =>
            {
                if (dgvTrainers.SelectedRows.Count > 0)
                {
                    var row = dgvTrainers.SelectedRows[0];
                    var trainer = (GymPackageTrainer)row.DataBoundItem;
                    _packageTrainers.Remove(trainer);
                }
            };
            menu.Items.Add(deleteItem);
            dgvTrainers.ContextMenuStrip = menu;
        }

        private void ChkIsSessionBased_CheckedChanged(object sender, EventArgs e)
        {
            txtTotalSessions.Enabled = chkIsSessionBased.Checked;
            if (!chkIsSessionBased.Checked)
                txtTotalSessions.Text = "0";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageName.Text) || 
                string.IsNullOrWhiteSpace(txtPrice.Text) || 
                string.IsNullOrWhiteSpace(txtDurationDays.Text))
            {
                MessageBox.Show("يرجى تعبئة الحقول الأساسية (الاسم، المدة، السعر).");
                return;
            }

            try
            {
                var package = new GymSubscriptionType
                {
                    TypeName = txtPackageName.Text,
                    DurationDays = int.Parse(txtDurationDays.Text),
                    Price = decimal.Parse(txtPrice.Text),
                    IsSessionBased = chkIsSessionBased.Checked,
                    TotalSessions = chkIsSessionBased.Checked && !string.IsNullOrWhiteSpace(txtTotalSessions.Text) ? int.Parse(txtTotalSessions.Text) : 0
                };

                bool success = await _gymRepo.AddSubscriptionTypeAsync(package, _packageTrainers.ToList());
                
                if (success)
                {
                    MessageBox.Show("تمت الإضافة بنجاح!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء الحفظ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
