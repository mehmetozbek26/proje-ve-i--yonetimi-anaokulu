using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    
    public partial class PersonelKayit : Form
    {
        public PersonelGuncelle prsguncelle;    
        public PersonelKayit()
        {
            InitializeComponent();
           
             prsguncelle = new PersonelGuncelle();
            prsguncelle.prskayit = this;    
        }
        bool kimlikbilgileri = true;
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");  
        private void PersonelKayit_Load(object sender, EventArgs e)
        { 
               

            PersonelGetir();
           
            cmbDepartman.Items.Add("Yönetim");
            cmbDepartman.Items.Add("Muhasebe");
            cmbDepartman.Items.Add("Banko");
            cmbDepartman.Items.Add("Öğretmen");
            cmbCinsiyet.Items.Add("ERKEK");
            cmbCinsiyet.Items.Add("KIZ");
            cmbKanGrubu.Items.Add("A rh(+)");
            cmbKanGrubu.Items.Add("A rh(-)");
            cmbKanGrubu.Items.Add("0 rh(+)");
            cmbKanGrubu.Items.Add("A rh(-)");
            cmbKanGrubu.Items.Add("B rh(+)");
            cmbKanGrubu.Items.Add("B rh(-)");
            cmbKanGrubu.Items.Add("AB rh(+)");
            cmbKanGrubu.Items.Add("AB rh(-)");
            cmbAskerlikDurumu.Items.Add("Yapıldı");
            cmbAskerlikDurumu.Items.Add("Yapılmadı");
            cmbAskerlikDurumu.Items.Add("Tecilli");
            cmbOgrenimDurumu.Items.Add("Lise");
            cmbOgrenimDurumu.Items.Add("ÖnLisans");
            cmbOgrenimDurumu.Items.Add("YüksekLisans");
            cmbKayitDurumu.Items.Add("Çalışıyor");
            cmbKayitDurumu.Items.Add("Çalışmıyor");
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            if (kimlikbilgileri)
            {
                tabControl1.SelectedIndex = 1;
                kimlikbilgileri = false;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("sp_PersonelEkle", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Adis", txtAd.Text);
                cmd.Parameters.Add("@SoyAdis", txtSoyad.Text);
                cmd.Parameters.Add("@SicilNos", txtSicilNo.Text);
                cmd.Parameters.Add("@BasvuruTarihis", dateTimePicker1.Value);
                cmd.Parameters.Add("@BaslamaTarihis", dateTimePicker2.Value);
                cmd.Parameters.Add("@AskerlikDurumus", cmbAskerlikDurumu.Text);
                cmd.Parameters.Add("@TecilBitisYilis", txtTecilBitisYili.Text);
                cmd.Parameters.Add("@Kangrubus", cmbKanGrubu.Text);
                cmd.Parameters.Add("@Cinsiyets", cmbCinsiyet.Text);
                cmd.Parameters.Add("@Adress", txtAdres.Text);
                cmd.Parameters.Add("@Semts", txtSemt.Text);
                cmd.Parameters.Add("@Ilces", txtilce.Text);
                cmd.Parameters.Add("@ils", txtil.Text);
                cmd.Parameters.Add("@Mails", txtMail.Text);
                cmd.Parameters.Add("@EvTels", txtEvTel.Text);
                cmd.Parameters.Add("@CepTels", txtCepTel.Text);
                cmd.Parameters.Add("@EgitimDurumus", cmbOgrenimDurumu.Text);
                cmd.Parameters.Add("@AyrilisTarihis", txtAyrilisTarihi.Text);
                cmd.Parameters.Add("@TcNos", txtTcNo.Text);
                cmd.Parameters.Add("@Departmans", cmbDepartman.Text);

                cmd.Parameters.Add("@KTcNos", textBox1.Text);
                cmd.Parameters.Add("@KUyruks", txtUyruk.Text);
                cmd.Parameters.Add("@KCinsiyets", comboBox1.Text);
                cmd.Parameters.Add("@KKimlikSeriNos", txtKimlikSeriNo.Text);
                cmd.Parameters.Add("@KDogumYeris", txtDogumYeri.Text);
                cmd.Parameters.Add("@KDogumTarihis", dateTimePicker3.Value);
                cmd.Parameters.Add("@KDogumilis", txtKimlikil.Text);
                cmd.Parameters.Add("@KDogumilces", txtKimlikilce.Text);
                cmd.Parameters.Add("@KMahalles", txtMahalle.Text);
                cmd.Parameters.Add("@KKoys", txtKoy.Text);
                cmd.Parameters.Add("@KCilts", txtCilt.Text);
                cmd.Parameters.Add("@KAiles", txtAile.Text);
                cmd.Parameters.Add("@KSiraNos", txtSiraNo.Text);
                cmd.Parameters.Add("@KVerilisYeris", txtVerYeri.Text);
                cmd.Parameters.Add("@KKayitNos", txtKayitNo.Text);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Eklendi.");
                    kimlikbilgileri = true;

                }
                catch
                { MessageBox.Show("Hata Oluştu"); }
                finally
                {
                    cnn.Close();
                    DataTable tablo = new DataTable();
                    tablo.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Personeller", cnn);
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
        }
        public void ClearTextBoxes(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TextBox)
                {
                    (child as TextBox).Text = "";
                }
                else
                {
                    ClearTextBoxes(child);
                }
            }
        }
        public void PersonelGetir()
        {
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personeller", cnn);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Refresh();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(panel1);
        }
        
        private void btnDuzenle_Click(object sender, EventArgs e)
        {

            prsguncelle = new PersonelGuncelle();
            prsguncelle.prskayit = this;    
            prsguncelle.ShowDialog();       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "Delete from Personeller where PersonelId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";            
            cmd.ExecuteNonQuery();
            cnn.Close();
            PersonelGetir();
            MessageBox.Show("Kayıt Silindi.");
        }

      
    }
}