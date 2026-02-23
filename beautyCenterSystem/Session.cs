using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautyCenterSystem
{
    public static class CurrentSession
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string RoleName { get; set; }

        public static void Logout()
        {
            UserID = 0;
            Username = null;
            RoleName = null;
        }
    }
}
