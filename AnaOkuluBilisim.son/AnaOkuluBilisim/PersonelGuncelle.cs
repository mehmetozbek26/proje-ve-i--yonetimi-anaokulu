using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class PersonelGuncelle : Form
    {
        public PersonelKayit prskayit;
        private int id = 0;
        private AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        public PersonelGuncelle()
        {
            InitializeComponent();
        }
       
        private void PersonelGuncelle_Load(object sender, EventArgs e)
        {
            id = (int)prskayit.dataGridView1.CurrentRow.Cells["PersonelId"].Value;
            txtAd.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Adi"].Value.ToString() ;
            txtSoyad.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Soyadi"].Value;
            txtSicilNo.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["SicilNo"].Value;
            datebasvuru.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["BasvuruTarihi"].Value;
            datebaslama.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["BaslamaTarihi"].Value;
            var askerlik = (String)prskayit.dataGridView1.CurrentRow.Cells["AskerlikDurumu"].Value;
            for (int i = 0; i < cmbAskerlikDurumu.Items.Count; i++)
                if (cmbAskerlikDurumu.Items[i].ToString() == askerlik)
                    cmbAskerlikDurumu.SelectedIndex = i;
           
            txtTecilBitisYili.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["TecilBitisYili"].Value;
            var kan = (String)prskayit.dataGridView1.CurrentRow.Cells["KanGrubu"].Value;
            for (int i = 0; i < cmbKanGrubu.Items.Count; i++)
                if (cmbKanGrubu.Items[i].ToString() == kan)
                    cmbKanGrubu.SelectedIndex = i;
            var cin = (String)prskayit.dataGridView1.CurrentRow.Cells["Cinsiyet"].Value;
            for (int i = 0; i < cmbCinsiyet.Items.Count; i++)
                if (cmbCinsiyet.Items[i].ToString() == cin)
                    cmbCinsiyet.SelectedIndex = i;        
            txtAdres.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Adres"].Value;
            txtSemt.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Semt"].Value;
            txtilce.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Ilce"].Value;
            txtil.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["il"].Value;
            txtMail.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Mail"].Value;
            txtEvTel.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["EvTel"].Value;
            txtCepTel.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["CepTel"].Value;
            var ogr = (String)prskayit.dataGridView1.CurrentRow.Cells["EgitimDurumu"].Value;
            for (int i = 0; i < cmbOgrenimDurumu.Items.Count; i++)
                if (cmbOgrenimDurumu.Items[i].ToString() == ogr)
                    cmbOgrenimDurumu.SelectedIndex = i;  
            
            
            txtTcNo.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["TcNo"].Value;
            var dep = (String)prskayit.dataGridView1.CurrentRow.Cells["Departman"].Value;
            for (int i = 0; i < cmbDepartman.Items.Count; i++)
                if (cmbDepartman.Items[i].ToString() == dep)
                    cmbDepartman.SelectedIndex = i;
            var uy = (String)prskayit.dataGridView1.CurrentRow.Cells["Kuyruk"].Value;
            for (int i = 0; i < cmbUyruk.Items.Count; i++)
                if (cmbUyruk.Items[i].ToString() == uy)
                    cmbUyruk.SelectedIndex = i; 
           txtKimlikSeriNo.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["KkimlikSeriNo"].Value;
            txtDogumYeri.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["KdogumYeri"].Value;
            datedogum.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["KdogumTarihi"].Value;
           txtKimlikil.Text= (String)prskayit.dataGridView1.CurrentRow.Cells["il"].Value;
            txtKimlikilce.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Ilce"].Value;
            txtMahalle.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Kmahalle"].Value;
           txtKoy.Text= (String)prskayit.dataGridView1.CurrentRow.Cells["Kkoy"].Value;
           txtCilt.Text= (String)prskayit.dataGridView1.CurrentRow.Cells["Kcilt"].Value;
           txtAile.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["Kaile"].Value;
           txtSiraNo.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["KSiraNo"].Value;
           txtVerYeri.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["KVerilisYeri"].Value;
           txtKayitNo.Text = (String)prskayit.dataGridView1.CurrentRow.Cells["KKayitNo"].Value;
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PersonellerDB per=new PersonellerDB
                {
                    Adi = txtAd.Text.ToUpper(),
                    Soyadi = txtSoyad.Text.ToUpper(),
                    SicilNo = txtSicilNo.Text.ToUpper(),
                    TcNo = txtTcNo.Text.ToUpper(),
                    BasvuruTarihi = datebasvuru.Value,
                    BaslamaTarihi = datebaslama.Value,
                    Departman = cmbDepartman.SelectedItem.ToString(),
                    AskerlikDurumu = cmbAskerlikDurumu.SelectedItem.ToString(),
                    TecilBitisYili = txtTecilBitisYili.Text.ToUpper(),
                    KanGrubu = cmbKanGrubu.SelectedItem.ToString(),
                    Cinsiyet = cmbCinsiyet.SelectedItem.ToString(),
                    Adres = txtAdres.Text.ToUpper(),
                    Semt = txtSemt.Text.ToUpper(),
                    Ilce = txtilce.Text.ToUpper(),
                    il = txtil.Text.ToUpper(),
                    Mail = txtMail.Text,
                    EvTel = txtEvTel.Text.ToUpper(),
                    CepTel = txtCepTel.Text.ToUpper(),
                    EgitimDurumu = cmbOgrenimDurumu.SelectedItem.ToString(),
                    Durumu = cmbKayitDurumu.SelectedItem.ToString(),
                    Kuyruk = cmbUyruk.SelectedItem.ToString(),
                    KkimlikSeriNo = txtKimlikSeriNo.Text.ToUpper(),
                    KdogumYeri = txtDogumYeri.Text.ToUpper(),
                    KdogumTarihi = datedogum.Value,
                    Kdogumili = txtKimlikil.Text.ToUpper(),
                    Kdogumilce = txtKimlikilce.Text.ToUpper(),
                    Kmahalle = txtMahalle.Text.ToUpper(),
                    Kkoy = txtKoy.Text.ToUpper(),
                    Kcilt = txtCilt.Text.ToUpper(),
                    Kaile = txtAile.Text.ToUpper(),
                    KSiraNo = txtSiraNo.Text.ToUpper(),
                    KVerilisYeri = txtVerYeri.Text.ToUpper(),
                    KKayitNo = txtKayitNo.Text.ToUpper(),
                    PersonelId = id
                };
                if (client.PersonelGuncelle(par.KullaniciAdi, par.Sifre, par.Departman, per))
                    MessageBox.Show("Personel Güncellendi");
                else
                    MessageBox.Show("Personel Güncellenemedi");
            }
            catch (Exception err)
            {

            }

        }

        private void cmbAskerlikDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAskerlikDurumu.SelectedText == "Tecilli")
            {
                label8.Text = "Tecil Bitiş YIlı";
                txtTecilBitisYili.Enabled = true;
            }
            else if (cmbAskerlikDurumu.SelectedText == "Yapıldı")
            {
                label8.Text = "Yapılış Tarihi";
                txtTecilBitisYili.Enabled = true;
            }
            else
            {
                label8.Text = "Tecil Bitiş YIlı";
                txtTecilBitisYili.Enabled = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                textBox1.Text = txtTcNo.Text;


            }
        }
        
    }
}
