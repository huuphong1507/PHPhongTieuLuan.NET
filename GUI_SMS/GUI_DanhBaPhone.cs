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

namespace GUI_SMS
{
    public partial class GUI_DanhBaPhone : Form
    {
        BUS_DanhBaPhone busDanhBaPhone = new BUS_DanhBaPhone();
        bool tf, tf1;
        int id;
        public GUI_DanhBaPhone()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_Unlock(tf);
                txtgioitinh.Text = txtsodt.Text = txtnhom.Text = txtdiachi.Text = txthoten.Text = txtSearch.Text = "";
                txthoten.Focus();
            }
            else MessageBox.Show("Update or Deleting!\nClick Reset to do another thing.","Information");
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txthoten.Text!="" && txtgioitinh.Text!="" && txtsodt.Text!="" && txtnhom.Text!="" && txtdiachi.Text!="")
            {
                if (busDanhBaPhone.insertDanhBaPhone(txthoten.Text,txtgioitinh.Text,txtsodt.Text,txtnhom.Text,txtdiachi.Text))
                {
                    MessageBox.Show("Insert Successful!", "Information");
                    tf = !tf;
                    Lock_Unlock(tf);
                    dgvDanhBaPhone.DataSource = busDanhBaPhone.getDanhBaPhone();
                }
                else
                {
                    MessageBox.Show("Add fail!", "Information");
                }
            }
            else
            {
                MessageBox.Show("Please input data again.", "Information");
                txthoten.Focus();
            }
        }
        void Lock_Unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txthoten.Enabled = txtgioitinh.Enabled = txtsodt.Enabled = txtnhom.Enabled = txtdiachi.Enabled = txtSearch.Enabled = !tf;
        }
        void Lock_Unlock1(bool tf1)
        {
            dgvDanhBaPhone.Enabled = tf1;
            btnDelete.Enabled = btnUpdate.Enabled = txthoten.Enabled = txtgioitinh.Enabled = txtsodt.Enabled = txtnhom.Enabled = txtdiachi.Enabled = txtSearch.Enabled = !tf1;
        }

        private void dgvDanhBaPhone_Click(object sender, EventArgs e)
        {
            if (tf)
            {
                int i = dgvDanhBaPhone.CurrentRow.Index;
                id = int.Parse(dgvDanhBaPhone[0, i].Value.ToString());
                txthoten.Text = dgvDanhBaPhone[1, i].Value.ToString();
                txtgioitinh.Text = dgvDanhBaPhone[2, i].Value.ToString();
                txtsodt.Text = dgvDanhBaPhone[3, i].Value.ToString();
                txtnhom.Text = dgvDanhBaPhone[4, i].Value.ToString();
                txtdiachi.Text = dgvDanhBaPhone[5, i].Value.ToString();
                txthoten.Focus();
                tf1 = !tf1;
                Lock_Unlock1(tf1);
            }
            else MessageBox.Show("Inserting!\nClick Reset to do another thing.", "Information");
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txthoten.Text != "" && txtgioitinh.Text != "" && txtsodt.Text != "" && txtnhom.Text != "" && txtdiachi.Text != "")
            {
                if (busDanhBaPhone.updateDanhBaPhone(id,txthoten.Text, txtgioitinh.Text, txtsodt.Text, txtnhom.Text, txtdiachi.Text))
                {
                    MessageBox.Show("Update Successful!", "Information");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvDanhBaPhone.DataSource = busDanhBaPhone.getDanhBaPhone();
                }
                else
                {
                    MessageBox.Show("Update fail!", "Information");
                }
            }
            else
            {
                MessageBox.Show("Please input data again.", "Information");
                txthoten.Focus();
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (busDanhBaPhone.deleteDanhBaPhone(id))
            {
                MessageBox.Show("Delete Successful!", "Information");
                tf1 = !tf1;
                Lock_Unlock1(tf1);
                dgvDanhBaPhone.DataSource = busDanhBaPhone.getDanhBaPhone();
            }
            else
            {
                MessageBox.Show("Delete fail!", "Information");
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           Close();
        }

       

        private void GUI_DanhBaPhone_Load(object sender, EventArgs e)
        {
            dgvDanhBaPhone.DataSource = busDanhBaPhone.getDanhBaPhone();
        }
    }
}
