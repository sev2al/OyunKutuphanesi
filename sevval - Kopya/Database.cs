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
        public static SqlConnection conn=new SqlConnection("Server=.;Database=giyimotomasyon;Trusted_Connection=True;");
    }
}
