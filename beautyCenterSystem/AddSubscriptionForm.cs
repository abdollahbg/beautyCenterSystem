using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using beautyCenterSystem.Data.Repositories;
using System;
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

        public AddSubscriptionForm()
        {
            InitializeComponent();
            var factory = new DbConnectionFactory();
            _customerRepo = new CustomerRepository(factory);
            _gymRepo = new GymRepository(factory);

            // Event Handlers
            this.Load += AddSubscriptionForm_Load;
            btnNewCustomer.Click += BtnNewCustomer_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            cmbSubscriptionTypes.SelectedIndexChanged += CmbSubscriptionTypes_SelectedIndexChanged;
        }

        private async void AddSubscriptionForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            pnlHeader.BackColor = AppTheme.Primary;
            btnCancel.BackColor = Color.Gray;

            // default payment
            cmbPaymentMethod.SelectedIndex = 0; 
            
            await LoadCustomersAsync();
            await LoadSubscriptionTypesAsync();
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

        private void CmbSubscriptionTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubscriptionTypes.SelectedItem is GymSubscriptionType selectedType)
            {
                txtPaidAmount.Text = selectedType.Price.ToString("0.00");
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
                    // Select the newly added customer (assuming it's at the bottom or we could just select the last)
                    if (cmbCustomers.Items.Count > 0)
                        cmbCustomers.SelectedIndex = cmbCustomers.Items.Count - 1;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار عميلة.");
                return;
            }

            if (cmbSubscriptionTypes.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار نوع الباقة.");
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
                    // IssuedBy and SafeID will be handled or mapped later if Session context available
                };

                string paymentMethod = cmbPaymentMethod.SelectedItem.ToString(); // "Cash" or "Card"

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
                MessageBox.Show($"خطأ أثناء تسجيل الاشتراك: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BtnCancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
