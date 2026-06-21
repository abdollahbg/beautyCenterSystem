using System;
using System.Data.SqlClient;

class Program {
    static void Main() {
        string connStr = "Server=.\\SQLEXPRESS;Database=BeautyCenterDB;Trusted_Connection=True;";
        using(var conn = new SqlConnection(connStr)) {
            conn.Open();
            using(var cmd = new SqlCommand("SELECT name FROM sys.tables WHERE name LIKE '%GymSubscriptionType%'", conn)) {
                using(var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
            }
        }
    }
}
