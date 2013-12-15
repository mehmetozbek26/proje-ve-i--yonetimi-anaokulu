using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;


namespace AnaOkuluBilisim
{
    public partial class Giris : Form
    {
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        public Giris()
        {

            InitializeComponent();         
            txtpwd.Text = "admin";
            comboBox1.SelectedIndex = 2;
            txtuserid.Text = "admin";

        
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtuserid.Text == "" || txtuserid.Text==null) throw new Exception("Kullanıcı Adi giriniz.");
                if (txtpwd.Text == "" || txtpwd.Text==null) throw new Exception("Şifre giriniz.");
                    bool kontrol = client.GirisKontrol(txtuserid.Text, txtpwd.Text, comboBox1.SelectedItem.ToString());
                    if (kontrol)
                    {
                        Parola parola = Parola.GET();
                        parola.KullaniciAdi = txtuserid.Text;
                        parola.Sifre = txtpwd.Text;
                        parola.Departman = comboBox1.SelectedItem.ToString();
                        Form yeniform = new ListeForm();
                        yeniform.Size = Screen.PrimaryScreen.WorkingArea.Size;
                        yeniform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                    }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

       
    }
}
