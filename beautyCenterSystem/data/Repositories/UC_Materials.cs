using beautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beautyCenterSystem.data.Repositories
{
    public partial class UC_Materials : UserControl
    {
        private readonly MaterialRepository _materialRepo;
        private List<Material> _allMaterials = new List<Material>();

        public UC_Materials()
        {
            InitializeComponent();
            _materialRepo = new MaterialRepository(new DbConnectionFactory());
        }

        private async Task LoadMaterials()
        {
            try
            {
                // جلب المواد (تأكد أن GetAllAsync في الـ Repository تجلب كل الحقول الجديدة)
                var materials = await _materialRepo.GetAllAsync();
                _allMaterials = materials.ToList();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل قائمة المواد: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_allMaterials == null) return;

            string searchText = txtboxSearch.Text.Trim().ToLower();

            dgvMaterials.CellValueChanged -= dgvMaterials_CellValueChanged;

            if (string.IsNullOrEmpty(searchText))
            {
                dgvMaterials.DataSource = new BindingList<Material>(_allMaterials);
            }
            else
            {
                var filtered = _allMaterials.Where(m => m.MaterialName.ToLower().Contains(searchText)).ToList();
                dgvMaterials.DataSource = new BindingList<Material>(filtered);
            }

            FormatGrid();

            dgvMaterials.CellValueChanged += dgvMaterials_CellValueChanged;
        }

        private void FormatGrid()
        {
            if (dgvMaterials.Columns.Count > 0)
            {
                // إخفاء المعرفات والأعمدة المنطقية التي لا يحتاجها المستخدم العادي في الجدول
                if (dgvMaterials.Columns.Contains("MaterialID")) dgvMaterials.Columns["MaterialID"].Visible = false;
                if (dgvMaterials.Columns.Contains("IsActive")) dgvMaterials.Columns["IsActive"].Visible = false;
                if (dgvMaterials.Columns.Contains("IsCaffeteriaItem")) dgvMaterials.Columns["IsCaffeteriaItem"].Visible = false;

                // تنسيق اسم المادة
                if (dgvMaterials.Columns.Contains("MaterialName"))
                {
                    dgvMaterials.Columns["MaterialName"].HeaderText = "اسم المادة / الصنف";
                    dgvMaterials.Columns["MaterialName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // تنسيق سعر البيع (SalePrice)
                if (dgvMaterials.Columns.Contains("SalePrice"))
                {
                    dgvMaterials.Columns["SalePrice"].HeaderText = "سعر البيع";
                    dgvMaterials.Columns["SalePrice"].DefaultCellStyle.Format = "N2";
                    dgvMaterials.Columns["SalePrice"].Width = 100;
                }

                // تنسيق كمية المخزن (StockQuantity)
                if (dgvMaterials.Columns.Contains("StockQuantity"))
                {
                    dgvMaterials.Columns["StockQuantity"].HeaderText = "الكمية المتوفرة";
                    dgvMaterials.Columns["StockQuantity"].Width = 100;
                }

                // تحويل IsAvailable إلى ComboBox
                if (dgvMaterials.Columns.Contains("IsAvailable") && !(dgvMaterials.Columns["IsAvailable"] is DataGridViewComboBoxColumn))
                {
                    int columnIndex = dgvMaterials.Columns["IsAvailable"].Index;
                    dgvMaterials.Columns.Remove("IsAvailable");

                    DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn
                    {
                        Name = "IsAvailable",
                        HeaderText = "الحالة",
                        DataPropertyName = "IsAvailable",
                        DataSource = new[]
                        {
                            new { Text = "متوفر", Value = true },
                            new { Text = "غير متوفر", Value = false }
                        },
                        DisplayMember = "Text",
                        ValueMember = "Value",
                        FlatStyle = FlatStyle.Flat
                    };
                    dgvMaterials.Columns.Insert(columnIndex, comboCol);
                }
            }
            dgvMaterials.ReadOnly = false;
        }

        private async void dgvMaterials_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMaterials.Rows[e.RowIndex];
                if (row.Cells["MaterialID"].Value == null) return;

                // التعديل هنا ليتوافق مع أسماء خصائص الموديل
                var material = new Material
                {
                    MaterialID = (int)row.Cells["MaterialID"].Value,
                    MaterialName = row.Cells["MaterialName"].Value?.ToString() ?? "",
                    SalePrice = Convert.ToDecimal(row.Cells["SalePrice"].Value ?? 0),
                    StockQuantity = Convert.ToInt32(row.Cells["StockQuantity"].Value ?? 0),
                    IsAvailable = row.Cells["IsAvailable"].Value != null && (bool)row.Cells["IsAvailable"].Value,
                    IsActive = true, // نفترض أنها نشطة طالما تظهر في الجدول
                    IsCaffeteriaItem = true // أو جلب القيمة الأصلية من القائمة المحلية
                };

                try
                {
                    await _materialRepo.UpdateAsync(material);

                    // تحديث الكائن في الذاكرة
                    var localItem = _allMaterials.FirstOrDefault(m => m.MaterialID == material.MaterialID);
                    if (localItem != null)
                    {
                        localItem.MaterialName = material.MaterialName;
                        localItem.SalePrice = material.SalePrice;
                        localItem.StockQuantity = material.StockQuantity;
                        localItem.IsAvailable = material.IsAvailable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"فشل التحديث: {ex.Message}");
                }
            }
        }

        private void dgvMaterials_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMaterials.IsCurrentCellDirty)
            {
                dgvMaterials.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private async void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null) return;

            int id = (int)dgvMaterials.CurrentRow.Cells["MaterialID"].Value;
            string name = dgvMaterials.CurrentRow.Cells["MaterialName"].Value.ToString();

            if (MessageBox.Show($"حذف {name}؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _materialRepo.DeleteAsync(id))
                {
                    await LoadMaterials();
                }
            }
        }

        private async void UC_Materials_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            await LoadMaterials();
        }

        private async void btnAddMaterials_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddMaterialForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadMaterials();
                }
            }
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}