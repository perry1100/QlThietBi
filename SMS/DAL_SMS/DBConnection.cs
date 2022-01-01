using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_SMS
{
    public class DBConnection
    {
        public static SqlConnection con = new SqlConnection("server=DESKTOP-1UC0G7M;uid=sa;pwd=123456;database=SMD;MultipleActiveResultSets=true");
    }
}
