using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SMS
{
    public class DAL_Student:DBConnection
    {
        public DataTable getStudent()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Equipment", con);
            DataTable daStudent = new DataTable();
            da.Fill(daStudent);
            daStudent.Columns.Add("Ord");
            for (int i = 1; i <= daStudent.Rows.Count; i++)
                daStudent.Rows[i - 1]["Ord"] = i.ToString();
            return daStudent;
        }
        public bool insertStudent(string name, string email)
        {
            string str = string.Format("insert into Equipment(name,email) values('{0}','{1}')", name, email);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }
        public bool updateStudent(int id, string name, string email)
        {
            string str = string.Format("update Equipment set name='{0}', tt='{1}' where id = '{2}'", name, email, id);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }
        public bool deleteStudent(int id)
        {
            string str = string.Format("delete from Equipment where id = '{0}'", id);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }
    }
}
