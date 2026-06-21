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
using beautyCenterSystem.Properties; // هذا السطر ضروري جداً للتعرف على ملف الإعدادات

namespace beautyCenterSystem.data.Repositories
{
    public partial class UC_Settings : UserControl
    {
        // 1. التعريفات الأساسية
        private readonly SettingsRepository _settingsRepo = new SettingsRepository(new DbConnectionFactory());
        private readonly UserRepository _userRepo = new UserRepository(new DbConnectionFactory());
        private readonly BackupRepository _backupRepo = new BackupRepository(new DbConnectionFactory());

        private CenterSettings _currentSettings = new CenterSettings();
        private bool _isDataChanged = false;

        public UC_Settings()
        {
            InitializeComponent();

            // تطبيق الثيم (إذا كان متوفراً)
            if (typeof(AppTheme) != null) AppTheme.Apply(this);

            ApplyCustomStyles();
            AttachChangeTracking();
            SetupEvents();
            ApplyPermission();
        }

        private void ApplyPermission()
        {
           

            // 1. التحقق من صلاحية "هوية المركز"
            if (!PermissionManager.Can("AccessCenterIdentity"))
            {
                tabControl1.TabPages.Remove(tbCenterIdentity);
            }

            // 2. التحقق من صلاحية "المستخدمين"
            if (!PermissionManager.Can("AccessUsersPermissions")) // تأكد من اسم الصلاحية في قاعدة بياناتك
            {
                tabControl1.TabPages.Remove(tbUsersPermissions);
            }

            // 3. التحقق من صلاحية "النسخ الاحتياطي"
            if (!PermissionManager.Can("AccessBackup"))
            {
                tabControl1.TabPages.Remove(tbBackup);
            }
        }

        // 2. تنسيق الواجهة
        private void ApplyCustomStyles()
        {
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = Color.FromArgb(240, 240, 240);
            this.picLogo.BorderStyle = BorderStyle.FixedSingle;

            StyleButton(btnBrowse, Color.FromArgb(0, 120, 215));
            StyleButton(btnDelete, Color.FromArgb(220, 53, 69));
            StyleButton(btnSaveSettings, Color.FromArgb(40, 167, 69));

            // أزرار النسخ الاحتياطي
            StyleButton(btnTakeBackup, Color.FromArgb(255, 152, 0));
            StyleButton(btnRestore, Color.FromArgb(183, 28, 28));
            StyleButton(btnSaveBackupSettings, Color.FromArgb(40, 167, 69));

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvUsers.Columns["UserID"] != null) dgvUsers.Columns["UserID"].DataPropertyName = "UserID";
            if (dgvUsers.Columns["Username"] != null) dgvUsers.Columns["Username"].DataPropertyName = "Username";
            if (dgvUsers.Columns["RoleName"] != null) dgvUsers.Columns["RoleName"].DataPropertyName = "RoleName";
            clbPermissions.CheckOnClick = true;
        }

        private void StyleButton(Button btn, Color color)
        {
            if (btn == null) return;
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        private void SetupEvents()
        {
            this.Load += UC_Settings_Load;

            // أحداث النسخ الاحتياطي
            btnTakeBackup.Click += btnTakeBackup_Click;
            btnRestore.Click += btnRestore_Click;
            btnBrowseAutoBackup.Click += btnBrowseAutoBackup_Click;
            btnSaveBackupSettings.Click += btnSaveBackupSettings_Click;
        }

        // 3. تحميل البيانات (Load)
        private async void UC_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadCenterSettings();
                await LoadUsersGrid();
                await LoadAllPermissionsList();
                await LoadRolesCombo();

                // تحميل إعدادات النسخ الاحتياطي من ملف Properties
                chkEnableAutoBackup.Checked = Settings.Default.EnableAutoBackup;
                txtAutoBackupPath.Text = Settings.Default.AutoBackupPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}");
            }
        }

        private async Task LoadCenterSettings()
        {
            _currentSettings = await _settingsRepo.GetSettingsAsync();
            if (_currentSettings != null)
            {
                txtCenterName.Text = _currentSettings.CenterName;
                txtPhone.Text = _currentSettings.Phone;
                txtWhatsApp.Text = _currentSettings.WhatsApp;
                txtFacebook.Text = _currentSettings.Facebook;
                txtInstagram.Text = _currentSettings.Instagram;
                txtInvoiceNote.Text = _currentSettings.Note;

                if (_currentSettings.LogoBytes != null && _currentSettings.LogoBytes.Length > 0)
                    picLogo.Image = ByteArrayToImage(_currentSettings.LogoBytes);
            }
            _isDataChanged = false;
        }

        // 4. منطق هوية المركز
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picLogo.Image = Image.FromFile(ofd.FileName);
                    _isDataChanged = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
            _isDataChanged = true;
        }

        private async void btnSaveSettings_Click(object sender, EventArgs e)
        {
            await SaveCenterDataInternal();
            MessageBox.Show("تم حفظ إعدادات الهوية بنجاح", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- 5. منطق النسخ الاحتياطي المضاف ---

        private async void btnTakeBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "اختر مكان حفظ النسخة الاحتياطية" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnTakeBackup.Enabled = false;
                        string fullPath = await _backupRepo.CreateBackupAsync(fbd.SelectedPath);
                        MessageBox.Show($"تم إنشاء النسخة بنجاح:\n{fullPath}", "النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"فشل النسخ الاحتياطي: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { btnTakeBackup.Enabled = true; }
                }
            }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("تحذير: استعادة البيانات ستحذف البيانات الحالية. هل تريد المتابعة؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Backup Files (*.bak)|*.bak" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            btnRestore.Enabled = false;
                            bool success = await _backupRepo.RestoreDatabaseAsync(ofd.FileName);
                            if (success)
                            {
                                MessageBox.Show("تمت استعادة البيانات بنجاح، سيتم تحديث الصفحة.", "نجاح");
                                await LoadCenterSettings();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"فشل الاستعادة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally { btnRestore.Enabled = true; }
                    }
                }
            }
        }

        private void btnBrowseAutoBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK) txtAutoBackupPath.Text = fbd.SelectedPath;
            }
        }

        private void btnSaveBackupSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.EnableAutoBackup = chkEnableAutoBackup.Checked;
            Settings.Default.AutoBackupPath = txtAutoBackupPath.Text;
            Settings.Default.Save();
            MessageBox.Show("تم حفظ إعدادات النسخ الاحتياطي", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 6. إدارة المستخدمين
        private async Task LoadUsersGrid()
        {
            try
            {
                var usersList = await _userRepo.GetAllUsersWithRolesAsync();
                var dataSource = usersList.ToList();

                dgvUsers.DataSource = null;
                dgvUsers.Columns.Clear();
                dgvUsers.AutoGenerateColumns = false;

                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserID", DataPropertyName = "UserID", HeaderText = "ID", Visible = false });
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "RoleID", DataPropertyName = "RoleID", HeaderText = "RoleID", Visible = false });
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "اسم المستخدم", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "RoleName", DataPropertyName = "RoleName", HeaderText = "الصلاحية", Width = 120 });
                dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { Name = "IsActive", DataPropertyName = "IsActive", HeaderText = "نشط", Width = 60 });

                dgvUsers.DataSource = dataSource;
            }
            catch (Exception ex) { MessageBox.Show($"خطأ في تحميل الجدول: {ex.Message}"); }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var frm = new UserCreateForm())
            {
                if (frm.ShowDialog() == DialogResult.OK) _ = LoadUsersGrid();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            int roleId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["RoleID"].Value);

            using (var frm = new UserEditForm(userId, username, roleId))
            {
                if (frm.ShowDialog() == DialogResult.OK) _ = LoadUsersGrid();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int targetUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            int currentAdminId = CurrentSession.UserID;

            using (var frm = new DeleteUserModal(targetUserId, currentAdminId))
            {
                if (frm.ShowDialog() == DialogResult.OK) _ = LoadUsersGrid();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            string name = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();

            using (var frm = new PasswordResetForm(userId, name)) { frm.ShowDialog(); }
        }

        // 7. إدارة الأدوار والصلاحيات
        private async Task LoadRolesCombo()
        {
            cbRoles.SelectedIndexChanged -= cbRoles_SelectedIndexChanged;
            var roles = await _userRepo.GetAllRolesAsync();
            cbRoles.DataSource = roles.ToList();
            cbRoles.DisplayMember = "RoleName";
            cbRoles.ValueMember = "RoleID";
            cbRoles.SelectedIndexChanged += cbRoles_SelectedIndexChanged;
            if (cbRoles.Items.Count > 0) cbRoles_SelectedIndexChanged(null, null);
        }

        private async Task LoadAllPermissionsList()
        {
            clbPermissions.Items.Clear();
            var permissions = await _userRepo.GetAllPermissionsAsync();
            if (permissions != null && permissions.Any())
            {
                clbPermissions.DisplayMember = "PermissionName";
                clbPermissions.ValueMember = "PermissionID";
                foreach (var perm in permissions) clbPermissions.Items.Add(perm);
            }
        }

        private async void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoles.SelectedValue is int roleId && clbPermissions.Items.Count > 0)
            {
                clbPermissions.BeginUpdate();
                for (int i = 0; i < clbPermissions.Items.Count; i++) clbPermissions.SetItemChecked(i, false);
                var rolePermIds = await _userRepo.GetRolePermissionIdsAsync(roleId);
                for (int i = 0; i < clbPermissions.Items.Count; i++)
                {
                    var permission = (Permission)clbPermissions.Items[i];
                    if (rolePermIds.Contains(permission.PermissionID)) clbPermissions.SetItemChecked(i, true);
                }
                clbPermissions.EndUpdate();
            }
        }

        private async void btnSavePermissions_Click(object sender, EventArgs e)
        {
            if (cbRoles.SelectedValue is int roleId)
            {
                var selectedIds = new List<int>();
                foreach (var item in clbPermissions.CheckedItems) selectedIds.Add(((Permission)item).PermissionID);
                bool success = await _userRepo.UpdateRolePermissionsAsync(roleId, selectedIds);
                if (success) MessageBox.Show("تم تحديث صلاحيات الدور بنجاح", "نجاح");
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            using (var frm = new RoleCreateForm())
            {
                if (frm.ShowDialog() == DialogResult.OK) _ = LoadRolesCombo();
            }
        }

        // 8. وظائف المساعدة
        private void AttachChangeTracking()
        {
            foreach (Control c in new Control[] { txtCenterName, txtPhone, txtWhatsApp, txtFacebook, txtInstagram, txtInvoiceNote })
                c.TextChanged += (s, e) => _isDataChanged = true;
        }

        private async Task SaveCenterDataInternal()
        {
            _currentSettings.CenterName = txtCenterName.Text;
            _currentSettings.Phone = txtPhone.Text;
            _currentSettings.WhatsApp = txtWhatsApp.Text;
            _currentSettings.Facebook = txtFacebook.Text;
            _currentSettings.Instagram = txtInstagram.Text;
            _currentSettings.Note = txtInvoiceNote.Text;
            _currentSettings.LogoBytes = picLogo.Image != null ? ImageToByteArray(picLogo.Image) : null;

            await _settingsRepo.SaveSettingsAsync(_currentSettings);
            _isDataChanged = false;
        }

        public async Task<bool> PromptUnsavedChanges()
        {
            if (!_isDataChanged) return true;
            var res = MessageBox.Show("هل تريد حفظ التغييرات في إعدادات المركز؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) { await SaveCenterDataInternal(); return true; }
            return res == DialogResult.No;
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream()) { image.Save(ms, ImageFormat.Png); return ms.ToArray(); }
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes)) return Image.FromStream(ms);
        }
    }
}