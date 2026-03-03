using BeautyCenterSystem.Data;
using BeautyCenterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace beautyCenterSystem.data.Repositories
{
    public class SettingsRepository
    {
        private readonly DbConnectionFactory _dbFactory;
        public SettingsRepository(DbConnectionFactory dbFactory) => _dbFactory = dbFactory;

        public async Task<CenterSettings> GetSettingsAsync()
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                var sql = "SELECT TOP 1 * FROM CenterSettings"; // نأخذ أول سطر دائماً
                return await conn.QueryFirstOrDefaultAsync<CenterSettings>(sql) ?? new CenterSettings();
            }
        }

        public async Task SaveSettingsAsync(CenterSettings s)
        {
            using (var conn = _dbFactory.CreateConnection())
            {
                var sql = @"
                IF EXISTS (SELECT 1 FROM CenterSettings)
                BEGIN
                    UPDATE CenterSettings SET CenterName=@CenterName, Phone=@Phone, 
                           Facebook=@Facebook, Instagram=@Instagram, WhatsApp=@WhatsApp, 
                           Note=@Note, LogoBytes=@LogoBytes
                END
                ELSE
                BEGIN
                    INSERT INTO CenterSettings (CenterName, Phone, Facebook, Instagram, WhatsApp, Note, LogoBytes)
                    VALUES (@CenterName, @Phone, @Facebook, @Instagram, @WhatsApp, @Note, @LogoBytes)
                END";
                await conn.ExecuteAsync(sql, s);
            }
        }
    }
}
