using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;
using beautyCenterSystem;

namespace BeautyCenterSystem.Data.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        // 1. جلب كافة الموظفات النشطات مع اسم الغرفة المرتبطة
        // 1. جلب كافة الموظفات النشطات مع اسم الغرفة المرتبطة
        // تم تغيير dynamic إلى Employee لضمان تطابق البيانات
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
        SELECT 
            E.EmployeeID, 
            E.EmployeeName, 
            E.Phone, 
            E.CommissionRate, 
            E.RoomID, 
            E.IsActive,
            E.EmployeeType,
            E.BaseSalary,
            R.RoomName 
        FROM Employees E
        LEFT JOIN Rooms R ON E.RoomID = R.RoomID
        WHERE E.IsActive = 1
        ORDER BY E.EmployeeID DESC";

            // جلب البيانات وربطها مباشرة بموديل Employee
            return await db.QueryAsync<Employee>(sql);
        }

        // 2. إضافة موظفة جديدة
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                INSERT INTO Employees (EmployeeName, Phone, CommissionRate, RoomID, IsActive, EmployeeType, BaseSalary)
                VALUES (@EmployeeName, @Phone, @CommissionRate, @RoomID, 1, @EmployeeType, @BaseSalary);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            return await db.ExecuteScalarAsync<int>(sql, employee);
        }

        // 3. تحديث بيانات موظفة (يستخدم عند التعديل المباشر في الجدول)
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = @"
                UPDATE Employees 
                SET EmployeeName = @EmployeeName, 
                    Phone = @Phone, 
                    CommissionRate = @CommissionRate, 
                    RoomID = @RoomID,
                    EmployeeType = @EmployeeType,
                    BaseSalary = @BaseSalary
                WHERE EmployeeID = @EmployeeID";

            int rows = await db.ExecuteAsync(sql, employee);
            return rows > 0;
        }

        // 4. حذف موظفة (حذف منطقي)
        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "UPDATE Employees SET IsActive = 0 WHERE EmployeeID = @ID";

            int rows = await db.ExecuteAsync(sql, new { ID = employeeId });
            return rows > 0;
        }

        // 5. جلب الغرف لملء الـ ComboBox داخل الجدول
        public async Task<IEnumerable<Room>> GetRoomsForComboAsync()
        {
            using var db = _dbFactory.CreateConnection();
            // Dapper سيقوم بربط النتائج بخصائص كلاس Room تلقائياً
            var result = await db.QueryAsync<Room>("SELECT RoomID, RoomName FROM Rooms WHERE IsActive = 1");

            return result.ToList();
        }

        // جلب إجمالي ما استحقته الموظفة من جدول تفاصيل المواعيد
        public async Task<decimal> GetTotalEarnedAsync(int employeeId)
        {
            using var db = _dbFactory.CreateConnection();
            // نستخدم ISNULL لضمان عدم رجوع قيمة null إذا لم يكن لها عمليات بعد
            string sql = "SELECT ISNULL(SUM(CommissionAmount), 0) FROM AppointmentDetails WHERE EmployeeID = @ID";
            return await db.ExecuteScalarAsync<decimal>(sql, new { ID = employeeId });
        }

        // جلب إجمالي ما تم صرفه للموظفة سابقاً من جدول مدفوعات الموظفين الجديد
        public async Task<decimal> GetTotalPaidAsync(int employeeId)
        {
            using var db = _dbFactory.CreateConnection();
            string sql = "SELECT ISNULL(SUM(AmountPaid), 0) FROM EmployeePayments WHERE EmployeeID = @ID";
            return await db.ExecuteScalarAsync<decimal>(sql, new { ID = employeeId });
        }

        // تسجيل عملية صرف جديدة (مع تحديث رصيد الخزنة في معاملة واحدة Transaction)
        public async Task<bool> SaveEmployeePaymentAsync(int employeeId, int safeId, decimal amount, string notes, int userId)
        {
            using var db = _dbFactory.CreateConnection();
            db.Open();
            using var trans = db.BeginTransaction();
            try
            {
                // 1. إضافة سجل الصرف في الجدول الجديد
                string sqlPayment = @"INSERT INTO EmployeePayments (EmployeeID, SafeID, AmountPaid, PaymentDate, Notes, IssuedBy) 
                              VALUES (@EmpID, @SafeID, @Amount, GETDATE(), @Notes, @UserID)";

                await db.ExecuteAsync(sqlPayment,
                    new { EmpID = employeeId, SafeID = safeId, Amount = amount, Notes = notes, UserID = userId },
                    trans);

                // 2. خصم المبلغ من رصيد الخزنة المختار في جدول Safes
                // ملاحظة: تأكد أن اسم الحقل في جدول Safes هو Balance كما في الكويري الخاص بك
                string sqlUpdateSafe = "UPDATE Safes SET Balance = Balance - @Amount WHERE SafeID = @SafeID";

                await db.ExecuteAsync(sqlUpdateSafe,
                    new { Amount = amount, SafeID = safeId },
                    trans);

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }
        }
    }
}