using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace beautyCenterSystem 
{
    public class MaterialSearchableCombo : ComboBox
    {
        // لون الخط السفلي (أزرق مادي افتراضي)
        private Color _lineColor = Color.FromArgb(63, 81, 181);
        private Color _hoverColor = Color.FromArgb(222, 222, 222);

        public MaterialSearchableCombo()
        {
            // إعدادات البحث والكتابة
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;

            // إعدادات المظهر
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Segoe UI", 11f);
            this.BackColor = Color.White;
        }

        // رسم الخط السفلي ليناسب شكل Material
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // رسم خط بسيط في الأسفل ليحاكي شكل الـ Material
            using (Pen pen = new Pen(_lineColor, 2))
            {
                e.Graphics.DrawLine(pen, 0, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        // تحسين مظهر الأداة عند التركيز
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _lineColor = Color.FromArgb(33, 150, 243); // تغيير اللون عند التركيز (Active)
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _lineColor = Color.FromArgb(63, 81, 181); // العودة للون الأصلي
            this.Invalidate();
        }
    }
}