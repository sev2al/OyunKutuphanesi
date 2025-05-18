using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevval
{
    public static class Database
    {
        public static string ConnectionString = "Data Source=.;Initial Catalog=giyimotomasyon;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(ConnectionString);

        public static bool TestConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
