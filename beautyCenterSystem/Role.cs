using System;
using System.Collections.Generic;

namespace beautyCenterSystem
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // قائمة الصلاحيات الكاملة المرتبطة بهذا الدور
        // سنستخدمها في واجهة "إدارة الأدوار"
        public List<Permission> RolePermissions { get; set; } = new List<Permission>();
    }

    // كلاس بسيط لتمثيل الصلاحية كما هي في قاعدة البيانات
    public class Permission
    {
        public int PermissionID { get; set; }
        public string PermissionKey { get; set; }
        public string PermissionName { get; set; }
    }
}