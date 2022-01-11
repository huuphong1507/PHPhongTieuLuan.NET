using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_SMS;
using System.Data.SqlClient;
namespace GUI_SMS
{
    public partial class frmLogin : Form
    {
        BUS_DanhBaPhone busAdmin = new BUS_DanhBaPhone();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (busAdmin.LoginAdmin(txtUsername.Text, txtPassword.Text) == true)
            {
                mySave.KT = !mySave.KT;
                MessageBox.Show("Login Success", "Attention");
                Close();
            }
            else
            {
                MessageBox.Show("Fail", "Attention");
            }
        }
    }
}
