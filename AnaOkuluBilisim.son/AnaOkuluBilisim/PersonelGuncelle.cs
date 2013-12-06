using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AnaOkuluBilisim
{
    public partial class PersonelGuncelle : Form
    {
        public PersonelKayit prskayit;

        public PersonelGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        private void PersonelGuncelle_Load(object sender, EventArgs e)
        {          
            txtAd.Text = prskayit.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = prskayit.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSicilNo.Text = prskayit.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = prskayit.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker2.Text = prskayit.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbAskerlikDurumu.Text = prskayit.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtTecilBitisYili.Text = prskayit.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cmbKanGrubu.Text = prskayit.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cmbCinsiyet.Text = prskayit.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtAdres.Text = prskayit.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtSemt.Text = prskayit.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtilce.Text = prskayit.dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtil.Text = prskayit.dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtMail.Text = prskayit.dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txtEvTel.Text = prskayit.dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txtCepTel.Text = prskayit.dataGridView1.CurrentRow.Cells[16].Value.ToString();
            cmbOgrenimDurumu.Text = prskayit.dataGridView1.CurrentRow.Cells[17].Value.ToString();
            txtAyrilisTarihi.Text = prskayit.dataGridView1.CurrentRow.Cells[18].Value.ToString();
            txtTcNo.Text = prskayit.dataGridView1.CurrentRow.Cells[19].Value.ToString();
            cmbDepartman.Text = prskayit.dataGridView1.CurrentRow.Cells[20].Value.ToString();

            textBox1.Text = prskayit.dataGridView1.CurrentRow.Cells[21].Value.ToString();
            txtUyruk.Text = prskayit.dataGridView1.CurrentRow.Cells[22].Value.ToString();
           comboBox1.Text  = prskayit.dataGridView1.CurrentRow.Cells[23].Value.ToString();
           txtKimlikSeriNo.Text = prskayit.dataGridView1.CurrentRow.Cells[24].Value.ToString();
            txtDogumYeri.Text = prskayit.dataGridView1.CurrentRow.Cells[25].Value.ToString();
         txtDogumTarihi.Text= prskayit.dataGridView1.CurrentRow.Cells[26].Value.ToString();
           txtKimlikil.Text= prskayit.dataGridView1.CurrentRow.Cells[27].Value.ToString();
            txtKimlikilce.Text = prskayit.dataGridView1.CurrentRow.Cells[28].Value.ToString();
        txtMahalle.Text = prskayit.dataGridView1.CurrentRow.Cells[29].Value.ToString();
           txtKoy.Text= prskayit.dataGridView1.CurrentRow.Cells[30].Value.ToString();
           txtCilt.Text= prskayit.dataGridView1.CurrentRow.Cells[31].Value.ToString();
           txtAile.Text = prskayit.dataGridView1.CurrentRow.Cells[32].Value.ToString();
           txtSiraNo.Text = prskayit.dataGridView1.CurrentRow.Cells[33].Value.ToString();
           txtVerYeri.Text = prskayit.dataGridView1.CurrentRow.Cells[34].Value.ToString();
            txtKayitNo.Text = prskayit.dataGridView1.CurrentRow.Cells[35].Value.ToString();
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("buton calisti.");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("update Personeller set Adi='" + txtAd.Text + "',SoyAdi='" + txtSoyad.Text + "',SicilNo='" + txtSicilNo.Text + "',IsBasvuruTarihi='" + dateTimePicker1.Value.ToShortDateString() + "',IseBaslamaTarihi='" + dateTimePicker2.Value.ToShortDateString() + "',AskerlikDurumu='" + cmbAskerlikDurumu.Text + "',TecilBitisYili='" + txtTecilBitisYili.Text + "',KanGrubu='" + cmbKanGrubu.Text + "',Cinsiyet='" + cmbCinsiyet.Text + "',Adres='" + txtAdres.Text + "',Semt='" + txtSemt.Text + "',Ilce='" + txtilce.Text + "',Il='" + txtil.Text + "',Mail='" + txtMail.Text + "',EvTel='" + txtEvTel.Text + "',CepTel='" + txtCepTel.Text + "',EgitimDurumu='" + cmbOgrenimDurumu.Text + "',AyrilisTarihi='" + txtAyrilisTarihi.Text + "',TcNo='" + txtTcNo.Text + "',Departman='" + cmbDepartman.Text + "',KTcNo='" + textBox1.Text + "',KUyruk='" + txtUyruk.Text + "',KCinsiyet='" + comboBox1.Text + "',KKimlikSeriNo='" + txtKimlikSeriNo.Text + "',KDogumYeri='" + txtDogumYeri.Text + "',KDogumTarihi='" + txtDogumTarihi.Text + "',KDogumili='" + txtKimlikil.Text + "',KDogumilce='" + txtKimlikilce.Text + "',KMahalle='" + txtMahalle.Text + "',KKoy='" + txtKoy.Text + "',KCilt='" + txtCilt.Text + "',KAile='" + txtAile.Text + "',KSiraNo='" + txtSiraNo.Text + "',KVerilisYeri='" + txtVerYeri.Text + "',KKayitNo='" + txtKayitNo.Text + "'", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            prskayit.PersonelGetir();
            MessageBox.Show("Güncelleme gerçekleşti.");
            this.Close();

        }
        
    }
}
