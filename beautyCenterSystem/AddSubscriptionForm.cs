using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Models;
using beautyCenterSystem.data.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class AddSubscriptionForm : Form
    {
        private readonly CustomerRepository _customerRepo;
        private readonly GymRepository _gymRepo;
        private DataGridView dgvTrainers;
        private Label lblTrainers;

        public AddSubscriptionForm()
        {
            InitializeComponent();
            var factory = new DbConnectionFactory();
            _customerRepo = new CustomerRepository(factory);
            _gymRepo = new GymRepository(factory);

            InitializeTrainersGrid();

            this.Load += AddSubscriptionForm_Load;
            btnNewCustomer.Click += BtnNewCustomer_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            cmbSubscriptionTypes.SelectedIndexChanged += CmbSubscriptionTypes_SelectedIndexChanged;
        }

        private async void AddSubscriptionForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            pnlHeader.Visible = false; // Using standard OS title bar now
            btnCancel.BackColor = Color.Gray;

            cmbPaymentMethod.SelectedIndex = 0; 
            
            await LoadCustomersAsync();
            await LoadSubscriptionTypesAsync();
        }

        private void InitializeTrainersGrid()
        {
            // توسيع الواجهة قليلاً لتبدو مرتبة
            int oldWidth = this.Width;
            this.Width = 650;
            this.Height = 600; // تقليل الطول الإجمالي ليبدو طبيعيا
            
            int diff = (this.Width - oldWidth) / 2;

            // إضافة عنوان للجدول (مرفوع للأعلى)
            lblTrainers = new Label
            {
                Text = "المدربات المتاحات (يرجى اختيار المدربة):",
                Location = new Point(30, 275),
                AutoSize = true,
                Font = new Font("Arial", 10F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray
            };
            this.Controls.Add(lblTrainers);

            // إعداد جدول المدربات ليكون سهل القراءة ومنسق (مرفوع للأعلى وأكثر اتساعاً أفقياً وعمودياً)
            dgvTrainers = new DataGridView
            {
                Location = new Point(30, 305),
                Size = new Size(590, 200), // زيادة الارتفاع لإظهار المزيد من المدربات
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BorderStyle = BorderStyle.Fixed3D,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.LightGray
            };

            // تنسيق رأس الجدول
            dgvTrainers.EnableHeadersVisualStyles = false;
            dgvTrainers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            dgvTrainers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTrainers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvTrainers.ColumnHeadersHeight = 35;
            
            dgvTrainers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgvTrainers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTrainers.DefaultCellStyle.Font = new Font("Arial", 10F);

            var colSelect = new DataGridViewCheckBoxColumn
            {
                HeaderText = "اختيار",
                Name = "colSelect",
                Width = 50
            };

            var colTrainerId = new DataGridViewTextBoxColumn { Name = "colTrainerId", Visible = false };
            var colTrainerName = new DataGridViewTextBoxColumn { HeaderText = "اسم المدربة", ReadOnly = true };
            var colBaseAmount = new DataGridViewTextBoxColumn { HeaderText = "حصة المدربة (إن وجدت)", ReadOnly = true };
            var colCommissionRate = new DataGridViewTextBoxColumn { HeaderText = "النسبة %", ReadOnly = true };

            dgvTrainers.Columns.Add(colSelect);
            dgvTrainers.Columns.Add(colTrainerId);
            dgvTrainers.Columns.Add(colTrainerName);
            dgvTrainers.Columns.Add(colBaseAmount);
            dgvTrainers.Columns.Add(colCommissionRate);
            
            this.Controls.Add(dgvTrainers);
            
            // توسيط العناصر الأصلية في الشاشة بعد التوسيع ورفعها للأعلى لملء الفراغ
            foreach (Control c in this.Controls)
            {
                if (c != pnlHeader && c != dgvTrainers && c != lblTrainers)
                {
                    c.Left += diff;
                    c.Top -= 40; // رفع العناصر للأعلى 40 بكسل
                }
            }
            
            // توسيط زري الحفظ والإلغاء في الأسفل
            btnSave.Location = new Point(this.Width / 2 - btnSave.Width - 10, 515);
            btnCancel.Location = new Point(this.Width / 2 + 10, 515);
        }

        private async Task LoadCustomersAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            cmbCustomers.DataSource = customers.ToList();
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.ValueMember = "CustomerID";
        }

        private async Task LoadSubscriptionTypesAsync()
        {
            var types = await _gymRepo.GetAllSubscriptionTypesAsync();
            cmbSubscriptionTypes.DataSource = types.ToList();
            cmbSubscriptionTypes.DisplayMember = "TypeName";
            cmbSubscriptionTypes.ValueMember = "TypeID";
        }

        private async void CmbSubscriptionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubscriptionTypes.SelectedItem is GymSubscriptionType selectedType)
            {
                txtPaidAmount.Text = selectedType.Price.ToString("0.00");
                
                dgvTrainers.Rows.Clear();
                var packageTrainers = await _gymRepo.GetPackageTrainersAsync(selectedType.TypeID);
                foreach (var t in packageTrainers)
                {
                    dgvTrainers.Rows.Add(false, t.TrainerID, t.TrainerName, t.BaseAmount, t.CommissionRate);
                }
            }
        }

        private async void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddCustomerForm())
            {
                var result = addForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await LoadCustomersAsync();
                    if (cmbCustomers.Items.Count > 0)
                        cmbCustomers.SelectedIndex = cmbCustomers.Items.Count - 1;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار عميلة.");
                return;
            }

            if (cmbSubscriptionTypes.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار نوع الاشتراك.");
                return;
            }

            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount))
            {
                MessageBox.Show("المبلغ المدفوع غير صحيح.");
                return;
            }

            try
            {
                var selectedCustomer = (Customer)cmbCustomers.SelectedItem;
                var selectedType = (GymSubscriptionType)cmbSubscriptionTypes.SelectedItem;

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = startDate.AddDays(selectedType.DurationDays);

                var newSubscription = new CustomerGymSubscription
                {
                    CustomerID = selectedCustomer.CustomerID,
                    TypeID = selectedType.TypeID,
                    StartDate = startDate,
                    EndDate = endDate,
                    PaidAmount = paidAmount,
                    Notes = txtNotes.Text.Trim(),
                    SessionsRemaining = selectedType.IsSessionBased ? selectedType.TotalSessions : 0
                };

                foreach (DataGridViewRow row in dgvTrainers.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["colSelect"].Value);
                    if (isSelected)
                    {
                        int trainerId = Convert.ToInt32(row.Cells["colTrainerId"].Value);
                        decimal baseAmount = Convert.ToDecimal(row.Cells[3].Value);
                        decimal commRate = Convert.ToDecimal(row.Cells[4].Value);

                        newSubscription.Trainers.Add(new GymSubscriptionTrainer
                        {
                            TrainerID = trainerId,
                            BaseAmount = baseAmount,
                            CommissionRate = commRate
                        });
                    }
                }

                string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";

                bool success = await _gymRepo.RegisterCustomerSubscriptionAsync(newSubscription, paymentMethod);
                
                if (success)
                {
                    MessageBox.Show("تم تسجيل الاشتراك بنجاح.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء حفظ الاشتراك: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
