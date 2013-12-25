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

namespace AnaOkuluBilisim
{
    public partial class YemekList : Form
    {
        public YemekList()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);

        public void YemekListele()
        {
            DataTable dt = new DataTable();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Yemekler", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
            dataGridView1.Columns["YemekId"].Visible = false;
        }
        public void MailleriGetir()
        {
            DataTable dt = new DataTable();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Adi,Soyadi,EMail from Veliler", cnn);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            cnn.Close();
        }
        private void YemekList_Load(object sender, EventArgs e)
        {
            MailleriGetir();
            YemekListele();
        }
        private void btnYukle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_YemekYukle", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Corba", txtCorba.Text);
            cmd.Parameters.Add("@AnaYemek", txtAnaYemek.Text);
            cmd.Parameters.Add("@Tatli", txtTatli.Text);
            cmd.Parameters.Add("@Tarih", dateTimePicker1.Value);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Liste Eklendi.");
                
                 
                
                
            }
            catch(Exception err)
            {
                MessageBox.Show("Hata Oluştu.");
            }
            finally
            {
                cnn.Close();
                YemekListele();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Veri Yok");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Delete from Yemekler where YemekId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                YemekListele();
                MessageBox.Show("Liste Silindi.");
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in dataGridView2.Rows)
            {
                string a = rw.Cells["EMail"].Value.ToString();
                
                


                MailMessage mail = new MailMessage(); //
                mail.From = new MailAddress("m.ozbek01@gmail.com", "Ana Okulu"); //Mailin kimden gittiğini belirtiyoruz
                mail.To.Add(a); //Mailin kime gideceğini belirtiyoruz
                mail.Subject = "Yemek Listesi"; //Mail konusu          
                mail.Body =  "Tarih : " + dateTimePicker1.Text+"\n"+"Çorba : "+dataGridView1.CurrentRow.Cells["Corba"].Value.ToString() + "\nAna Yemek : " + dataGridView1.CurrentRow.Cells["AnaYemek"].Value.ToString() + "\nTatlı : " + dataGridView1.CurrentRow.Cells["Tatli"].Value.ToString(); //Mailin içeriği                  
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
