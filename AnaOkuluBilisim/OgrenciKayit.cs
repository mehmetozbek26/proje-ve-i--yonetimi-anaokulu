using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;


namespace AnaOkuluBilisim
{
    public partial class OgrenciKayit : Form
    {
        public Giris frm1;
        double x, y, fx, fy, oranx, orany;
        Parola par=Parola.GET();
        AnaOkuluWebServiceClient client=new AnaOkuluWebServiceClient();
        IList<SiniflarDB> sinif;
        IList<ServislerDB> servis;
        public OgrenciKayit()
            
        { 
        
            InitializeComponent();
        }
        string resimPath=null;
        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            try
            {
                sinif = client.TumSiniflar(par.KullaniciAdi, par.Sifre, par.Departman);
                cmbSinif.Items.Clear();
                foreach (var item in sinif)
                {
                    cmbSinif.Items.Add(item.sinifAdi);
                }
               servis = client.TumServisler(par.KullaniciAdi, par.Sifre, par.Departman);
                cmbServis.Items.Clear();
                foreach (var item in servis)
                {
                    cmbServis.Items.Add(item.AD);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                x = Screen.PrimaryScreen.Bounds.Width;
                y = Screen.PrimaryScreen.Bounds.Height;
                fx = this.Width;
                fy = this.Height;
                oranx = Math.Round(1920 / x, 2);
                orany = Math.Round(1080 / y, 2);
                this.Width = Convert.ToInt32(1292 / oranx);
                this.Height = Convert.ToInt32(756 / orany);
                txtOgrenciAd.Width = Convert.ToInt32(417 / oranx);
            }
            catch (Exception err)
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";
            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                textBox17.Text = openFileDialog1.FileName;
                lblDosyaAdi.Text = openFileDialog1.SafeFileName;
                resimPath = openFileDialog1.FileName.ToString();
            }
        }
        private void btnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            int ogrid = 0;
            try
            {
                if (txtOgrenciAd.Text == "") throw new Exception("Öğrenci Adı Giriniz.");
                if (txtOgrenciSoyad.Text == "") throw new Exception("Öğrenci Soyadı Giriniz.");
                if (txtOgrenciAdres.Text == "") throw new Exception("Adres Giriniz.");
                if (txtSemt.Text == "") throw new Exception("Semt Giriniz.");
                if (txtIlce.Text == "") throw new Exception("İlçe Giriniz.");
                if (txtil.Text == "") throw new Exception("İl Giriniz.");
                if (txtPostaKodu.Text == "") throw new Exception("Posta Kodu Giriniz.");
                if (txtEvTel.Text == "") throw new Exception("Ev Telofon Bilgilerini Giriniz.");
                if (comboBox1.SelectedIndex < 0) throw new Exception("Uyruk Giriniz.");
                if (txtTcNo.Text == "") throw new Exception("Tc No Giriniz.");
                if (txtKimlikSeriNo.Text == "") throw new Exception("Seri No Giriniz.");
                if (txtDogumYeri.Text == "") throw new Exception("Doğum Yeri Giriniz.");
                if (txtKimlikil.Text == "") throw new Exception("Kimlik Bilg. İl Giriniz.");
                if (txtKimlikilce.Text == "") throw new Exception("Kimlik Bilg. İlçe Giriniz.");
                if (txtMahalle.Text == "") throw new Exception("Mahalle Giriniz.");
                if (txtKoy.Text == "") throw new Exception("Köy Giriniz.");
                if (txtCilt.Text == "") throw new Exception("Cilt Bilg. Giriniz.");
                if (txtAile.Text == "") throw new Exception("Kimlik Bilg. Aile Girniz.");
                if (txtSiraNo.Text == "") throw new Exception("Kimlik Bilg.Sıra No Giriniz.");
                if (txtVerYeri.Text == "") throw new Exception("Kimlik Bilg. Veriliş Yeri Giriniz.");
                if (txtKayitNo.Text == "") throw new Exception("Kimlik Bilg. Kayıt No Giriniz."); 
                if (resimPath == null) throw new Exception("Resim Seçiniz");
                FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                ogrid = client.OgrenciEkle(par.KullaniciAdi, par.Sifre, par.Departman, new OgrencilerDB
                {
                    Adi = txtOgrenciAd.Text.ToUpper(),
                    Adres = txtOgrenciAdres.Text.ToUpper(),
                    Aile = txtAile.Text.ToUpper(),
                    Alerjiler = textBox3.Text.ToUpper(),
                    Ameliyatlar = textBox4.Text.ToUpper(),
                    Asilar = textBox9.Text.ToUpper(),
                    Cilt = txtCilt.Text.ToUpper(),
                    Cinsiyet = cmbCinsiyet.SelectedText,
                    DavranisSorunu = txtDavranisSorunlari.Text.ToUpper(),
                    Diyet = txtDiyet.Text.ToUpper(),
                    Dogumilce = txtKimlikilce.Text.ToUpper(),
                    Dogumili = txtKimlikil.Text.ToUpper(),
                    DogumTarihi = dateTimePicker1.Value,
                    DogumYeri = txtDogumYeri.Text.ToUpper(),
                    EvTel = txtEvTel.Text.ToUpper(),
                    Fobileri = txtFobileri.Text.ToUpper(),
                    GecirdigiHastaliklar = textBox1.Text.ToUpper(),
                    Soyadi = txtOgrenciSoyad.Text.ToUpper(),
                    Semt = txtSemt.Text.ToUpper(),
                    ilce = txtIlce.Text.ToUpper(),
                    il = txtil.Text.ToUpper(),
                    PostaKodu = txtPostaKodu.Text.ToUpper(),
                    KanGrubu = cmbKanGrubu.SelectedText,
                    TcNo = txtTcNo.Text.ToUpper(),
                    Uyruk = comboBox1.SelectedText,
                    KimlikSeriNo = txtKimlikSeriNo.Text.ToUpper(),
                    Mahalle = txtMahalle.Text.ToUpper(),
                    Koy = txtKoy.Text.ToUpper(),
                    SiraNo = txtSiraNo.Text.ToUpper(),
                    VerilisYeri = txtVerYeri.Text.ToUpper(),
                    KayitNo = txtKayitNo.Text.ToUpper(),
                    Resim = resim,
                    SinifId = sinif[cmbSinif.SelectedIndex].sinifId,
                    ServisId = servis[cmbServis.SelectedIndex].ID,
                    KayitTarihi = dateTimePicker2.Value,
                    Yapilanlar = txtYapilanlar.Text.ToUpper(),
                    YasitlariylaIliskisi = txtYasitlariylailiskisi.Text.ToUpper(),
                    SevdigiYiyecekler = txtYiyecekler.Text.ToUpper(),
                    SaglikSorunlari = textBox5.Text.ToUpper(),
                    ilac = textBox6.Text.ToUpper(),
                    Protez = textBox10.Text.ToUpper(),
                });
                if (ogrid == 0) throw new Exception("Ogrenci Eklenemedi");
                if(!(textBox2.Text=="" || textBox2.Text==null))              
                    client.VeliEkle(par.KullaniciAdi, par.Sifre, par.Departman, new VelilerDB
                    {
                        Adi=textBox2.Text.ToUpper(),
                        Soyadi=txtVeliSoyAdi.Text.ToUpper(),
                        Ceptel=txtVeliCep.Text.ToUpper(),
                        EvTel=txtVeliEvTel.Text.ToUpper(),
                        TcNo=txtVeliTc.Text.ToUpper(),
                        YakinlikDerecesi = txtVeliYakinlikDerecesi.Text.ToUpper(),
                        Meslek=txtVeliMeslek.Text.ToUpper(),
                        Email=txtVeliEmail.Text.ToUpper(),
                        OgrenciId=ogrid
                    });
               if(!(txtUcuncuSahisAd.Text=="" || txtUcuncuSahisAd.Text==null))
                client.UcuncuSahisEkle(par.KullaniciAdi, par.Sifre, par.Departman, new UcuncuSahisDB
                {
                    Adi=txtUcuncuSahisAd.Text.ToUpper(),
                    Soyadi=txtUcuncuSahisSoyad.Text.ToUpper(),
                    EvTel=txtUcuncuSahisEvTel.Text.ToUpper(),
                    Email=txtUcuncuSahisEmail.Text.ToUpper(),
                    Ceptel=txtUcuncuSahisCep.Text.ToUpper(),
                    Meslek=txtUcuncuSahisMeslek.Text.ToUpper(),
                    OgrenciId=ogrid,
                    TcNo=txtUcuncuSahisTc.Text.ToUpper(),
                    YakinlikDerecesi=txtUcuncuSahisYakinlikDerecesi.Text.ToUpper()
                });
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(panel1);
            ClearTextBoxes(panel2);
            ClearTextBoxes(panel3);
            ClearTextBoxes(panel4);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {


        }

    }
}
