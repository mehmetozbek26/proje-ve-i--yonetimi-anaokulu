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
using System.Configuration;

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
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);  
        private void PersonelKayit_Load(object sender, EventArgs e)
        { 
               

            PersonelGetir();



        }   
        private void button1_Click(object sender, EventArgs e)
        {         
            SqlCommand cmd = new SqlCommand("sp_PersonelEkle", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Adis", txtAd.Text);
            cmd.Parameters.Add("@SoyAdis", txtSoyad.Text);
            cmd.Parameters.Add("@SicilNos", txtSicilNo.Text);
            cmd.Parameters.Add("@BasvuruTarihis", txtBasvuruTarihi.Value);
            cmd.Parameters.Add("@BaslamaTarihis", txtBaslamaTarihi.Value);
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
            cmd.Parameters.Add("@TcNos", txtTcNo.Text);
            cmd.Parameters.Add("@Departmans", cmbDepartman.Text);
            cmd.Parameters.Add("@Kuyruks", txtUyruk.Text);
            cmd.Parameters.Add("@Kcinsiyets", comboBox1.Text);
            cmd.Parameters.Add("@KkimlikSeriNos", txtKimlikSeriNo.Text);
            cmd.Parameters.Add("@KdogumYeris", txtDogumYeri.Text);
            cmd.Parameters.Add("@KdogumTarihis", txtDogumTarihi.Value);
            cmd.Parameters.Add("@Kdogumilis", txtKimlikil.Text);
            cmd.Parameters.Add("@Kdogumilces", txtKimlikilce.Text);
            cmd.Parameters.Add("@Kmahalles", txtMahalle.Text);
            cmd.Parameters.Add("@Kkoys", txtKoy.Text);
            cmd.Parameters.Add("@Kcilts", txtCilt.Text);
            cmd.Parameters.Add("@Kailes", txtAile.Text);
            cmd.Parameters.Add("@KSiraNos", txtSiraNo.Text);
            cmd.Parameters.Add("@KVerilisYeris", txtVerYeri.Text);
            cmd.Parameters.Add("@KKayitNos", txtKayitNo.Text);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi.");

            }
            catch(Exception err)
            { 
                MessageBox.Show("Hata Oluştu"); 
            }
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
            dataGridView1.Columns["PersonelId"].Visible = true;
            dataGridView1.Columns["SicilNo"].Visible = false;
            dataGridView1.Columns["TcNo"].Visible = false;
            dataGridView1.Columns["BasvuruTarihi"].Visible = false;
            dataGridView1.Columns["BaslamaTarihi"].Visible = false;
            dataGridView1.Columns["AskerlikDurumu"].Visible = false;
            dataGridView1.Columns["TecilBitisYili"].Visible = false;
            dataGridView1.Columns["KanGrubu"].Visible = false;
            dataGridView1.Columns["Cinsiyet"].Visible = false;
            dataGridView1.Columns["Semt"].Visible = false;
            dataGridView1.Columns["Adres"].Visible = false;
            dataGridView1.Columns["Semt"].Visible = false;
            dataGridView1.Columns["Ilce"].Visible = false;
            dataGridView1.Columns["il"].Visible = false;
            dataGridView1.Columns["BaslamaTarihi"].Visible = false;
            dataGridView1.Columns["Mail"].Visible = false;
            dataGridView1.Columns["EvTel"].Visible = false;
            dataGridView1.Columns["CepTel"].Visible = false;
            dataGridView1.Columns["EgitimDurumu"].Visible = false;
            dataGridView1.Columns["Durumu"].Visible = false;
            dataGridView1.Columns["Kuyruk"].Visible = false;
            dataGridView1.Columns["KkimlikSeriNo"].Visible = false;
            dataGridView1.Columns["KdogumYeri"].Visible = false;
            dataGridView1.Columns["KdogumTarihi"].Visible = false;
            dataGridView1.Columns["Kdogumili"].Visible = false;
            dataGridView1.Columns["Kdogumilce"].Visible = false;
            dataGridView1.Columns["Kmahalle"].Visible = false;
            dataGridView1.Columns["Kkoy"].Visible = false;
            dataGridView1.Columns["Kcilt"].Visible = false;
            dataGridView1.Columns["Kaile"].Visible = false;
            dataGridView1.Columns["KSiraNo"].Visible = false;
            dataGridView1.Columns["KVerilisYeri"].Visible = false;
            dataGridView1.Columns["KKayitNo"].Visible = false;
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
            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "Delete from Personeller where PersonelId='" + dataGridView1.CurrentRow.Cells["PersonelId"].Value.ToString() + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                PersonelGetir();
                MessageBox.Show("Kayıt Silindi.");
            }
            catch(Exception err){
                MessageBox.Show("hata olustu.");

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                textBox1.Text = txtTcNo.Text;
                comboBox1.SelectedIndex = cmbCinsiyet.SelectedIndex;
            }
        }

        private void cmbAskerlikDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAskerlikDurumu.SelectedIndex==0)
                txtTecilBitisYili.Enabled = false;
            else
                txtTecilBitisYili.Enabled = true;

            if (cmbCinsiyet.SelectedIndex == 0)
            {
                cmbAskerlikDurumu.Enabled = false;
                txtTecilBitisYili.Enabled = false;
                
            }
            else
            {
                cmbAskerlikDurumu.Enabled = true;
                txtTecilBitisYili.Enabled = true;
                
            }
        }

        private void txtSemt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}