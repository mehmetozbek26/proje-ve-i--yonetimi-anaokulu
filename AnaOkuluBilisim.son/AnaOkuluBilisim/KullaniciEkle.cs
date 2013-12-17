using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.Models;
using AnaOkuluBilisim.AnaOkuluService;

namespace AnaOkuluBilisim
{
    public partial class KullaniciEkle : Form
    {
        Parola par = Parola.GET();
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        public KullaniciEkle()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Information1.Text = "";
            try
            {
                if (validatedata() == 0)
                {
                    errorProvider1.Clear();                 
                    if (!client.KontrolAdVeSoyad(par.KullaniciAdi,par.Sifre,par.Departman,textBox5.Text,textBox6.Text))                                
                        MessageBox.Show("Bu Kullanýcý Önceden Kayýtlý");                   
                    else
                    {
                        if (textBox3.Text == textBox4.Text)
                        {
                            pwd yeni = new pwd
                            {
                                firstname = textBox5.Text.ToUpper(),
                                lastname = textBox6.Text.ToUpper(),
                                address = textBox8.Text.ToUpper(),
                                age = Convert.ToInt32(comboBox3.Text),
                                comdepart = comdepart.Text.ToUpper(),
                                confirmpassword = textBox4.Text.ToUpper(),
                                createpassword = textBox3.Text.ToUpper(),
                                day = Convert.ToInt32(comboBox4.Text),
                                gender = comboBox2.Text.ToUpper(),
                                mount = Convert.ToInt32(comboBox5.Text),
                                tel = txtcontact.Text.ToUpper(),
                                userid = textBox2.Text.ToUpper(),
                                year = Convert.ToInt32(textBox7.Text)
                            };
                            if(client.KullaniciEkle(par.KullaniciAdi, par.Sifre, par.Departman, yeni))
                            {
                                MessageBox.Show("Kullanýcý Kaydedildi", "Message");
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error");
                        }
                        else
                        {
                            MessageBox.Show("Þifreler Ayný Deðil", "Error");
                        }
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Bu Kullanýcý Adý Sistemde Kayýtlý Baþka Kullanýcý Adý Deneyiniz", "Error");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int validatedata()
        {
            int a = 0;
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox5, "Ýsminizi Giriniz");
                a = 1;
            }
            else
            {
                textBox5.BackColor = Color.White;
            }
            if (comboBox4.Text == "")
            {
                comboBox4.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox4, "Tarih Giriniz");
                a = 1;
            }
            else
            {
                comboBox4.BackColor = Color.White;
            }
            if (comboBox5.Text == "")
            {
                comboBox5.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox5, "Ay Giriniz");
                a = 1;
            }
            else
            {
                comboBox5.BackColor = Color.White;
            }
            if (textBox7.Text == "")
            {
                textBox7.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox7, "Yaþýnýzý Giriniz");
                a = 1;
            }
            else
            {
                textBox7.BackColor = Color.White;
            }
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox6, "Soyadýnýzý Giriniz");
                a = 1;
            }
            else
            {
                textBox6.BackColor = Color.White;
            }
            if (comboBox3.Text == "")
            {
                comboBox3.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox3, "Yaþýnýzý Giriniz");
                a = 1;
            }
            else
            {
                comboBox3.BackColor = Color.White;
            }
            if (comboBox2.Text == "")
            {
                comboBox2.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox2, "Cinsiyetinizi Seçiniz");
                a = 1;
            }
            else
            {
                comboBox2.BackColor = Color.White;
            }
            if (textBox8.Text == "")
            {
                textBox8.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox8, "Adresinizi Giriniz");
                a = 1;
            }
            else
            {
                textBox8.BackColor = Color.White;
            }
            if (txtcontact.Text.Length < 6)
            {
                txtcontact.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtcontact, "Telefon Numarasý Giriniz");
                a = 1;
            }
            else
            {
                txtcontact.BackColor = Color.White;
            }
           
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox2, "Kullanýcý Adýnýzý Giriniz");
                a = 1;
            }
            else
            {
                textBox2.BackColor = Color.White;
            }
            if (textBox3.Text.Length < 4)
            {
                textBox3.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox3, "Þifre En Az 4 Karakter Olmalýdýr");
                a = 1;
            }
            else
            {
                textBox3.BackColor = Color.White;
            }
            if (textBox4.Text.Length < 4)
            {
                textBox4.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox4, "Þifenizi Doðrulayýnýz");
                a = 1;
            }
            else
            {
                textBox4.BackColor = Color.White;
            }
           
           
           
            if (comdepart.Text == "")
            {
                comdepart.BackColor = Color.LightCoral;
                errorProvider1.SetError(comdepart, "Bölümünüzü Seçiniz");
            }
            else
            {
                comdepart.BackColor = Color.White;
            }
            return a;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Name";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your last Name";
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your gender";
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Date of Birth";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please create your user Id";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please create your password";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please varify your password";
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please choose your security question";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter the answer";
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your full address";
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your contact no.";
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your qualification";
        }
        int d;
        private void frmnewaccount_Load(object sender, EventArgs e)
        {
            d = System.DateTime.Now.Year;
            for (int i = 18; i < 100; i++)
            {
                comboBox3.Items.Add(i);
            }
            d = System.DateTime.Now.Year;
            for (int j = 1; j < 32; j++)
            {
                comboBox4.Items.Add(j);
            }
            for (int k = 1; k < 13; k++)
            {
                comboBox5.Items.Add(k);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false)
            {
                e.Handled = true;
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Age";
        }

        private void txtcontact_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your contact no.";
        }

        private void comqualification_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Qualification";
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(comboBox3.SelectedItem);
            int c = d - a;
            textBox7.Text = c.ToString();
        }
        string str2;
        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = textBox5.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                textBox5.Clear();
                inform.Text = "Düzgün Formatta Giriniz";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }
        
        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = textBox6.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                textBox6.Clear();
                inform.Text = "Düzgün Formatta Giriniz";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}