using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_Customers : UserControl
    {
        private readonly CustomerRepository _customerRepo;
        public UC_Customers()
        {
            InitializeComponent();
            _customerRepo = new CustomerRepository(new DbConnectionFactory());
        }
        private void UpdateCustomerCount()
        {
            // الحصول على عدد الصفوف الحقيقي في الجدول
            int count = dgvCustomers.Rows.Count;

            // إذا كان الجدول يسمح بضافة صف يدوي (السطر الفارغ الأخير)، نطرح 1


            lblNumberOfCustumer.ForeColor = Color.DimGray;
            lblNumberOfCustumer.Text = $"لديك {count} عميل مسجلة";
        }
        public async Task LoadCustomers(string term = "")
        {
            try
            {
                IEnumerable<Customer> data;

                if (string.IsNullOrWhiteSpace(term))
                    data = await _customerRepo.GetAllAsync();
                else
                    data = await _customerRepo.SearchAsync(term);

                dgvCustomers.DataSource = data.ToList();
                FormatGrid(); // ميثود لتنسيق الجدول
                UpdateCustomerCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب البيانات: {ex.Message}");
            }
        }
        private void FormatGrid()
        {
            if (dgvCustomers.Columns.Count > 0)
            {
                dgvCustomers.Columns["CustomerID"].Visible = false; // إخفاء الآيدي
                dgvCustomers.Columns["CustomerName"].HeaderText = "اسم العميل";
                dgvCustomers.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvCustomers.Columns["Notes"].HeaderText = "ملاحظات";
                dgvCustomers.Columns["CreatedAt"].HeaderText = "تاريخ الإضافة";


            }
            if (dgvCustomers.Columns.Contains("CreatedAt"))
                dgvCustomers.Columns["CreatedAt"].ReadOnly = true;


            dgvCustomers.ReadOnly = false;
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddCustomer.FlatStyle = FlatStyle.Flat;
                btnAddCustomer.FlatAppearance.BorderSize = 1;
                btnAddCustomer.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddCustomer.BackColor = Color.White;
            });
            await LoadCustomers();
        }

        private void UC_Customers_Load(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddCustomerForm())
            {


                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadCustomers();

                }
            }
        }





        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnAddCustomer_Click_2(object sender, EventArgs e)
        {
            using (var addForm = new AddCustomerForm())
            {
                AppTheme.Apply(addForm);

                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadCustomers();

                }
                lblNumberOfCustumer.Text = dgvCustomers.RowCount.ToString();

            }
        }

        private void dgvCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtboxSearch_Click(object sender, EventArgs e)
        {

        }

        private async void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadCustomers(txtboxSearch.Text.Trim());

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // 1. التأكد من أن المستخدم اختار صفاً
            if (dgvCustomers.CurrentRow != null)
            {
                // 2. الحصول على بيانات العميلة المحددة
                var customer = dgvCustomers.CurrentRow.DataBoundItem as Customer;

                if (customer != null)
                {
                    // 3. رسالة تأكيد (للحماية من الحذف بالخطأ)
                    var result = MessageBox.Show($"هل أنت متأكد من حذف العميلة: {customer.CustomerName}؟",
                                               "تأكيد الحذف",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // 4. تنفيذ الحذف من قاعدة البيانات
                            bool isDeleted = await _customerRepo.DeleteAsync(customer.CustomerID);

                            if (isDeleted)
                            {
                                // 5. تحديث الجدول والعداد فوراً
                                await LoadCustomers();
                                MessageBox.Show("تم حذف العميلة بنجاح.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void dgvCustomers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCustomers.ClearSelection();
                dgvCustomers.Rows[e.RowIndex].Selected = true;
                dgvCustomers.CurrentCell = dgvCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private async void dgvCustomers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var customer = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;

            if (customer != null)
            {
                if (string.IsNullOrWhiteSpace(customer.CustomerName))
                {
                    MessageBox.Show("عذراً، لا يمكن ترك اسم العميل فارغاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadCustomers();
                    return;
                }

                try
                {
                    bool isUpdated = await _customerRepo.UpdateAsync(customer);

                    if (isUpdated)
                    {
                        MessageBox.Show("تم التعديل بنجاح");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حفظ التعديل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadCustomers();
                }
            }
        }

        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void dgvCustomers_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
