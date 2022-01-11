using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    class DAL_Admin: DBConnection
    {
        public DataTable getAdmin()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DangNhap", con);
            DataTable dtbAdmin = new DataTable();
            da.Fill(dtbAdmin);
            dtbAdmin.Columns.Add("Ord");
            for (int i = 1; i <= dtbAdmin.Rows.Count; i++)
                dtbAdmin.Rows[i - 1]["Ord"] = i.ToString();
            return dtbAdmin;
        }
        public bool LoginAdmin(string username, string password)
        {
            string str = string.Format("select * from DangNhap where username = '{0}' and password = '{1}'", username, password);
            Boolean kq = false;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    kq = true;
                }
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return kq;
        }

    }
}
