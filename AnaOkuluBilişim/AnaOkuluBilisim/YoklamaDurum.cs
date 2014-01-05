using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class YoklamaDurum : Form
    {
        public YoklamaDurum()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        IList<Sinif> siniflar = new List<Sinif>();
        private void YoklamaDurum_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", cnn))
            {

                cnn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                siniflar.Clear();
                while (rdr.Read())
                {
                    var oid = rdr["ögretmenId"].ToString();
                    var kap = rdr["sinifkapasite"].ToString();
                    siniflar.Add(new Sinif
                    {
                        OgretmenID = oid,
                        SinifAdi = rdr["sinifAdi"].ToString(),
                        SinifID = Convert.ToInt32(rdr["sinifId"].ToString()),
                        SinifKapasite = kap
                    });
                    cmbDurum.Items.Add(rdr["sinifAdi"].ToString());
                }
                cnn.Close();

            }
        }
         private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT o.Adi as OgreciAdi,o.Soyadi as OgreciSoyadi,v.Adi as VeliAdi,v.Soyadi as VeliSoyadi,og.Adi as OgretmenAdi,og.Soyadi as OgretmenSoyadi,y.Tarih,s.sinifAdi,y.DevamsizlikTuru,y.Aciklama,v.Email from Ogrenciler o,Siniflar s,Yoklama y,Veliler v,Ogretmenler og where y.SinifId=@id and y.SinifId=s.sinifId and y.OgrenciId=o.OgrenciId and v.OgrenciId=y.OgrenciId and s.ögretmenId=og.KayitId", cnn))
                {
                    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = siniflar[cmbDurum.SelectedIndex].SinifID;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
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
                 string a = rw.Cells["Email"].Value.ToString();
                 MailMessage mail = new MailMessage(); //
                 mail.From = new MailAddress("m.ozbek01@gmail.com", "Ana Okulu");//Mailin kimden gittiğini belirtiyoruz
                 mail.To.Add(a); //Mailin kime gideceğini belirtiyoruz
                 mail.Subject = "Yoklama"; //Mail konusu          
                 mail.Body = "Tarih : " + Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Tarih"].Value.ToString()).ToShortDateString() + "\n" +
                     "Sayın " + dataGridView1.CurrentRow.Cells["VeliAdi"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["VeliAdi"].Value.ToString() + "\n" +
                     "Öğrencimiz " + dataGridView1.CurrentRow.Cells["OgreciAdi"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["OgreciSoyadi"].Value.ToString() +
                     " Bugün Okula " + dataGridView1.CurrentRow.Cells["DevamsizlikTuru"].Value.ToString() + "\nAçıklama : " + dataGridView1.CurrentRow.Cells["Aciklama"].Value.ToString();
                 SmtpClient sc = new SmtpClient();
                 sc.Port = 587;
                 sc.Host = "smtp.gmail.com";
                 sc.EnableSsl = true;
                 sc.Credentials = new NetworkCredential("m.ozbek01@gmail.com", "mehmet2473378");
                 sc.Send(mail);
                 MessageBox.Show("Mail Gönderildi.");
             }
         }
    }
}
