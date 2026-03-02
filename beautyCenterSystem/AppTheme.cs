using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp; // مكتبة الأيقونات

namespace beautyCenterSystem
{
    public static class AppTheme
    {
        // --- لوحة الألوان الخاصة بالمركز ---
        public static Color Primary = ColorTranslator.FromHtml("#e61946");
        public static Color RoseGold = ColorTranslator.FromHtml("#e7d0d5");
        public static Color Charcoal = ColorTranslator.FromHtml("#1b0e11");
        public static Color BackgroundLight = ColorTranslator.FromHtml("#fcf8f9");
        public static Color White = Color.White;
        public static Color DarkGray = Color.FromArgb(45, 45, 48);

        private static EmbeddedFontLoader _fontLoader = new EmbeddedFontLoader();

        static AppTheme()
        {
            string ns = "beautyCenterSystem";
            _fontLoader.LoadFontFromResource($"{ns}.Cairo-Regular.ttf");
            _fontLoader.LoadFontFromResource($"{ns}.Cairo-Bold.ttf");
        }

        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(_fontLoader.GetFontFamily("Cairo"), size, style);
        }

        public static void Apply(Control parent)
        {
            if (parent is MaterialForm mForm)
            {
                var manager = MaterialSkinManager.Instance;
                manager.AddFormToManage(mForm);
                manager.Theme = MaterialSkinManager.Themes.LIGHT;
                manager.ColorScheme = new ColorScheme(
                    Primary, Charcoal, RoseGold, Primary, TextShade.WHITE);

                mForm.RightToLeft = RightToLeft.Yes;
                mForm.RightToLeftLayout = true;
            }

            parent.BackColor = BackgroundLight;
            parent.Font = GetFont(parent.Font.Size);

            ApplyToAllChildren(parent);
        }

        private static void ApplyToAllChildren(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // 1. استثناء التيكست بوكس من خط كايرو (للمشاكل البرمجية)
                bool isTextBox = c is MaterialTextBox || c is MaterialTextBox2 || c is TextBox;
                if (!isTextBox)
                {
                    c.Font = GetFont(c.Font.Size);
                }

                // --- تنسيق الأزرار العادية و IconButton ---
                if (c is IconButton iconBtn)
                {
                    iconBtn.IconFont = IconFont.Auto;
                    iconBtn.FlatStyle = FlatStyle.Flat;
                    iconBtn.FlatAppearance.BorderSize = 0;
                    iconBtn.BackColor = Color.White; // ليعطي شكل Sidebar أنيق
                    iconBtn.ForeColor = Charcoal;
                    iconBtn.IconColor = Charcoal;
                    iconBtn.TextAlign = ContentAlignment.MiddleRight;
                    iconBtn.ImageAlign = ContentAlignment.MiddleRight;
                    iconBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    iconBtn.Padding = new Padding(0, 0, 15, 0);
                    iconBtn.Cursor = Cursors.Hand;
                    iconBtn.FlatAppearance.MouseOverBackColor = RoseGold;
                }
                else if (c is Button btn && !(c is MaterialButton))
                {
                    btn.BackColor = Primary;
                    btn.ForeColor = White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                }

                // --- تنسيق الـ Panels (لو أردت تمييز الـ Sidebar) ---
                if (c is Panel pnl)
                {
                    if (pnl.Name.ToLower().Contains("sidebar"))
                        pnl.BackColor = Charcoal;
                    else if (pnl.Name.ToLower().Contains("header"))
                        pnl.BackColor = White;
                }

                // --- تنسيق العناوين (Labels) ---
                if (c is Label lbl)
                {
                    lbl.ForeColor = Charcoal;
                    if (lbl.Tag?.ToString() == "Header") // لو وضعت كلمة Header في خاصية Tag
                        lbl.Font = GetFont(lbl.Font.Size, FontStyle.Bold);
                }

                // --- تنسيق الجداول (DataGridView) لتكون مودرن ---
                if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.MultiSelect = false;
                    dgv.RowHeadersVisible = false;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // الهيدر
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Primary;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = GetFont(10, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.ColumnHeadersHeight = 40;

                    // الصفوف
                    dgv.DefaultCellStyle.SelectionBackColor = RoseGold;
                    dgv.DefaultCellStyle.SelectionForeColor = Charcoal;
                    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.RowTemplate.Height = 35;
                }

                // --- تنسيق القوائم (ListView) ---
                if (c is ListView lv)
                {
                    lv.BackColor = White;
                    lv.ForeColor = Charcoal;
                    lv.BorderStyle = BorderStyle.None;
                    lv.FullRowSelect = true;
                    lv.GridLines = false;
                    lv.Font = GetFont(10, FontStyle.Regular);
                }

                if (c.HasChildren) ApplyToAllChildren(c);
            }
        }
    }
}