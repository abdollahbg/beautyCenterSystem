using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeautyCenterSystem.Models;
using beautyCenterSystem.viewsmodels;

namespace beautyCenterSystem
{
    public partial class UC_CartSummary : UserControl
    {
        public event EventHandler OnAddCustomerClicked;
        public event EventHandler OnSaveAppointmentClicked;
        public event EventHandler<int> OnRemoveServiceRequested;
        public event Action<int, int> OnQuantityChanged;

        private decimal _currentTotal = 0;
        private bool _isRefreshing = false;

        public string SaveButtonText
        {
            get => btnSave.Text;
            set => btnSave.Text = value;
        }

        public string ItemColumnHeaderText
        {
            get => NameCol.HeaderText;
            set => NameCol.HeaderText = value;
        }

        public UC_CartSummary()
        {
            InitializeComponent();
            SetupCustomEvents();
        }

        private void SetupCustomEvents()
        {
            btnAddCustomer.Click += (s, e) => OnAddCustomerClicked?.Invoke(this, e);

            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(200, 20, 60);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(230, 25, 70);

            btnSave.Click += (s, e) =>
            {
                dgvCart.EndEdit();
                OnSaveAppointmentClicked?.Invoke(this, e);
            };

            dgvCart.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "DeleteCol")
                {
                    var val = dgvCart.Rows[e.RowIndex].Cells["IDCol"].Value;
                    if (val != null) OnRemoveServiceRequested?.Invoke(this, (int)val);
                }
            };

            dgvCart.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvCart.IsCurrentCellDirty)
                {
                    dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            dgvCart.EditingControlShowing += (s, e) =>
            {
                if (dgvCart.CurrentCell.OwningColumn.Name == "QuantityCol")
                {
                    TextBox txt = e.Control as TextBox;
                    if (txt != null)
                    {
                        txt.KeyPress -= Quantity_KeyPress;
                        txt.KeyPress += Quantity_KeyPress;
                    }
                }
            };

            dgvCart.KeyDown += (s, e) =>
            {
                if (dgvCart.CurrentCell != null && dgvCart.CurrentCell.OwningColumn.Name == "QuantityCol")
                {
                    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    {
                        UpdateQuantityByArrow(e.KeyCode);
                        e.Handled = true;
                    }
                }
            };

            dgvCart.CellValueChanged += (s, e) =>
            {
                if (_isRefreshing) return;

                if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "QuantityCol")
                {
                    // تحديث إجمالي السطر والإجمالي الكلي بصرياً فوراً
                    UpdateVisualTotals();

                    var idVal = dgvCart.Rows[e.RowIndex].Cells["IDCol"].Value;
                    var qtyVal = dgvCart.Rows[e.RowIndex].Cells["QuantityCol"].Value;

                    if (idVal != null && int.TryParse(qtyVal?.ToString(), out int newQty))
                    {
                        if (newQty < 1) newQty = 1;
                        OnQuantityChanged?.Invoke((int)idVal, newQty);
                    }
                }
            };
        }

        // دالة لتحديث الإجماليات بصرياً دون إعادة بناء الجدول
        public void UpdateVisualTotals()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (decimal.TryParse(row.Cells["PriceCol"].Value?.ToString(), out decimal price) &&
                    int.TryParse(row.Cells["QuantityCol"].Value?.ToString(), out int qty))
                {
                    decimal lineTotal = price * qty;
                    row.Cells["LineTotalCol"].Value = lineTotal.ToString("N2");
                    total += lineTotal;
                }
            }
            _currentTotal = total;
            lblTotalPrice.Text = $"{_currentTotal:N2} د.ل";
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void UpdateQuantityByArrow(Keys key)
        {
            var cell = dgvCart.CurrentCell;
            if (cell == null || cell.ReadOnly) return;

            if (int.TryParse(cell.Value?.ToString(), out int currentQty))
            {
                int newQty = (key == Keys.Up) ? currentQty + 1 : currentQty - 1;
                if (newQty >= 1) cell.Value = newQty;
            }
        }

        public void RefreshCart(List<AppointmentDetailDto> items)
        {
            _isRefreshing = true;
            dgvCart.Rows.Clear();
            _currentTotal = 0;

            if (items != null)
            {
                foreach (var item in items)
                {
                    decimal lineTotal = item.Price * item.Quantity;
                    bool isMaterial = item.MaterialID.HasValue && item.MaterialID.Value > 0;
                    int itemId = item.ServiceID ?? item.MaterialID ?? 0;

                    int rowIndex = dgvCart.Rows.Add();
                    DataGridViewRow row = dgvCart.Rows[rowIndex];

                    row.Cells["IDCol"].Value = itemId;
                    row.Cells["NameCol"].Value = item.Name;
                    row.Cells["PriceCol"].Value = item.Price.ToString("N2");
                    row.Cells["QuantityCol"].Value = item.Quantity;
                    row.Cells["LineTotalCol"].Value = lineTotal.ToString("N2");
                    row.Cells["TypeCol"].Value = isMaterial ? "Material" : "Service";

                    row.Cells["QuantityCol"].ReadOnly = !isMaterial;
                    if (!isMaterial) row.Cells["QuantityCol"].Style.ForeColor = Color.Gray;

                    _currentTotal += lineTotal;
                }
            }
            lblTotalPrice.Text = $"{_currentTotal:N2} د.ل";
            _isRefreshing = false;
        }

        public void FillCustomers(object dataSource)
        {
            cmbCustomers.DataSource = dataSource;
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.ValueMember = "CustomerID";
            cmbCustomers.SelectedIndex = -1;
        }

        public int? SelectedCustomerId
        {
            get => cmbCustomers.SelectedValue as int?;
            set => cmbCustomers.SelectedValue = value;
        }

        public decimal TotalAmount => _currentTotal;
    }
}