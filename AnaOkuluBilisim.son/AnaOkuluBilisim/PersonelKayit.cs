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
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;


namespace AnaOkuluBilisim
{
    
    public partial class PersonelKayit : Form
    {
        public PersonelGuncelle prsguncelle;
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        public PersonelKayit()
        {
            InitializeComponent();        
            prsguncelle = new PersonelGuncelle();
            prsguncelle.prskayit = this;    
        }
        bool kimlikbilgileri = true; 
        private void PersonelKayit_Load(object sender, EventArgs e)
        {               
            PersonelGetir();
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(client.PersonelKayit(par.KullaniciAdi,par.Sifre,par.Departman,new PersonellerDB{
                    Adi=txtAd.Text.ToUpper(),
                    Soyadi=txtSoyad.Text.ToUpper(),
                    SicilNo=txtSicilNo.Text.ToUpper(),
                    TcNo=txtTcNo.Text.ToUpper(),
                    BasvuruTarihi=basvurutarih.Value,
                    BaslamaTarihi=baslamatarih.Value,
                    Departman = cmbDepartman.SelectedItem.ToString(),
                    AskerlikDurumu=cmbAskerlikDurumu.SelectedItem.ToString(),
                    TecilBitisYili=txtTecilBitisYili.Text.ToUpper(),
                    KanGrubu=cmbKanGrubu.SelectedItem.ToString(),
                    Cinsiyet=cmbCinsiyet.SelectedItem.ToString(),
                    Adres=txtAdres.Text.ToUpper(),
                    Semt=txtSemt.Text.ToUpper(),
                    Ilce=txtilce.Text.ToUpper(),
                    il=txtil.Text.ToUpper(),
                    Mail=txtMail.Text,
                    EvTel=txtEvTel.Text.ToUpper(),
                    CepTel=txtCepTel.Text.ToUpper(),
                    EgitimDurumu=cmbOgrenimDurumu.SelectedItem.ToString(),
                    Durumu=cmbKayitDurumu.SelectedItem.ToString(),
                    Kuyruk=cmbUyruk.SelectedItem.ToString(),
                    KkimlikSeriNo=txtKimlikSeriNo.Text.ToUpper(),
                    KdogumYeri=txtDogumYeri.Text.ToUpper(),
                    KdogumTarihi=datedogumtarihi.Value,
                    Kdogumili=txtKimlikil.Text.ToUpper(),
                    Kdogumilce=txtKimlikilce.Text.ToUpper(),
                    Kmahalle=txtMahalle.Text.ToUpper(),
                    Kkoy=txtKoy.Text.ToUpper(),
                    Kcilt=txtCilt.Text.ToUpper(),
                    Kaile=txtAile.Text.ToUpper(),
                    KSiraNo=txtSiraNo.Text.ToUpper(),
                    KVerilisYeri=txtVerYeri.Text.ToUpper(),
                    KKayitNo=txtKayitNo.Text.ToUpper()
                }))
                    MessageBox.Show("Personel Kaydedildi");
                else
                    MessageBox.Show("Personel Kaydedilemedi");
                PersonelGetir();


            }
            catch (Exception err)
            {


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
            try
            {
                var item = client.TumPersoneller();
                if (item.Length > 0)
                {
                    dataGridView1.DataSource = item;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        dataGridView1.Columns[i].Visible = false;
                    dataGridView1.Columns["Adi"].DisplayIndex = 0;
                    dataGridView1.Columns["Soyadi"].DisplayIndex = 1;
                    dataGridView1.Columns["Mail"].DisplayIndex = 2;
                    dataGridView1.Columns["Adi"].Visible = true;
                    dataGridView1.Columns["Soyadi"].Visible = true;
                    dataGridView1.Columns["Mail"].Visible = true;
                }

            }
            catch (Exception err)
            {

            }

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
                if (client.PersonelSil(par.KullaniciAdi, par.Sifre, par.Departman, Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonelId"].Value)))
                    MessageBox.Show("Personel Kayıt Silindi");
                else
                    MessageBox.Show("Personel Kayıt Silinemedi");
                    PersonelGetir();




            }
            catch (Exception err)
            {



            }
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                textBox1.Text = txtTcNo.Text;
               

            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDogumYeri_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbAskerlikDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAskerlikDurumu.SelectedText == "Tecilli")
            {
                label8.Text="Tecil Bitiş YIlı";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}