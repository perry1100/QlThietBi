using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SMS
{
    public class DAL_Login : DBConnection
    {
        public bool Login(string username, string pass)
        {
            string str = string.Format("select * from Accout where username = '{0}' and pass = '{1}'", username, pass);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    return true;
                }
                data.Close();
                data.Dispose();
            }
            catch
            {
                return false;
            }
           
            con.Close();
            return false;
        }

    }
}
