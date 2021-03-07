using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Data.SqlDbAcces
{
    public class ConnectionString
    {
        private static string connectionString = "Data Source=LAPTOP-M87NBEN5;Initial Catalog=AppDB;Integrated Security=True";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
