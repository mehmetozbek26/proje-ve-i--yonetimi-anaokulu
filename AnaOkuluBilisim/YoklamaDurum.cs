using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class YoklamaDurum : Form
    {
        public YoklamaDurum()
        {
            InitializeComponent();
        }
        Parola par = Parola.GET();
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        IList<SiniflarDB> sinif;

        private void YoklamaDurum_Load(object sender, EventArgs e)
        {
            try
            {
                sinif = client.TumSiniflar(par.KullaniciAdi, par.Sifre, par.Departman);
                cmbSinif.Items.Clear();
                foreach (var item in sinif)
                {
                    cmbSinif.Items.Add(item.sinifAdi);
                }
            }
            catch (Exception err)
            {

            }
        }
         private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (client.TumYoklamaById(par.KullaniciAdi, par.Sifre, par.Departman, sinif[cmbSinif.SelectedIndex].sinifId).Length > 0)
                {
                    dataGridView1.DataSource = client.TumYoklamaById(par.KullaniciAdi, par.Sifre, par.Departman, sinif[cmbSinif.SelectedIndex].sinifId);
                    dataGridView1.Columns["VELIADI"].DisplayIndex = 0;
                    dataGridView1.Columns["VELISOYADI"].DisplayIndex = 1;
                    dataGridView1.Columns["VELIEMAIL"].DisplayIndex = 2;
                    dataGridView1.Columns["OGRENCIADI"].DisplayIndex = 3;
                    dataGridView1.Columns["OGRENCISOYADI"].DisplayIndex = 4;
                    dataGridView1.Columns["TARIH"].DisplayIndex = 5;
                    dataGridView1.Columns["VELIEMAIL"].DisplayIndex = 6;
                    dataGridView1.Columns["DEVAMSIZLIK"].DisplayIndex = 7;
                    dataGridView1.Columns["ACIKLAMA"].DisplayIndex = 8;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["SinifId"].Visible = false;
                    dataGridView1.Columns["VeliId"].Visible = false;
                    dataGridView1.Columns["OgrenciId"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Sınıf Kayıt Yok");
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception err)
            {

            }
        }

         private void btnYoklamaDurum_Click(object sender, EventArgs e)
         {
             foreach (DataGridViewRow rw in dataGridView1.Rows)
             {
                 string a = rw.Cells[11].Value.ToString();
                 MailMessage mail = new MailMessage(); //
                 mail.From = new MailAddress("cengmahmutay@gmail.com", "Ana Okulu"); //Mailin kimden gittiğini belirtiyoruz
                 mail.To.Add(a); //Mailin kime gideceğini belirtiyoruz
                 mail.Subject = "Yemek Listesi"; //Mail konusu          
                 mail.Body = dataGridView1.CurrentRow.Cells[1].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[6].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[7].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[8].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[9].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[10].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[11].Value.ToString() + "-" + dataGridView1.CurrentRow.Cells[12].Value.ToString(); //Mailin içeriği                  
                 SmtpClient sc = new SmtpClient();
                 sc.Port = 587;
                 sc.Host = "smtp.gmail.com";
                 sc.EnableSsl = true;
                 sc.Credentials = new NetworkCredential("cengmahmutay@gmail.com", "eeeeeeeeeee");
                 sc.Send(mail);
                 MessageBox.Show("Mail Gönderildi.");
             }
         }
    }
}
