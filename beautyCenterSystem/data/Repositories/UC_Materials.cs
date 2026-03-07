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

        // متغير للاحتفاظ بكل المواد في الذاكرة لعملية البحث السريع
        private List<Material> _allMaterials = new List<Material>();

        public UC_Materials()
        {
            InitializeComponent();
            _materialRepo = new MaterialRepository(new DbConnectionFactory());
            LoadMaterials();
        }

        private async Task LoadMaterials()
        {
            try
            {
                // 1. جلب القائمة من المستودع
                var materials = await _materialRepo.GetAllAsync();

                // 2. تخزينها في المتغير العام للبحث
                _allMaterials = materials.ToList();

                // 3. تطبيق البحث (إذا كان هناك نص مكتوب) أو عرض الكل
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل قائمة المواد: {ex.Message}", "خطأ قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة الفلترة (البحث)
        private void ApplyFilter()
        {
            if (_allMaterials == null) return;

            string searchText = txtboxSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dgvMaterials.DataSource = _allMaterials;
            }
            else
            {
                // فلترة المواد التي يحتوي اسمها على النص المكتوب
                var filtered = _allMaterials.Where(m => m.MaterialName.ToLower().Contains(searchText)).ToList();
                dgvMaterials.DataSource = filtered;
            }

            // تطبيق التنسيقات بعد كل فلترة
            FormatGrid();
        }

        // حدث الكتابة في مربع البحث
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void FormatGrid()
        {
            if (dgvMaterials.Columns.Count > 0)
            {
                if (dgvMaterials.Columns.Contains("MaterialID"))
                    dgvMaterials.Columns["MaterialID"].Visible = false;

                if (dgvMaterials.Columns.Contains("MaterialName"))
                {
                    dgvMaterials.Columns["MaterialName"].HeaderText = "اسم العنصر / المادة";
                    dgvMaterials.Columns["MaterialName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvMaterials.Columns.Contains("IsAvailable") && !(dgvMaterials.Columns["IsAvailable"] is DataGridViewComboBoxColumn))
                {
                    int columnIndex = dgvMaterials.Columns["IsAvailable"].Index;
                    dgvMaterials.Columns.Remove("IsAvailable");

                    DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                    comboCol.Name = "IsAvailable";
                    comboCol.HeaderText = "الحالة (متوفر؟)";
                    comboCol.DataPropertyName = "IsAvailable";

                    comboCol.DataSource = new[]
                    {
                        new { Text = "متوفر", Value = true },
                        new { Text = "غير متوفر", Value = false }
                    };
                    comboCol.DisplayMember = "Text";
                    comboCol.ValueMember = "Value";

                    dgvMaterials.Columns.Insert(columnIndex, comboCol);
                }
            }

            dgvMaterials.ReadOnly = false;

            if (dgvMaterials.Columns.Contains("MaterialName"))
                dgvMaterials.Columns["MaterialName"].ReadOnly = false;
        }

        // حدث الضغط على الخلية (لفتح الكومبو بوكس من أول ضغطة)
        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // التحقق من أن الخلية المضغوطة هي خلية الكومبو بوكس
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

                var material = new Material
                {
                    MaterialID = (int)row.Cells["MaterialID"].Value,
                    MaterialName = row.Cells["MaterialName"].Value.ToString(),
                    IsAvailable = (bool)row.Cells["IsAvailable"].Value
                };

                try
                {
                    bool success = await _materialRepo.UpdateAsync(material);
                    // إعادة التحميل لضمان تطابق البيانات
                    await LoadMaterials();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء التحديث: {ex.Message}");
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private async void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null || dgvMaterials.CurrentRow.Index < 0)
            {
                MessageBox.Show("يرجى اختيار العنصر المراد حذفه من الجدول أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int materialId = (int)dgvMaterials.CurrentRow.Cells["MaterialID"].Value;
            string materialName = dgvMaterials.CurrentRow.Cells["MaterialName"].Value.ToString();

            var confirmResult = MessageBox.Show($"هل أنت متأكد من حذف العنصر: ({materialName}) نهائياً؟",
                                                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = await _materialRepo.DeleteAsync(materialId);

                    if (isDeleted)
                    {
                        await LoadMaterials();
                        MessageBox.Show("تم الحذف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"تعذر الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvMaterials.CurrentCell = dgvMaterials.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void UC_Materials_Load(object sender, EventArgs e)
        {
            FormatGrid();
            AppTheme.Apply(this);
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
                    try
                    {
                        await LoadMaterials();
                        MessageBox.Show("تم تحديث القائمة بنجاح.", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"حدث خطأ أثناء تحديث الجدول: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}