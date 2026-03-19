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
                var materials = await _materialRepo.GetAllAsync();
                _allMaterials = materials.ToList();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل قائمة المواد: {ex.Message}", "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_allMaterials == null) return;

            string searchText = txtboxSearch.Text.Trim().ToLower();

            // فك الارتباط مؤقتاً لتجنب إطلاق أحداث التغيير أثناء التحميل
            dgvMaterials.CellValueChanged -= dgvMaterials_CellValueChanged;

            if (string.IsNullOrEmpty(searchText))
            {
                dgvMaterials.DataSource = _allMaterials;
            }
            else
            {
                var filtered = _allMaterials.Where(m => m.MaterialName.ToLower().Contains(searchText)).ToList();
                dgvMaterials.DataSource = filtered;
            }

            FormatGrid();

            // إعادة ربط الحدث بعد انتهاء التحميل
            dgvMaterials.CellValueChanged += dgvMaterials_CellValueChanged;
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void FormatGrid()
        {
            if (dgvMaterials.Columns.Count > 0)
            {
                // 1. إخفاء المعرف
                if (dgvMaterials.Columns.Contains("MaterialID"))
                    dgvMaterials.Columns["MaterialID"].Visible = false;

                // 2. تنسيق اسم المادة
                if (dgvMaterials.Columns.Contains("MaterialName"))
                {
                    dgvMaterials.Columns["MaterialName"].HeaderText = "اسم العنصر / المادة";
                    dgvMaterials.Columns["MaterialName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvMaterials.Columns["MaterialName"].ReadOnly = false;
                }

                // 3. تحويل عمود الحالة إلى ComboBox إذا لم يكن كذلك
                if (dgvMaterials.Columns.Contains("IsAvailable") && !(dgvMaterials.Columns["IsAvailable"] is DataGridViewComboBoxColumn))
                {
                    int columnIndex = dgvMaterials.Columns["IsAvailable"].Index;
                    dgvMaterials.Columns.Remove("IsAvailable");

                    DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn
                    {
                        Name = "IsAvailable",
                        HeaderText = "الحالة (متوفر؟)",
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

        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMaterials.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                dgvMaterials.BeginEdit(true);
                if (dgvMaterials.EditingControl is ComboBox comboBox)
                {
                    comboBox.DroppedDown = true;
                }
            }
        }

        private async void dgvMaterials_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMaterials.Rows[e.RowIndex];

                // التحقق من وجود البيانات
                if (row.Cells["MaterialID"].Value == null) return;

                var material = new Material
                {
                    MaterialID = (int)row.Cells["MaterialID"].Value,
                    MaterialName = row.Cells["MaterialName"].Value?.ToString() ?? "",
                    IsAvailable = row.Cells["IsAvailable"].Value != null && (bool)row.Cells["IsAvailable"].Value
                };

                try
                {
                    // تحديث قاعدة البيانات فقط دون إعادة تحميل الجدول بالكامل 
                    // لضمان استمرار وضع التعديل وسلاسة الكتابة
                    await _materialRepo.UpdateAsync(material);

                    // تحديث الكائن في القائمة المحلية أيضاً ليبقى البحث دقيقاً
                    var localItem = _allMaterials.FirstOrDefault(m => m.MaterialID == material.MaterialID);
                    if (localItem != null)
                    {
                        localItem.MaterialName = material.MaterialName;
                        localItem.IsAvailable = material.IsAvailable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}");
                }
            }
        }

        private void dgvMaterials_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // هذا السطر يضمن حفظ التغييرات فور اختيار قيمة من الـ ComboBox
            if (dgvMaterials.IsCurrentCellDirty && dgvMaterials.CurrentCell is DataGridViewComboBoxCell)
            {
                dgvMaterials.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private async void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار العنصر المراد حذفه.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int materialId = (int)dgvMaterials.CurrentRow.Cells["MaterialID"].Value;
            string materialName = dgvMaterials.CurrentRow.Cells["MaterialName"].Value.ToString();

            var confirm = MessageBox.Show($"هل أنت متأكد من حذف ({materialName})؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (await _materialRepo.DeleteAsync(materialId))
                {
                    await LoadMaterials();
                    MessageBox.Show("تم الحذف بنجاح.");
                }
            }
        }

        private void dgvMaterials_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvMaterials.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvMaterials.ClearSelection();
                    dgvMaterials.Rows[hit.RowIndex].Selected = true;

                    // الحل لمشكلة الخلية المخفية: البحث عن أول عمود مرئي
                    var firstVisibleCol = dgvMaterials.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
                    if (firstVisibleCol != null)
                    {
                        dgvMaterials.CurrentCell = dgvMaterials.Rows[hit.RowIndex].Cells[firstVisibleCol.Index];
                    }
                }
            }
        }

        private async void UC_Materials_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this);
            await LoadMaterials(); // جلب البيانات عند التحميل

            this.BeginInvoke((MethodInvoker)delegate
            {
                btnAddMaterials.FlatStyle = FlatStyle.Flat;
                btnAddMaterials.FlatAppearance.BorderSize = 1;
                btnAddMaterials.FlatAppearance.BorderColor = AppTheme.Charcoal;
                btnAddMaterials.BackColor = Color.White;
            });
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
    }
}