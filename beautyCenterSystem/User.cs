using System;
using System.Collections.Generic;

namespace beautyCenterSystem
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        // اسم الدور (مفيد للعرض السريع)
        public string RoleName { get; set; }

        // قائمة مفاتيح الصلاحيات (Permission Keys) 
        // التي سيتم تعبئتها عند تسجيل الدخول
        public List<string> Permissions { get; set; } = new List<string>();
    }
}