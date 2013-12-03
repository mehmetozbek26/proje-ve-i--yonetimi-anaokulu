using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.AnaOkuluService;

namespace AnaOkuluBilisim
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        
    
        private void btncreatepwd_Click_1(object sender, EventArgs e)
        {
            Information.Text = "";
            try
            {
                if (validatedata() == 0)
                {
                    errorProvider1.Clear();
                    if (txtnewpwd.Text.Length == txtconfirmpwd.Text.Length)
                    {
                        using (AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient())
                        {
                            var temp = client.ParolaDegistir(txtoldpwd.Text, txtconfirmpwd.Text, txtuserid.Text, GlobalClass.GlobalVar);
                            if (temp == true)
                            {
                                MessageBox.Show("Password changed", "Message");
                            }
                            else
                            {
                                MessageBox.Show("Password did not change your user id or password is wrong", "Message");
                                btnresetpwd_Click_1(sender, e);
                            }
                        }
                        btnresetpwd_Click_1(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Your new password and confirm password is not same","Message");
                        txtnewpwd.Clear();
                        txtconfirmpwd.Clear();
                    }
                }
          }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnresetpwd_Click_1(object sender, EventArgs e)
        {
            txtuserid.Clear();
            txtoldpwd.Clear();
            txtnewpwd.Clear();
            txtconfirmpwd.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuserid_Enter(object sender, EventArgs e)
        {
            Information.Text = "Please enter user id";
        }

        private void txtoldpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Please enter current password";
        }

        private void txtnewpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Please enter new password";
        }

        private void txtconfirmpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Please re-enter new password";
        }
        private int validatedata()
        {
            int i = 0;
            if (txtuserid.Text.Length == 0)
            {
                txtuserid.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtuserid, "Please enter user Id");
                i = 1;
            }
            else
            {
                txtuserid.BackColor = Color.White;
            }
            if (txtoldpwd.Text.Length <4)
            {
                txtoldpwd.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtoldpwd, "Please enter current password");
                i = 1;
            }
            else
            {
                txtoldpwd.BackColor = Color.White;
            }
            if (txtnewpwd.Text.Length <4)
            {
                txtnewpwd.BackColor = Color.LightCoral;
                txtconfirmpwd.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtnewpwd, "Please enter your password and password length should be minimum four characters");
                errorProvider1.SetError(txtconfirmpwd, "Your password should be match to new password");
                i = 1;
            }
            else
            {
                txtconfirmpwd.BackColor = Color.White;
                txtnewpwd.BackColor = Color.White;
            }
            if (txtconfirmpwd.Text.Length <4)
            {
                txtconfirmpwd.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtconfirmpwd, "Your password should be match to new password");
                i = 1;
            }
            else
            {
                txtconfirmpwd.BackColor = Color.White;
            }
            return i;
        }
    }
}
