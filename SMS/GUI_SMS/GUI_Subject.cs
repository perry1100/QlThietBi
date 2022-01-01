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
    public partial class GUI_Subject : Form
    {
        BUS_Student busStudent = new BUS_Student();
        BUS_Subject busSubject = new BUS_Subject();
        bool tf, tf1;
        DataTable dtbStudent;
        public GUI_Subject()
        {
            InitializeComponent();
            tf = tf1 = true;
            lock_unLock(tf);
            lock_unLock1(tf1);
            dtbStudent = busStudent.getStudent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                lock_unLock(tf);
                txtMark.Text = txtSubjectName.Text = "";
                txtSubjectName.Focus();
            }
            else MessageBox.Show("Updating or Deleting!\nClick Reset to do another thing.", "Infomation");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMark.Text != "" && txtSubjectName.Text != "")
            {
                string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
                if (busSubject.insertSubject(id, txtSubjectName.Text, txtMark.Text))
                {
                    tf = !tf;
                    lock_unLock(tf);
                    txtSubjectName.Text = txtMark.Text = "";
                    dgvSubject.DataSource = busSubject.getSubject(id);
                    MessageBox.Show("Insert successful.", "Infomation");
                }
                else
                {
                    MessageBox.Show("Insert fail!", "Infomation");
                }
            }
            else
            {
                MessageBox.Show("Subject Name or Email is empty!\nInput data again.", "Infomation");
                txtSubjectName.Focus();
            }

        }
        void lock_unLock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txtSubjectName.Enabled = txtMark.Enabled = !tf;
        }
        void lock_unLock1(bool tf1)
        {
            dgvSubject.Enabled = tf1;
            btnDelete.Enabled = btnUpdate.Enabled = txtMark.Enabled = txtSubjectName.Enabled = !tf1;
        }

        private void dgvStudent_Click(object sender, EventArgs e)
        {
            /*if (tf1)
            {
                int i = dgvSubject.CurrentRow.Index;
                id = int.Parse(dgvStudent[0, i].Value.ToString());
                txtName.Text = dgvStudent[1, i].Value.ToString();
                txtEmail.Text = dgvStudent[2, i].Value.ToString();
                txtName.Focus();
                tf1 = !tf1;
                lock_unLock1(tf1);
            }
            else MessageBox.Show("Inserting!\nClick Reset to do another thing.", "Infomation");*/

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*if (txtEmail.Text != "" && txtName.Text != "")
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
            }*/

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*if (busStudent.deleteStudent(id))
            {
                MessageBox.Show("Delete successful.", "Infomation");
                tf1 = !tf1;
                lock_unLock1(tf1);
                dgvStudent.DataSource = busStudent.getStudent();
            }
            else
            {
                MessageBox.Show("Delete fail!", "Infomation");
            }*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GUI_Subject_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < dtbStudent.Rows.Count; i++)
            {
                cmbStudentName.Items.Add(dtbStudent.Rows[i]["name"].ToString());
                cmbStudentName.Text = dtbStudent.Rows[0]["name"].ToString();
            }
            string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }

        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            lock_unLock(tf);
            lock_unLock1(tf1);
        }

        
    }
}
