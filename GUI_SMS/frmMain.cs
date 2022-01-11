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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Lock_Unlock(mySave.KT);
        }
        void Lock_Unlock(Boolean kt)
        {
            mnuLogout.Enabled = mnuManager.Enabled = mnuSearch.Enabled = mnuPrint.Enabled = !kt;
            mnuLogin.Enabled = mnuClose.Enabled = kt;
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Lock_Unlock(mySave.KT);
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            mySave.KT = !mySave.KT;
            Lock_Unlock(mySave.KT);
        }

        private void mnuManagerContacts_Click(object sender, EventArgs e)
        {
            GUI_DanhBaPhone f = new GUI_DanhBaPhone();
            f.Show();
        }
    }
}
