using BeautyCenterSystem.Data.Repositories;
using BeautyCenterSystem.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace beautyCenterSystem
{
    public class BackupRepository : BaseRepository
    {
        private readonly string _databaseName = "BeautyCenterDB";

        public BackupRepository(DbConnectionFactory dbFactory) : base(dbFactory) { }

        /// <summary>
        /// إنشاء نسخة احتياطية يدوية أو تلقائية
        /// </summary>
        public async Task<string> CreateBackupAsync(string destinationPath)
        {
            // توليد اسم ملف فريد بناءً على التاريخ والوقت
            string fileName = $"{_databaseName}_{DateTime.Now:yyyy_MM_dd_HHmmss}.bak";
            string fullPath = Path.Combine(destinationPath, fileName);

            using var db = _dbFactory.CreateConnection();

            // استعلام SQL للنسخ الاحتياطي
            string sql = $@"BACKUP DATABASE [{_databaseName}] 
                            TO DISK = @FullPath 
                            WITH FORMAT, NAME = 'Full Backup of {_databaseName}';";

            await db.ExecuteAsync(sql, new { FullPath = fullPath });

            return fullPath;
        }

        /// <summary>
        /// استعادة قاعدة البيانات من ملف خارجي
        /// </summary>
        /// <remarks>تتطلب هذه العملية صلاحيات Admin والاتصال بـ master database</remarks>
        public async Task<bool> RestoreDatabaseAsync(string backupFilePath)
        {
            // ملاحظة: للاستعادة يجب أن نكون خارج قاعدة البيانات المستهدفة
            // سنقوم بتعديل سلسلة الاتصال مؤقتاً للاتصال بـ master
            var currentConnectionString = _dbFactory.CreateConnection().ConnectionString;
            var builder = new SqlConnectionStringBuilder(currentConnectionString)
            {
                InitialCatalog = "master"
            };

            using var masterDb = new SqlConnection(builder.ConnectionString);

            // 1. قطع جميع الاتصالات الحالية بقاعدة البيانات (Single User Mode)
            // 2. البدء بعملية الاستعادة مع خيار REPLACE
            // 3. إعادة الاتصالات للوضع الطبيعي (Multi User Mode)
            string sql = $@"
                ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{_databaseName}] FROM DISK = @FilePath WITH REPLACE;
                ALTER DATABASE [{_databaseName}] SET MULTI_USER;";

            int result = await masterDb.ExecuteAsync(sql, new { FilePath = backupFilePath });


            return true; // في حال نجاح التنفيذ دون Exception
        }
    }
}
