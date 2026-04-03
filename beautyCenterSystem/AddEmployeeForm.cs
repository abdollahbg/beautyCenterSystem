using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;

namespace beautyCenterSystem
{
    public partial class AddEmployeeForm : Form
    {
        private readonly EmployeeRepository _employeeRepo;

        public AddEmployeeForm()
        {
            InitializeComponent();
            // تهيئة الريبو
            _employeeRepo = new EmployeeRepository(new DbConnectionFactory());
        }

        private async void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            AppTheme.Apply(this); // تطبيق الثيم
            PnlHeader.BackColor = AppTheme.Primary;
            await LoadRoomsData();
        }

        private async Task LoadRoomsData()
        {
            try
            {
                // جلب قائمة الكائنات من نوع Room
                var rooms = await _employeeRepo.GetRoomsForComboAsync();

                if (rooms != null)
                {
                    var roomsList = rooms.ToList();

                    // ربط البيانات بالـ ComboBox
                    cmbRooms.DataSource = roomsList;
                    cmbRooms.DisplayMember = nameof(Room.RoomName); // نستخدم nameof لتجنب الأخطاء الإملائية
                    cmbRooms.ValueMember = nameof(Room.RoomID);

                    cmbRooms.SelectedIndex = -1; // لإبقاء الاختيار فارغاً عند البدء
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الغرف: {ex.Message}", "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. التحقق من البيانات (Validation)
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم الموظفة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCommissionRate.Text, out decimal rate) || rate < 0 || rate > 100)
            {
                MessageBox.Show("يرجى إدخال نسبة مئوية صحيحة بين 0 و 100.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. تجهيز كائن الموظفة
            var newEmployee = new Employee
            {
                EmployeeName = txtEmployeeName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                CommissionRate = rate,
                RoomID = cmbRooms.SelectedValue != null ? (int)cmbRooms.SelectedValue : (int?)null,
                IsActive = true // افتراضياً تكون نشطة عند الإضافة
            };

            // 3. الحفظ في قاعدة البيانات
            try
            {
                btnSave.Enabled = false; // تعطيل الزر لمنع النقرات المتعددة
                
                // ملاحظة: افترضنا وجود دالة AddEmployeeAsync في الريبو الخاص بك
                bool success = await _employeeRepo.AddEmployeeAsync(newEmployee)>0;

                if (success)
                {
                    MessageBox.Show("تم إضافة الموظفة بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // إغلاق الفورم بنجاح
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل عملية الحفظ، يرجى المحاولة لاحقاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}