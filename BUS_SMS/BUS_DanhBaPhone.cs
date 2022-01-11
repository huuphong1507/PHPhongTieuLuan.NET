using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;
using System.Data;
using System.Data.SqlClient;
namespace BUS_SMS
{
    public class BUS_DanhBaPhone
    {
        DAL_DanhBaPhone daDanhBaPhone = new DAL_DanhBaPhone();
        public DataTable getDanhBaPhone()
        {
            return daDanhBaPhone.getDanhBaPhone();
        }
        public bool insertDanhBaPhone(string hoten, string gioitinh, string sodt, string nhom, string diachi)
        {
            return daDanhBaPhone.insertDanhBaPhone(hoten, gioitinh, sodt, nhom, diachi);
        }
        public bool updateDanhBaPhone(int id, string hoten, string gioitinh, string sodt, string nhom, string diachi)
        {
            return daDanhBaPhone.updateDanhBaPhone(id, hoten, gioitinh, sodt, nhom, diachi);
        }
        public bool deleteDanhBaPhone(int id)
        {
            return daDanhBaPhone.deleteDanhBaPhone(id);
        }
        public bool LoginAdmin(string username, string password)
        {
            return daDanhBaPhone.LoginAdmin(username, password);
        }
    }
}
