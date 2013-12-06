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
    public partial class Form1 : Form
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["MERKANVERTB"].ToString());
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        public Form1()
        {

            InitializeComponent();         
            txtpwd.Text = "niit";
            comboBox1.SelectedIndex = 1;
            txtuserid.Text = "mahmut";

        
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString() + " x " +
            //    Screen.PrimaryScreen.Bounds.Height.ToString());
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtuserid.Text == "")
                {
                    throw new Exception("Kullanıcı Adi giriniz.");
                }
                else if (txtpwd.Text == "")
                {
                    throw new Exception("Şifre giriniz.");
                }
                else
                {

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
