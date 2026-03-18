using System;
using System.Collections.Generic;
using System.Linq;

namespace beautyCenterSystem
{
    public static class PermissionManager
    {
        private static List<string> _userPermissions = new List<string>();
        private static string _userRole = "";

        // يتم استدعاؤها في شاشة Login عند نجاح الدخول
        public static void Initialize(User user)
        {
            if (user == null) return;

            // التأكد من أن القائمة ليست null لتجنب أخطاء Contains لاحقاً
            _userPermissions = user.Permissions ?? new List<string>();

            // تخزين الدور مع إزالة أي مسافات زائدة
            _userRole = user.RoleName?.Trim() ?? "";
        }

        // الدالة التي ستستخدمها في كل "شبر" من البرنامج
        public static bool Can(string permissionKey)
        {
            // 1. فحص الأدمن بشكل مرن (يتجاهل حالة الأحرف Capital/Small)
            // سيقبل: Admin, admin, ADMIN
            if (!string.IsNullOrEmpty(_userRole) &&
                _userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // 2. التحقق من وجود مفتاح الصلاحية في القائمة للموظفين العاديين
            if (string.IsNullOrEmpty(permissionKey) || _userPermissions == null)
                return false;

            return _userPermissions.Contains(permissionKey);
        }

        // دالة إضافية لتنظيف البيانات عند تسجيل الخروج
        public static void Reset()
        {
            _userPermissions.Clear();
            _userRole = "";
        }
    }
}