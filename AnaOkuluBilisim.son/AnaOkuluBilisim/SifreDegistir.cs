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
                                MessageBox.Show("Þifre Deðiþtirildi", "Message");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Þifre Deðiþtirilemedi.\nKullanýcý Adý veya Parola Yanlýþ", "Message");
                                btnresetpwd_Click_1(sender, e);
                            }
                        }
                        btnresetpwd_Click_1(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Yeni Þifre Ayný Deðil","Message");
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
            Information.Text = "Kullanýcý Adý Giriniz";
        }

        private void txtoldpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Þifrenizi Giriniz";
        }

        private void txtnewpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Yeni Þifrenizi Griniz";
        }

        private void txtconfirmpwd_Enter(object sender, EventArgs e)
        {
            Information.Text = "Yeni Þifrenizi Tekrar Griniz";
        }
        private int validatedata()
        {
            int i = 0;
            if (txtuserid.Text.Length == 0)
            {
                txtuserid.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtuserid, "Kullanýcý Adý Giriniz");
                i = 1;
            }
            else
            {
                txtuserid.BackColor = Color.White;
            }
            if (txtoldpwd.Text.Length <4)
            {
                txtoldpwd.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtoldpwd, "Þifrenizi Giriniz");
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
                errorProvider1.SetError(txtnewpwd, "Þifreniz Minimum 4 Karakter Olmalý");
                errorProvider1.SetError(txtconfirmpwd, "Yeni Þifre Birbiriyle Ayný Olmalý");
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
                errorProvider1.SetError(txtconfirmpwd, "Yeni Þifre Birbiriyle Ayný Olmalý");
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
