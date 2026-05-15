using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem
{
    public partial class UC_GymManagement : UserControl
    {
        private readonly GymRepository _gymRepo;

        // متغيرات لتخزين البيانات محلياً لتسريع عملية البحث الفوري
        private List<GymSubscriptionStatus> _allSubscriptions = new List<GymSubscriptionStatus>();
        private List<GymSubscriptionType> _allPackages = new List<GymSubscriptionType>();

        public UC_GymManagement()
        {
            InitializeComponent();
            _gymRepo = new GymRepository(new DbConnectionFactory());

            // Hook up events
            btnNewSubscription.Click += BtnNewSubscription_Click;
            btnCheckIn.Click += BtnCheckIn_Click;
            btnAddNewPackage.Click += BtnAddNewPackage_Click;
            btnEditPackage.Click += BtnEditPackage_Click;
            btnDeletePackage.Click += BtnDeletePackage_Click;
            dgvPackages.SelectionChanged += DgvPackages_SelectionChanged;

            // أحداث الفلترة والبحث الجديدة
            btnFilter.Click += BtnFilter_Click;
            txtBoxsearch.TextChanged += TxtBoxsearch_TextChanged;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppTheme.Apply(this);
            // جلب البيانات لأول مرة بناءً على التواريخ الافتراضية في الديزاينر (آخر 3 شهور)
            await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
        }

        // دالة الزر المسؤولة عن تصفية التواريخ
        private async void BtnFilter_Click(object sender, EventArgs e)
        {
            await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
        }

        // حدث البحث الفوري أثناء الكتابة
        private void TxtBoxsearch_TextChanged(object sender, EventArgs e)
        {
            BindGrids(txtBoxsearch.Text);
        }

        // تحديث الدالة لتقبل التواريخ كمعاملات
        private async Task LoadAllDataAsync(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                // 1. جلب الاشتراكات من قاعدة البيانات مع تطبيق الفلترة بالتاريخ
                var subscriptions = await _gymRepo.GetAllCustomerSubscriptionsAsync(fromDate, toDate);
                _allSubscriptions = subscriptions.ToList();

                // 2. جلب الباقات (لا تحتاج فلترة بالتاريخ عادة)
                var packages = await _gymRepo.GetAllSubscriptionTypesAsync();
                _allPackages = packages.ToList();

                // 3. عرض البيانات في الجداول بناءً على نص البحث الحالي (إن وجد)
                BindGrids(txtBoxsearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب البيانات: {ex.Message}");
            }
        }

        // دالة مساعدة لتوزيع البيانات على الجداول وتطبيق البحث الفوري
        private void BindGrids(string searchTerm)
        {
            string term = searchTerm?.Trim().ToLower() ?? "";

            // فلترة الاشتراكات بناءً على نص البحث (بحث برقم الهاتف، أو اسم العميلة، أو الباقة)
            var filteredSubs = _allSubscriptions.Where(s =>
                string.IsNullOrEmpty(term) ||
                (s.CustomerName != null && s.CustomerName.ToLower().Contains(term)) ||
                (s.Phone != null && s.Phone.ToLower().Contains(term)) ||
                (s.SubscriptionType != null && s.SubscriptionType.ToLower().Contains(term))
            ).ToList();

            // توزيع الاشتراكات المفلترة على الجداول الثلاثة
            dgvActive.DataSource = filteredSubs.Where(s => s.SubscriptionStatus == "ساري" || s.SubscriptionStatus == "حصص قاربت للنفاد" || s.SubscriptionStatus == "قرب الانتهاء").ToList();
            dgvNearExpiry.DataSource = filteredSubs.Where(s => s.SubscriptionStatus == "قرب الانتهاء").ToList();
            dgvExpired.DataSource = filteredSubs.Where(s => s.SubscriptionStatus == "منتهي" || s.SubscriptionStatus == "انتهت الحصص").ToList();

            FormatSubscriptionsGrid(dgvActive);
            FormatSubscriptionsGrid(dgvNearExpiry);
            FormatSubscriptionsGrid(dgvExpired);

            // فلترة الباقات بناءً على نص البحث
            var filteredPkgs = _allPackages.Where(p =>
                string.IsNullOrEmpty(term) ||
                (p.TypeName != null && p.TypeName.ToLower().Contains(term))
            ).ToList();

            dgvPackages.DataSource = filteredPkgs;
            FormatPackagesGrid();
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

        private void DgvPackages_SelectionChanged(object sender, EventArgs e)
        {
            btnEditPackage.Enabled = dgvPackages.CurrentRow != null && dgvPackages.CurrentRow.Selected;
        }

        private async void BtnAddNewPackage_Click(object sender, EventArgs e)
        {
            using (var form = new AddPackageForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
                }
            }
        }

        private async void BtnEditPackage_Click(object sender, EventArgs e)
        {
            if (dgvPackages.CurrentRow != null && dgvPackages.CurrentRow.Selected)
            {
                var package = dgvPackages.CurrentRow.DataBoundItem as GymSubscriptionType;
                if (package != null)
                {
                    using (var form = new EditPackageForm(package))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
                        }
                    }
                }
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
                                await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
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
                    await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
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
                                await LoadAllDataAsync(dtpFrom.Value, dtpTo.Value);
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