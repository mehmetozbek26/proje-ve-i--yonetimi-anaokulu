using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class SifreDegistir : Form
    {
        public SifreDegistir()
        {
            InitializeComponent();
        }

        Parola par = Parola.GET();
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
                            var temp = client.ParolaDegistir(txtoldpwd.Text, txtconfirmpwd.Text, txtuserid.Text, par.Departman);
                            if (temp == true)
                            {
                                MessageBox.Show("�ifre De�i�tirildi", "Message");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("�ifre De�i�tirilemedi.\nKullan�c� Ad� veya Parola Yanl��", "Message");
                                btnresetpwd_Click_1(sender, e);
                            }
                        }
                        btnresetpwd_Click_1(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Yeni �ifre Ayn� De�il","Message");
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
            Information.Text = "Kullan�c� Ad� Giriniz";
        }

        private void txtoldpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "�ifrenizi Giriniz";
        }

        private void txtnewpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Yeni �ifrenizi Griniz";
        }

        private void txtconfirmpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Yeni �ifrenizi Tekrar Griniz";
        }
        private int validatedata()
        {
            int i = 0;
            if (txtuserid.Text.Length == 0)
            {
                txtuserid.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtuserid, "Kullan�c� Ad� Giriniz");
                i = 1;
            }
            else
            {
                txtuserid.BackColor = Color.White;
            }
            if (txtoldpwd.Text.Length <4)
            {
                txtoldpwd.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtoldpwd, "�ifrenizi Giriniz");
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
                errorProvider1.SetError(txtnewpwd, "�ifreniz Minimum 4 Karakter Olmal�");
                errorProvider1.SetError(txtconfirmpwd, "Yeni �ifre Birbiriyle Ayn� Olmal�");
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
                errorProvider1.SetError(txtconfirmpwd, "Yeni �ifre Birbiriyle Ayn� Olmal�");
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
