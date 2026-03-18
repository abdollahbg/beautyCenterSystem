using BeautyCenterSystem.Data;
using BeautyCenterSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class frmPurchases : Form
    {
        private readonly FinancialRepository _financialRepo;
        private readonly int _currentUserId;
        private List<PurchaseInvoice> _allDayPurchases = new List<PurchaseInvoice>();

        private int _currentInvoiceId = 0;
        private int _currentSafeId = 0;

        public frmPurchases()
        {
            InitializeComponent();
            _financialRepo = new FinancialRepository(new DbConnectionFactory());
            _currentUserId = 1;

            dgvPurchaseDetails.DataError += (s, e) => { e.ThrowException = false; };
            dgvPurchases.DataError += (s, e) => { e.ThrowException = false; };

            dgvPurchaseDetails.CellMouseDown += dgvPurchaseDetails_CellMouseDown;

            numQty.ValueChanged += CalculateCurrentItemTotal;
            numPrice.ValueChanged += CalculateCurrentItemTotal;
        }

        private async void frmPurchases_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            await LoadInitialData();
            await SetupMaterialsColumn();
            await LoadPurchases();

            dtpFilterDate.ValueChanged += async (s, ev) => await LoadPurchases();
        }

        private async Task LoadInitialData()
        {
            try
            {
                var safes = await _financialRepo.GetAllSafesAsync();
                cmbSafes.DataSource = safes.ToList();
                cmbSafes.DisplayMember = "SafeName";
                cmbSafes.ValueMember = "SafeID";

                var materials = await _financialRepo.GetAllMaterialsAsync();
                cmbMaterials.DataSource = materials.ToList();
                cmbMaterials.DisplayMember = "MaterialName";
                cmbMaterials.ValueMember = "MaterialID";
            }
            catch (Exception ex) { MessageBox.Show("خطأ في تحميل البيانات الأساسية: " + ex.Message); }
        }

        // الدالة المعدلة التي تضمن تزامن جدول التفاصيل مع الفاتورة المحددة
        private async Task LoadPurchases()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // 1. إيقاف حدث تغيير التحديد مؤقتاً
                dgvPurchases.SelectionChanged -= dgvPurchases_SelectionChanged;

                // 2. حفظ حالة الفاتورة الحالية وموقع التمرير
                int savedId = _currentInvoiceId;
                int lastScrollIndex = dgvPurchases.Rows.Count > 0 ? dgvPurchases.FirstDisplayedScrollingRowIndex : -1;

                DateTime selectedDate = dtpFilterDate.Value.Date;
                var invoices = await _financialRepo.GetPurchaseInvoicesByDateAsync(selectedDate);
                _allDayPurchases = invoices.ToList();

                // 3. تحديث البيانات
                dgvPurchases.DataSource = null;
                dgvPurchases.DataSource = _allDayPurchases;
                FormatPurchasesGrid();

                // 4. استعادة التحديد بشكل آمن
                if (dgvPurchases.Rows.Count > 0)
                {
                    var firstVisibleCol = dgvPurchases.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Visible);

                    if (firstVisibleCol != null)
                    {
                        bool rowFound = false;

                        if (savedId > 0)
                        {
                            foreach (DataGridViewRow row in dgvPurchases.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["InvoiceID"].Value) == savedId)
                                {
                                    dgvPurchases.CurrentCell = row.Cells[firstVisibleCol.Index];
                                    row.Selected = true;
                                    _currentInvoiceId = savedId; // تثبيت المعرف
                                    rowFound = true;
                                    break;
                                }
                            }
                        }

                        if (!rowFound)
                        {
                            dgvPurchases.CurrentCell = dgvPurchases.Rows[0].Cells[firstVisibleCol.Index];
                            dgvPurchases.Rows[0].Selected = true;
                            _currentInvoiceId = Convert.ToInt32(dgvPurchases.Rows[0].Cells["InvoiceID"].Value);
                        }

                        if (lastScrollIndex >= 0 && lastScrollIndex < dgvPurchases.Rows.Count)
                        {
                            dgvPurchases.FirstDisplayedScrollingRowIndex = lastScrollIndex;
                        }
                    }
                }
                else
                {
                    _currentInvoiceId = 0;
                }

                // 5. الحــــــــل: تحديث جدول التفاصيل يدوياً هنا
                // لأن الحدث معطل، الجدول السفلي لن يعرف أننا اخترنا فاتورة معينة إلا بهذا السطر
                if (_currentInvoiceId > 0)
                {
                    await LoadPurchaseDetails(_currentInvoiceId);
                }
                else
                {
                    dgvPurchaseDetails.DataSource = null;
                }

            }
            catch (Exception ex) { MessageBox.Show($"خطأ في تحميل الفواتير: {ex.Message}"); }
            finally
            {
                // 6. إعادة تفعيل الحدث
                dgvPurchases.SelectionChanged += dgvPurchases_SelectionChanged;
                Cursor = Cursors.Default;
            }
        }

        private async Task LoadPurchaseDetails(int invoiceId)
        {
            try
            {
                var details = await _financialRepo.GetPurchaseDetailsAsync(invoiceId);
                dgvPurchaseDetails.DataSource = null;
                dgvPurchaseDetails.DataSource = details.ToList();
                FormatDetailsGrid();
            }
            catch { dgvPurchaseDetails.DataSource = null; }
        }

        private async void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("يرجى إدخال اسم المورد أولاً.");
                    return;
                }

                _currentSafeId = (int)cmbSafes.SelectedValue;

                var invoice = new PurchaseInvoice
                {
                    SupplierName = txtSupplierName.Text.Trim(),
                    Notes = txtNotes.Text.Trim(),
                    PurchaseDate = DateTime.Now,
                    PaidFromSafeID = _currentSafeId,
                    IssuedBy = _currentUserId,
                    TotalAmount = 0
                };

                _currentInvoiceId = await _financialRepo.CreatePurchaseHeaderAsync(invoice);

                if (_currentInvoiceId > 0)
                {
                    await LoadPurchases();
                    txtSupplierName.Clear();
                    txtNotes.Clear();
                    cmbMaterials.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show($"خطأ: {ex.Message}"); }
        }

        private async void dgvPurchases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow == null) return;

            try
            {
                _currentInvoiceId = Convert.ToInt32(dgvPurchases.CurrentRow.Cells["InvoiceID"].Value);

                if (dgvPurchases.Columns.Contains("PaidFromSafeID") && dgvPurchases.CurrentRow.Cells["PaidFromSafeID"].Value != null)
                {
                    _currentSafeId = Convert.ToInt32(dgvPurchases.CurrentRow.Cells["PaidFromSafeID"].Value);
                    cmbSafes.SelectedValue = _currentSafeId;
                }

                await LoadPurchaseDetails(_currentInvoiceId);
            }
            catch { dgvPurchaseDetails.DataSource = null; }
        }

        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            if (_currentInvoiceId == 0)
            {
                MessageBox.Show("يرجى فتح فاتورة جديدة أو تحديد فاتورة من الجدول.");
                return;
            }

            // --- إضافة هذا الجزء لضمان صحة رقم الخزنة قبل الخصم ---
            if (dgvPurchases.CurrentRow != null)
            {
                _currentSafeId = Convert.ToInt32(dgvPurchases.CurrentRow.Cells["PaidFromSafeID"].Value);
            }
            // ---------------------------------------------------

            if (cmbMaterials.SelectedValue == null || numQty.Value <= 0 || numPrice.Value <= 0)
            {
                MessageBox.Show("يرجى اختيار المادة وتحديد الكمية والسعر.");
                return;
            }

            var detail = new PurchaseDetail
            {
                InvoiceID = _currentInvoiceId,
                MaterialID = (int)cmbMaterials.SelectedValue,
                Quantity = (int)numQty.Value,
                UnitPrice = numPrice.Value
            };

            // نرسل _currentSafeId المتأكدين منه الآن
            bool success = await _financialRepo.AddPurchaseDetailAsync(detail, _currentSafeId);

            if (success)
            {
                await LoadPurchases();
                numQty.Value = 1;
                numPrice.Value = 1;
                cmbMaterials.Focus();
            }
        }

        private async void tsmiDeleteDetail_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseDetails.CurrentRow == null) return;

            int detailId = Convert.ToInt32(dgvPurchaseDetails.CurrentRow.Cells["DetailID"].Value);
            string materialName = dgvPurchaseDetails.CurrentRow.Cells["MaterialName"].Value?.ToString();

            var confirm = MessageBox.Show($"هل أنت متأكد من حذف '{materialName}'؟\nسيتم استرداد المبلغ للخزنة تلقائياً.",
                                         "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = await _financialRepo.DeletePurchaseDetailAsync(detailId);
                    if (isDeleted)
                    {
                        await LoadPurchases(); // سيقوم بتحديث الجدولين معاً
                    }
                }
                catch (Exception ex) { MessageBox.Show($"خطأ أثناء الحذف: {ex.Message}"); }
            }
        }

        private void dgvPurchaseDetails_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPurchaseDetails.ClearSelection();
                dgvPurchaseDetails.Rows[e.RowIndex].Selected = true;
                dgvPurchaseDetails.CurrentCell = dgvPurchaseDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void CalculateCurrentItemTotal(object sender, EventArgs e)
        {
            decimal total = numQty.Value * numPrice.Value;
            lblTotalItem.Text = $"إجمالي الصنف: {total:N2}";
        }

        private void FormatPurchasesGrid()
        {
            foreach (DataGridViewColumn col in dgvPurchases.Columns) col.Visible = false;

            if (dgvPurchases.Columns.Contains("PurchaseDate")) { dgvPurchases.Columns["PurchaseDate"].Visible = true; dgvPurchases.Columns["PurchaseDate"].HeaderText = "التاريخ"; }
            if (dgvPurchases.Columns.Contains("SupplierName")) { dgvPurchases.Columns["SupplierName"].Visible = true; dgvPurchases.Columns["SupplierName"].HeaderText = "المورد"; }
            if (dgvPurchases.Columns.Contains("SafeName")) { dgvPurchases.Columns["SafeName"].Visible = true; dgvPurchases.Columns["SafeName"].HeaderText = "الخزنة"; }
            if (dgvPurchases.Columns.Contains("TotalAmount")) { dgvPurchases.Columns["TotalAmount"].Visible = true; dgvPurchases.Columns["TotalAmount"].HeaderText = "الإجمالي"; dgvPurchases.Columns["TotalAmount"].DefaultCellStyle.Format = "N2"; }
            if (dgvPurchases.Columns.Contains("Notes")) { dgvPurchases.Columns["Notes"].Visible = true; dgvPurchases.Columns["Notes"].HeaderText = "ملاحظات"; dgvPurchases.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }

            dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FormatDetailsGrid()
        {
            foreach (DataGridViewColumn col in dgvPurchaseDetails.Columns) col.Visible = false;

            string[] visibleCols = { "MaterialName", "Quantity", "UnitPrice", "TotalAmount" };
            foreach (var name in visibleCols)
            {
                if (dgvPurchaseDetails.Columns.Contains(name))
                    dgvPurchaseDetails.Columns[name].Visible = true;
            }
        }

        private async Task SetupMaterialsColumn()
        {
            try
            {
                dgvPurchaseDetails.AutoGenerateColumns = false;
                dgvPurchaseDetails.Columns.Clear();

                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DetailID", Name = "DetailID", Visible = false });
                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaterialID", Name = "MaterialID", Visible = false });

                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaterialName",
                    DataPropertyName = "MaterialName",
                    HeaderText = "اسم المادة",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });

                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", Name = "Quantity", HeaderText = "الكمية", ReadOnly = true });
                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", Name = "UnitPrice", HeaderText = "السعر", DefaultCellStyle = { Format = "N2" }, ReadOnly = true });

                dgvPurchaseDetails.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    Name = "TotalAmount",
                    HeaderText = "الإجمالي",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "N2" }
                });
            }
            catch (Exception ex) { MessageBox.Show("خطأ في إعداد أعمدة الجدول: " + ex.Message); }
        }

        private async void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            await LoadPurchases();
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            ApplyPurchasesFilter();
        }

        private void ApplyPurchasesFilter()
        {
            try
            {
                string searchText = txtSearchSupplier.Text.Trim().ToLower();

                var filteredList = _allDayPurchases
                    .Where(p => string.IsNullOrEmpty(searchText) ||
                                (p.SupplierName != null && p.SupplierName.ToLower().Contains(searchText)))
                    .ToList();

                dgvPurchases.SelectionChanged -= dgvPurchases_SelectionChanged;
                dgvPurchases.DataSource = null;
                dgvPurchases.DataSource = filteredList;
                FormatPurchasesGrid();

                // بعد الفلترة، يفضل تحديث تفاصيل أول فاتورة تظهر في الفلترة
                if (dgvPurchases.Rows.Count > 0)
                {
                    _currentInvoiceId = Convert.ToInt32(dgvPurchases.Rows[0].Cells["InvoiceID"].Value);
                    LoadPurchaseDetails(_currentInvoiceId);
                }

                dgvPurchases.SelectionChanged += dgvPurchases_SelectionChanged;
            }
            catch (Exception ex) { MessageBox.Show("خطأ أثناء الفلترة: " + ex.Message); }
        }
    }
}