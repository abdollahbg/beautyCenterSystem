using BeautyCenterSystem.Data;
using beautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_GymManagement : UserControl
    {
        private readonly GymRepository _gymRepo;

        public UC_GymManagement()
        {
            InitializeComponent();
            _gymRepo = new GymRepository(new DbConnectionFactory());

            // Hook up events
            btnNewSubscription.Click += BtnNewSubscription_Click;
            btnCheckIn.Click += BtnCheckIn_Click;
            btnSavePackage.Click += BtnSavePackage_Click;
            btnDeletePackage.Click += BtnDeletePackage_Click;
            chkIsSessionBased.CheckedChanged += ChkIsSessionBased_CheckedChanged;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            await LoadAllDataAsync();
        }

        private async Task LoadAllDataAsync()
        {
            try
            {
                // 1. Load Customer Subscriptions
                var allSubscriptions = await _gymRepo.GetAllCustomerSubscriptionsAsync();

                dgvActive.DataSource = allSubscriptions.Where(s => s.SubscriptionStatus == "ساري" || s.SubscriptionStatus == "حصص قاربت للنفاد").ToList();
                dgvNearExpiry.DataSource = allSubscriptions.Where(s => s.SubscriptionStatus == "قرب الانتهاء").ToList();
                dgvExpired.DataSource = allSubscriptions.Where(s => s.SubscriptionStatus == "منتهي" || s.SubscriptionStatus == "انتهت الحصص").ToList();

                FormatSubscriptionsGrid(dgvActive);
                FormatSubscriptionsGrid(dgvNearExpiry);
                FormatSubscriptionsGrid(dgvExpired);

                // 2. Load Packages
                var packages = await _gymRepo.GetAllSubscriptionTypesAsync();
                dgvPackages.DataSource = packages.ToList();
                FormatPackagesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب البيانات: {ex.Message}");
            }
        }

        private void FormatSubscriptionsGrid(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["SubscriptionID"].Visible = false;
                dgv.Columns["CustomerName"].HeaderText = "اسم العميلة";
                dgv.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgv.Columns["SubscriptionType"].HeaderText = "نوع الباقة";
                dgv.Columns["IsSessionBased"].HeaderText = "بنظام الحصص؟";
                dgv.Columns["StartDate"].HeaderText = "تاريخ البدء";
                dgv.Columns["EndDate"].HeaderText = "تاريخ الانتهاء";
                dgv.Columns["SessionsRemaining"].HeaderText = "الحصص المتبقية";
                dgv.Columns["SubscriptionStatus"].HeaderText = "الحالة";
                dgv.Columns["PaidAmount"].HeaderText = "المبلغ المدفوع";
            }
        }

        private void FormatPackagesGrid()
        {
            if (dgvPackages.Columns.Count > 0)
            {
                dgvPackages.Columns["TypeID"].Visible = false;
                dgvPackages.Columns["TypeName"].HeaderText = "اسم الباقة";
                dgvPackages.Columns["DurationDays"].HeaderText = "المدة بالأيام";
                dgvPackages.Columns["Price"].HeaderText = "السعر";
                dgvPackages.Columns["IsActive"].Visible = false;
                dgvPackages.Columns["IsSessionBased"].HeaderText = "بنظام الحصص؟";
                dgvPackages.Columns["TotalSessions"].HeaderText = "إجمالي الحصص";
            }
        }

        private void ChkIsSessionBased_CheckedChanged(object sender, EventArgs e)
        {
            txtTotalSessions.Enabled = chkIsSessionBased.Checked;
            if (!chkIsSessionBased.Checked)
                txtTotalSessions.Text = "0";
        }

        private async void BtnSavePackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtDurationDays.Text))
            {
                MessageBox.Show("الرجاء إدخال بيانات الباقة الأساسية (الاسم، المدة، السعر).");
                return;
            }

            try
            {
                var package = new GymSubscriptionType
                {
                    TypeName = txtPackageName.Text.Trim(),
                    DurationDays = int.Parse(txtDurationDays.Text),
                    Price = decimal.Parse(txtPrice.Text),
                    IsSessionBased = chkIsSessionBased.Checked,
                    TotalSessions = chkIsSessionBased.Checked ? int.Parse(txtTotalSessions.Text) : 0,
                    IsActive = true
                };

                bool saved = false;

                // If editing existing, would check ID. Here we assume Add new
                if (dgvPackages.CurrentRow != null && dgvPackages.CurrentRow.Selected)
                {
                    var selected = dgvPackages.CurrentRow.DataBoundItem as GymSubscriptionType;
                    package.TypeID = selected.TypeID;
                    saved = await _gymRepo.UpdateSubscriptionTypeAsync(package);
                }
                else
                {
                    saved = await _gymRepo.AddSubscriptionTypeAsync(package);
                }

                if (saved)
                {
                    MessageBox.Show("تم حفظ الباقة بنجاح.");
                    txtPackageName.Clear();
                    txtDurationDays.Clear();
                    txtPrice.Clear();
                    txtTotalSessions.Clear();
                    chkIsSessionBased.Checked = false;
                    dgvPackages.ClearSelection();
                    await LoadAllDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ الباقة: {ex.Message}");
            }
        }

        private async void BtnDeletePackage_Click(object sender, EventArgs e)
        {
            if (dgvPackages.CurrentRow != null)
            {
                var package = dgvPackages.CurrentRow.DataBoundItem as GymSubscriptionType;
                if (package != null)
                {
                    var result = MessageBox.Show($"هل أنت متأكد من حذف الباقة: {package.TypeName}؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bool deleted = await _gymRepo.DeleteSubscriptionTypeAsync(package.TypeID);
                            if (deleted)
                            {
                                MessageBox.Show("تم الحذف بنجاح.");
                                await LoadAllDataAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"خطأ في الحذف: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("الرجاء تحديد باقة للحذف.");
            }
        }

        private async void BtnNewSubscription_Click(object sender, EventArgs e)
        {
            using (var form = new AddSubscriptionForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Refresh main grids after a successful registration
                    await LoadAllDataAsync();
                }
            }
        }

        private async void BtnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvActive.CurrentRow != null)
            {
                var sub = dgvActive.CurrentRow.DataBoundItem as GymSubscriptionStatus;
                if (sub != null && sub.IsSessionBased)
                {
                    var result = MessageBox.Show($"تأكيد حضور حصة للعميلة {sub.CustomerName}؟\nالمتبقي قبل التسجيل: {sub.SessionsRemaining} حصص", "تأكيد حضور", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bool checkedIn = await _gymRepo.CheckInSessionAsync(sub.SubscriptionID, "حضور حصة عادي");
                            if (checkedIn)
                            {
                                MessageBox.Show("تم تسجيل الحضور وخصم حصة بنجاح.");
                                await LoadAllDataAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"خطأ في تسجيل الحضور: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("هذا الاشتراك ليس بنظام الحصص أو لم يتم تحديد اشتراك صالح.");
                }
            }
            else
            {
                MessageBox.Show("الرجاء تحديد اشتراك من الجدول.");
            }
        }
    }
}
