using BUS_SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_SMS
{
    public partial class GUI_Login : Form
    {
        BUS_Login busLogin = new BUS_Login();
        public GUI_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPass.Text != "")
            {
                if (busLogin.Login(txtUsername.Text, txtPass.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Infomation");
                    GUI_Student x = new GUI_Student();
                    x.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Infomation");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu trống!\nĐiền thông tin và thử lại.", "Infomation");
                txtUsername.Focus();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GUI_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
