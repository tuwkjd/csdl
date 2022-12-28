using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_CSharp
{
    public class DBConnection
    {
        public DBConnection()
        {
            
        }
        public SqlConnection CreateConection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=TUPHAM\SQLEXPRESS;Initial Catalog=sale;User ID=sa;Password=sa";
            return conn;
        }
    }
}
