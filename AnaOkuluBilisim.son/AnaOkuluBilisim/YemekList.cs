using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class YemekList : Form
    {
        public YemekList()
        {
            InitializeComponent();
        }
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        public void YemekListele()
        {           
            dataGridView1.DataSource = client.TumYemekler(par.KullaniciAdi, par.Sifre, par.Departman);
            dataGridView1.Columns["AnaYemek"].DisplayIndex = 0;
            dataGridView1.Columns["Corba"].DisplayIndex = 1;
            dataGridView1.Columns["Tatli"].DisplayIndex = 2;
            dataGridView1.Columns["Tarih"].DisplayIndex = 3;
            dataGridView1.Columns["YemekId"].Visible = false;
        }
        public void MailleriGetir()
        { 
            dataGridView2.DataSource = client.VeliEmailler(par.KullaniciAdi, par.Sifre, par.Departman).Select(s=>new {Value=s}).ToList();
        }
        private void YemekList_Load(object sender, EventArgs e)
        {
            MailleriGetir();
            YemekListele();
        }
        private void btnYukle_Click(object sender, EventArgs e)
        {

            try
            {
                if (!client.YemekEkle(par.KullaniciAdi, par.Sifre, par.Departman, txtCorba.Text, txtAnaYemek.Text, txtTatli.Text, dateTimePicker1.Value.ToShortDateString()))
                    throw new Exception("Yemek Eklenemedi");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                YemekListele();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    throw new Exception("Veri Yok");
                if (client.YemekSil(par.KullaniciAdi, par.Sifre, par.Departman,Convert.ToInt32(dataGridView1.CurrentRow.Cells["YemekId"].Value) ))
                    MessageBox.Show("Liste Silindi.");
                else
                    throw new Exception("Yemek Silinemedi");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                YemekListele();
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow rw in dataGridView2.Rows)
            //{
            //    string a = rw.Cells["YemekId"].Value.ToString();
            //    MailMessage mail = new MailMessage(); //
            //    mail.From = new MailAddress("ilkerarslan49@gmail.com", "Ana Okulu"); //Mailin kimden gittiğini belirtiyoruz
            //    mail.To.Add(a); //Mailin kime gideceğini belirtiyoruz
            //    mail.Subject = "Yemek Listesi"; //Mail konusu          
            //    mail.Body = dataGridView1.CurrentRow.Cells[1].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "-" + dateTimePicker1.Text; //Mailin içeriği                  
            //    SmtpClient sc = new SmtpClient();
            //    sc.Port = 587;
            //    sc.Host = "smtp.gmail.com";
            //    sc.EnableSsl = true;
            //    sc.Credentials = new NetworkCredential("ilkerarslan49@gmail.com", "tezteztez");
            //    sc.Send(mail);
            //    MessageBox.Show("Mail Gönderildi.");
            //}
        }
    }
}
