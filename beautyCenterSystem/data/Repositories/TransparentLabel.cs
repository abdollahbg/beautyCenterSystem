using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem.data.Repositories
{
    public class TransparentLabel : Label
    {
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = -1;

            // إذا حاول الماوس فحص "هل أنا فوق الأداة؟"
            if (m.Msg == WM_NCHITTEST)
            {
                // نرد عليه بـ: "لا، أنا شفاف، اضغط على ما خلفي"
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
