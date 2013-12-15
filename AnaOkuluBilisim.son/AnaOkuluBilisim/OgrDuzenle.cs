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
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class OgrDuzenle : Form
    {
        public Ogrenciler ogrenciler;
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        IList<SiniflarDB> sinif;
        IList<ServislerDB> servis;
        public OgrDuzenle()
        {

            InitializeComponent();


        }
        private void OgrDuzenle_Load(object sender, EventArgs e)
        {
            try
            {
                int ogrid = Convert.ToInt32(GlobalClass.Ogrid);
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
                var ogren=client.OgrenciGetirID(par.KullaniciAdi, par.Sifre, par.Departman, ogrid);
                //cnn.Open();
                //SqlCommand cmd = new SqlCommand("Select Adi,Soyadi,Adres,Semt,ilce,il,PostaKodu,EvTel,KanGrubu,TcNo,Uyruk,Cinsiyet,KimlikSeriNo,DogumYeri,DogumTarihi,Dogumili,Dogumilce,Mahalle,Koy,Cilt,Aile,SiraNo,VerilisYeri,KayitNo,Resim,KayitTarihi,CikisTarihi,SinifId,Sinifi,Servisi,DavranisSorunu,Yapilanlar,YasitlariylaIliskisi,Fobileri,SevdigiYiyecekler,Asilar,GecirdigiHastaliklar,Alerjiler,Ameliyatlar,SaglikSorunlari,ilac,Protez,Diyet,RuhsalDurum from Ogrenciler Where OgrenciId='" + ogrid + "'", cnn);

                //SqlCommand cmd2 = new SqlCommand("Select Adi,Soyadi,Ceptel,EvTel,TcNo,YakinlikDerecesi,Meslek,Email from Veliler Where OgrenciId='" + ogrid + "'", cnn);
                //SqlCommand cmd3 = new SqlCommand("Select Adi,Soyadi,CepTel,EvTel,TcNo,YakinlikDerecesi,Meslek,Email from UcuncuSahislar Where OgrenciId='" + ogrid + "'", cnn);
                ////SqlDataAdapter da = new SqlDataAdapter("Select o.OgrenciId,o.Adi,o.Soyadi,o.Adres,o.Semt,o.ilce,o.il,o.PostaKodu,o.EvTel,o.KanGrubu,o.TcNo,o.Uyruk,o.Cinsiyet,o.KimlikSeriNo,o.DogumYeri,o.DogumTarihi,o.Dogumili,o.Dogumilce,o.Mahalle,o.Koy,o.Cilt,o.Aile,o.SiraNo,o.VerilisYeri,o.KayitNo,o.Resim,o.KayitTarihi,o.CikisTarihi,o.SinifId,o.Sinifi,o.Servisi,o.DavranisSorunu,o.Yapilanlar,o.YasitlariylaIliskisi,o.Fobileri,o.SevdigiYiyecekler,o.Asilar,o.GecirdigiHastaliklar,o.Alerjiler,o.Ameliyatlar,o.SaglikSorunlari,o.ilac,o.Protez,o.Diyet,o.RuhsalDurum,v.Adi,v.Soyadi,v.Ceptel,v.EvTel,v.TcNo,v.YakinlikDerecesi,v.Meslek,v.Email,u.Adi,u.Soyadi,u.CepTel,u.EvTel,u.TcNo,u.YakinlikDerecesi,u.Meslek,u.Email from Ogrenciler as o,Veliler as v,UcuncuSahislar as u Where o.OgrenciId='" + ogrid + "'", cnn);

                //SqlDataReader dr = cmd.ExecuteReader();
                //dr.Read();
                txtPostaKodu.Text = ogren.PostaKodu;
                txtAile.Text = ogren.Aile;
                txtOgrenciAd.Text = ogren.Adi;
                textBox3.Text = 
                txtOgrenciSoyad.Text = ogren.Soyadi;
                txtOgrenciAdres.Text = ogren.Adres;
                txtSemt.Text = ogren.Semt;
                txtIlce.Text = ogren.ilce;
                txtil.Text = ogren.il;
                txtDogumYeri.Text = ogren.DogumYeri;
                //txtDogumTarihi.Text = dr["DogumTarihi"].ToString();
                txtKimlikil.Text = ogren.il;
                txtKimlikilce.Text = ogren.ilce;
                txtMahalle.Text = ogren.Mahalle;
                txtKoy.Text = ogren.Koy;
                txtCilt.Text = ogren.Cilt;
                txtSiraNo.Text = ogren.SiraNo;
                txtVerYeri.Text = ogren.VerilisYeri;
                txtKayitNo.Text = ogren.KayitNo;
                byte[] resim = ogren.Resim;
                MemoryStream ms = new MemoryStream();

                ms.Write(resim, 0, resim.Length);
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;

                //txtKayitTarihi.Text = dr["KayitTarihi"].ToString();
                //txtCikisTarihi.Text = dr["CikisTarihi"].ToString();
                //cmbSinif.Items.Add(dr["Sinifi"].ToString());
                //cmbSinif.SelectedIndex = 0;
                //cmbServis.Items.Add(dr["Servisi"].ToString());
                //cmbServis.SelectedIndex = 0;
                //txtDavranisSorunlari.Text = ogren.DavranisSorunu;
                //txtYapilanlar.Text = ogren.Yapilanlar;
                //txtYasitlariylailiskisi.Text = ogren.YasitlariylaIliskisi;
                //txtFobileri.Text = ogren.Fobileri;
                //txtYiyecekler.Text = ogren.SevdigiYiyecekler;
                //textBox9.Text =
                //textBox1.Text =
                //textBox4.Text =
                //textBox5.Text =
                //textBox6.Text =
                //textBox10.Text =
                //txtDiyet.Text =
                //textBox7.Text =
                //txtEvTel.Text =
                ////txtUyruk.Text = 
                //txtKimlikSeriNo.Text = ogren.KimlikSeriNo;
                //txtTcNo.Text = ogren.TcNo;
                ////cmbKanGrubu.Items.Add(dr["KanGrubu"].ToString());
                ////cmbKanGrubu.SelectedIndex = 0;
                ////cmbCinsiyet.Items.Add(dr["Cinsiyet"].ToString());
                ////cmbCinsiyet.SelectedIndex = 0;

                ////dr.Close();







                //SqlDataReader dr2 = cmd2.ExecuteReader();
                //dr2.Read();
                //txtVeliCep.Text = dr2["CepTel"].ToString();
                //textBox2.Text = dr2["Adi"].ToString();
                //txtVeliSoyAdi.Text = dr2["Soyadi"].ToString();
                //txtVeliEvTel.Text = dr2["EvTel"].ToString();
                //txtVeliTc.Text = dr2["TcNo"].ToString();
                //txtVeliYakinlikDerecesi.Text = dr2["YakinlikDerecesi"].ToString();
                //txtVeliMeslek.Text = dr2["Meslek"].ToString();
                //txtVeliEmail.Text = dr2["Email"].ToString();
                //dr2.Close();
                //SqlDataReader dr3 = cmd3.ExecuteReader();
                //dr3.Read();
                //txtUcuncuSahisCep.Text = dr3["CepTel"].ToString();
                //txtUcuncuSahisAd.Text = dr3["Adi"].ToString();
                //txtUcuncuSahisSoyad.Text = dr3["Soyadi"].ToString();
                //txtUcuncuSahisEvTel.Text = dr3["EvTel"].ToString();
                //txtUcuncuSahisTc.Text = dr3["TcNo"].ToString();
                //txtUcuncuSahisYakinlikDerecesi.Text = dr3["YakinlikDerecesi"].ToString();
                //txtUcuncuSahisMeslek.Text = dr3["Meslek"].ToString();
                //txtUcuncuSahisEmail.Text = dr3["Email"].ToString();
                //dr3.Close();
                //cnn.Close();
            }
            catch (Exception err)
            {

            }
        }








    }
}