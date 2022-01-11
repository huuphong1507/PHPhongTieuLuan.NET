using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_DanhBaPhone: DBConnection
    {
        public DataTable getDanhBaPhone()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DanhBa", con);
            DataTable daDanhBaPhone = new DataTable();
            da.Fill(daDanhBaPhone);
            daDanhBaPhone.Columns.Add("Ord");
            for (int i = 1; i <= daDanhBaPhone.Rows.Count; i++)
                daDanhBaPhone.Rows[i-1]["Ord"] = i.ToString();
            return daDanhBaPhone;
        }
        public bool insertDanhBaPhone(string hoten, string gioitinh, string sodt, string nhom, string diachi)
        {
            string str = string.Format("insert into DanhBa(hoten, gioitinh, sodt, nhom, diachi) values('{0}','{1}','{2}','{3}','{4}')", hoten, gioitinh, sodt, nhom, diachi);
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
        public bool updateDanhBaPhone(int id, string hoten, string gioitinh, string sodt, string nhom, string diachi)
        {
            string str = string.Format("update DanhBa set hoten='{0}',gioitinh='{1}',sodt='{2}',nhom='{3}',diachi='{4}' where id = '{5}'", hoten, gioitinh, sodt, nhom, diachi, id);
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
        public bool deleteDanhBaPhone(int id)
        {
            string str = string.Format("delete DanhBa where id = '{0}'", id);
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
