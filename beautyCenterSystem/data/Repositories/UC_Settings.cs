using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using beautyCenterSystem.data.Repositories;
using BeautyCenterSystem.Models;
using BeautyCenterSystem.Data;

namespace beautyCenterSystem.data.Repositories
{
    public partial class UC_Settings : UserControl
    {
        // تعريف الريبو داخلياً
        private readonly SettingsRepository _repo = new SettingsRepository(new DbConnectionFactory());
        private CenterSettings _currentSettings = new CenterSettings();
        private bool _isDataChanged = false;

        public UC_Settings()
        {
            AppTheme.Apply(this);
            InitializeComponent();

            ApplyCustomStyles();

            AttachChangeTracking();
        }

        private void ApplyCustomStyles()
        {
            // إعدادات picLogo (IconPictureBox)
            this.picLogo.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.picLogo.IconColor = Color.Gray;
            this.picLogo.IconSize = 100;
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = Color.FromArgb(240, 240, 240);
            this.picLogo.BorderStyle = BorderStyle.FixedSingle;

            // إعدادات btnBrowse (أزرق مخصص)
            this.btnBrowse.BackColor = Color.FromArgb(0, 120, 215);
            this.btnBrowse.FlatStyle = FlatStyle.Flat;
            this.btnBrowse.ForeColor = Color.White;
            this.btnBrowse.UseVisualStyleBackColor = false;

            // إعدادات btnDelete (أحمر مخصص)
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;

        }

        private async void UC_Settings_Load(object sender, EventArgs e)
        {
            await LoadSettings();
        }

        private async Task LoadSettings()
        {
            try
            {
                _currentSettings = await _repo.GetSettingsAsync();

                if (_currentSettings != null)
                {
                    txtCenterName.Text = _currentSettings.CenterName;
                    txtPhone.Text = _currentSettings.Phone;
                    txtWhatsApp.Text = _currentSettings.WhatsApp;
                    txtFacebook.Text = _currentSettings.Facebook;
                    txtInstagram.Text = _currentSettings.Instagram;
                    txtInvoiceNote.Text = _currentSettings.Note;

                    if (_currentSettings.LogoBytes != null && _currentSettings.LogoBytes.Length > 0)
                    {
                        picLogo.Image = ByteArrayToImage(_currentSettings.LogoBytes);
                    }
                }
                _isDataChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الإعدادات: {ex.Message}");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picLogo.Image = Image.FromFile(ofd.FileName);
                    _isDataChanged = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (picLogo.Image != null || picLogo.IconChar != FontAwesome.Sharp.IconChar.Image)
            {
                picLogo.Image = null;
                picLogo.IconChar = FontAwesome.Sharp.IconChar.Image;
                _isDataChanged = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveData();
        }

        private async Task SaveData()
        {
            _currentSettings.CenterName = txtCenterName.Text;
            _currentSettings.Phone = txtPhone.Text;
            _currentSettings.WhatsApp = txtWhatsApp.Text;
            _currentSettings.Facebook = txtFacebook.Text;
            _currentSettings.Instagram = txtInstagram.Text;
            _currentSettings.Note = txtInvoiceNote.Text;
            _currentSettings.LogoBytes = picLogo.Image != null ? ImageToByteArray(picLogo.Image) : null;

            await _repo.SaveSettingsAsync(_currentSettings);
            _isDataChanged = false;
            MessageBox.Show("تم حفظ الإعدادات بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // دالة التحقق عند الخروج (يتم استدعاؤها من الفورم الرئيسي)
        public async Task<bool> PromptUnsavedChanges()
        {
            if (_isDataChanged)
            {
                var result = MessageBox.Show("هناك تغييرات لم يتم حفظها، هل تريد الحفظ الآن؟", "تنبيه",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await SaveData();
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return true; // خروج بدون حفظ
                }
                else
                {
                    return false; // إلغاء الخروج
                }
            }
            return true;
        }

        private void AttachChangeTracking()
        {
            txtCenterName.TextChanged += (s, e) => _isDataChanged = true;
            txtPhone.TextChanged += (s, e) => _isDataChanged = true;
            txtWhatsApp.TextChanged += (s, e) => _isDataChanged = true;
            txtFacebook.TextChanged += (s, e) => _isDataChanged = true;
            txtInstagram.TextChanged += (s, e) => _isDataChanged = true;
            txtInvoiceNote.TextChanged += (s, e) => _isDataChanged = true;
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}