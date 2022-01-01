using DAL_SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_SMS
{
    public class BUS_Login
    {
        DAL_Login dalLogin = new DAL_Login();
        public bool Login(string username, string pass)
        {
            return dalLogin.Login(username, pass);
        }
    }
}
