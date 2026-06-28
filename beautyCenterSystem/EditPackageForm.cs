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
    public partial class EditPackageForm : Form
    {
        private readonly GymRepository _gymRepo;
        private readonly TrainerRepository _trainerRepo;
        private BindingList<GymPackageTrainer> _packageTrainers;
        private GymSubscriptionType _packageToEdit;

        public EditPackageForm(GymSubscriptionType package)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "تعديل بيانات الباقة";
            _gymRepo = new GymRepository(new DbConnectionFactory());
            _trainerRepo = new TrainerRepository(new DbConnectionFactory());
            _packageTrainers = new BindingList<GymPackageTrainer>();
            _packageToEdit = package;
            
            chkIsSessionBased.CheckedChanged += ChkIsSessionBased_CheckedChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnAddTrainer.Click += BtnAddTrainer_Click;
            
            // Delete button for trainers
            dgvTrainers.KeyDown += DgvTrainers_KeyDown;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            btnCancel.BackColor = System.Drawing.Color.Gray;
            
            try
            {
                // Populate existing package fields
                txtPackageName.Text = _packageToEdit.TypeName;
                txtDurationDays.Text = _packageToEdit.DurationDays.ToString();
                txtPrice.Text = _packageToEdit.Price.ToString("0.00");
                chkIsSessionBased.Checked = _packageToEdit.IsSessionBased;
                txtTotalSessions.Text = _packageToEdit.TotalSessions.ToString();
                txtTotalSessions.Enabled = _packageToEdit.IsSessionBased;

                var trainers = await _trainerRepo.GetAllAsync();
                cmbTrainers.DisplayMember = "TrainerName";
                cmbTrainers.ValueMember = "TrainerID";
                cmbTrainers.DataSource = trainers.ToList();
                
                // Load existing package trainers
                var existingTrainers = await _gymRepo.GetPackageTrainersAsync(_packageToEdit.TypeID);
                foreach(var t in existingTrainers)
                {
                    _packageTrainers.Add(t);
                }

                dgvTrainers.DataSource = _packageTrainers;
                if (dgvTrainers.Columns.Contains("PackageID")) dgvTrainers.Columns["PackageID"].Visible = false;
                if (dgvTrainers.Columns.Contains("TrainerID")) dgvTrainers.Columns["TrainerID"].Visible = false;
                
                if (dgvTrainers.Columns.Contains("TrainerName")) dgvTrainers.Columns["TrainerName"].HeaderText = "اسم المدربة";
                if (dgvTrainers.Columns.Contains("BaseAmount")) dgvTrainers.Columns["BaseAmount"].HeaderText = "حصة المدربة (إن وجدت)";
                if (dgvTrainers.Columns.Contains("CommissionRate")) dgvTrainers.Columns["CommissionRate"].HeaderText = "نسبة %";

                SetupTrainersContextMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}");
            }
        }

        private void BtnAddTrainer_Click(object sender, EventArgs e)
        {
            if (cmbTrainers.SelectedItem == null) return;
            
            if (!decimal.TryParse(txtBaseAmount.Text, out decimal baseAmount))
            {
                MessageBox.Show("الرجاء إدخال مبلغ صحيح.");
                return;
            }
            if (!decimal.TryParse(txtCommissionRate.Text, out decimal commissionRate))
            {
                MessageBox.Show("الرجاء إدخال نسبة صحيحة.");
                return;
            }

            var selectedTrainer = (Trainer)cmbTrainers.SelectedItem;
            
            if (_packageTrainers.Any(t => t.TrainerID == selectedTrainer.TrainerID))
            {
                MessageBox.Show("هذه المدربة موجودة بالفعل في القائمة.");
                return;
            }

            _packageTrainers.Add(new GymPackageTrainer
            {
                PackageID = _packageToEdit.TypeID,
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

        private void DgvTrainers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvTrainers.SelectedRows.Count > 0)
            {
                var row = dgvTrainers.SelectedRows[0];
                var trainer = (GymPackageTrainer)row.DataBoundItem;
                _packageTrainers.Remove(trainer);
            }
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
                MessageBox.Show("الرجاء تعبئة جميع الحقول المطلوبة (اسم الباقة، المدة، السعر).");
                return;
            }

            try
            {
                _packageToEdit.TypeName = txtPackageName.Text;
                _packageToEdit.DurationDays = int.Parse(txtDurationDays.Text);
                _packageToEdit.Price = decimal.Parse(txtPrice.Text);
                _packageToEdit.IsSessionBased = chkIsSessionBased.Checked;
                _packageToEdit.TotalSessions = chkIsSessionBased.Checked && !string.IsNullOrWhiteSpace(txtTotalSessions.Text) ? int.Parse(txtTotalSessions.Text) : 0;

                bool success = await _gymRepo.UpdateSubscriptionTypeAsync(_packageToEdit, _packageTrainers.ToList());
                
                if (success)
                {
                    MessageBox.Show("تم تحديث الباقة بنجاح!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء التحديث.");
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
