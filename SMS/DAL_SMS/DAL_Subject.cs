using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL_SMS
{
    public class DAL_Subject : DBConnection
    {
        public DataTable getSubject(string id)
        {
            string str = string.Format("select * from subject where id='{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dtbSubject = new DataTable();
            da.Fill(dtbSubject);
            dtbSubject.Columns.Add("Ord");
            for (int i = 1; i <= dtbSubject.Rows.Count; i++)
                dtbSubject.Rows[i - 1]["Ord"] = i.ToString();
            return dtbSubject;
        }
        public bool insertSubject(string id, string subjectName, string mark)
        {
            string str = string.Format("insert into subject(id,subject_name,subject_mark) values('{0}','{1}','{2}')", id, subjectName, mark);
            try
            {
                con.Open();
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
