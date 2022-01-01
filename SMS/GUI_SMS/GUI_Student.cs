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
    public partial class GUI_Student : Form
    {
        BUS_Student busStudent = new BUS_Student();
        bool tf, tf1;
        int id;
        public GUI_Student()
        {
            InitializeComponent();
            tf = tf1 = true;
            lock_unLock(tf);
            lock_unLock1(tf1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                lock_unLock(tf);
                txtEmail.Text = txtName.Text = "";
                txtName.Focus();
            }
            else MessageBox.Show("Updating or Deleting!\nClick Reset to do another thing.", "Infomation"); 
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   
            if(txtEmail.Text != "" && txtName.Text != "")
            {
                if(busStudent.insertStudent(txtName.Text, txtEmail.Text))
                {
                    MessageBox.Show("Insert successful.", "Infomation");
                    tf = !tf;
                    lock_unLock(tf);
                    dgvStudent.DataSource = busStudent.getStudent();
                }
                else
                {
                    MessageBox.Show("Insert fail!", "Infomation");
                }
            }
            else
            {
                MessageBox.Show("Student Name or Email is empty!\nInput data again.", "Infomation");
                txtName.Focus();
            }
            
        }
        void lock_unLock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txtEmail.Enabled = txtName.Enabled = !tf;
        }
        void lock_unLock1(bool tf1)
        {
            dgvStudent.Enabled = tf1;
            btnDelete.Enabled = btnUpdate.Enabled = txtEmail.Enabled = txtName.Enabled = !tf1;
        }

        private void dgvStudent_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                int i = dgvStudent.CurrentRow.Index;
                id = int.Parse(dgvStudent[0, i].Value.ToString());
                txtName.Text = dgvStudent[1, i].Value.ToString();
                txtEmail.Text = dgvStudent[2, i].Value.ToString();
                txtName.Focus();
                tf1 = !tf1;
                lock_unLock1(tf1);
            }
            else MessageBox.Show("Inserting!\nClick Reset to do another thing.", "Infomation");
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtName.Text != "")
            {
                if (busStudent.updateStudent(id, txtName.Text, txtEmail.Text))
                {
                    MessageBox.Show("Update successful.", "Infomation");
                    tf1 = !tf1;
                    lock_unLock1(tf1);
                    dgvStudent.DataSource = busStudent.getStudent();
                }
                else
                {
                    MessageBox.Show("Update fail!", "Infomation");
                }
            }
            else
            {
                MessageBox.Show("Student Name or Email is empty!\nInput data again.", "Infomation");
                txtName.Focus();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (busStudent.deleteStudent(id))
            {
                MessageBox.Show("Delete successful.", "Infomation");
                tf1 = !tf1;
                lock_unLock1(tf1);
                dgvStudent.DataSource = busStudent.getStudent();
            }
            else
            {
                MessageBox.Show("Delete fail!", "Infomation");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            lock_unLock(tf);
            lock_unLock1(tf1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Subject x = new GUI_Subject();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI_Login y = new GUI_Login();
            y.Show();
        }

        private void GUI_Student_Load(object sender, EventArgs e)
        {
            dgvStudent.DataSource = busStudent.getStudent();
        }
    }
}
