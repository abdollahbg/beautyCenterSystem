using System;
using System.Collections.Generic;
using System.Linq;

namespace beautyCenterSystem
{
    public static class CurrentSession
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string RoleName { get; set; }
        // قائمة تخزن مفاتيح الصلاحيات المسموحة لهذا المستخدم
        public static List<string> UserPermissions { get; set; } = new List<string>();

        public static void Logout()
        {
            UserID = 0;
            Username = null;
            RoleName = null;
            UserPermissions.Clear();
        }

        // دالة سريعة لفحص الصلاحية من أي فورم
        public static bool CheckPermission(string permissionKey)
        {
            // إذا كان المستخدم "Admin" نعطيه صلاحية مطلقة تلقائياً
            if (RoleName == "Admin") return true;

            return UserPermissions.Contains(permissionKey);
        }
    }
}