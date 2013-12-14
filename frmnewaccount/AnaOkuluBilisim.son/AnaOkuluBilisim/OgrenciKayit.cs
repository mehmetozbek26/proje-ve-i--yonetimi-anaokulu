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

namespace AnaOkuluBilisim
{
    public partial class OgrenciKayit : Form
    {
        public Form1 frm1;
        //double x, y, fx, fy, oranx, orany;
        public OgrenciKayit()
            
        { 
        
            InitializeComponent();
        }
        string resimPath;
        SqlConnection baglan = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select sinifId,sinifAdi from Siniflar", baglan);
            baglan.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            cmbSinif.Items.Insert(0, "Seçiniz");
            while (rdr.Read())
            {
                
                cmbSinif.Items.Insert(Convert.ToInt32(rdr["sinifId"].ToString()), rdr["SinifAdi"].ToString());
                //cmbSinif.Items.Add( rdr["SinifAdi"].ToString());
            }
            baglan.Close();
            rdr.Close();

            SqlCommand cmd2 = new SqlCommand("Select ServisAdi from Servisler", baglan);
            baglan.Open();
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                cmbServis.Items.Add(rdr2["ServisAdi"].ToString());
            }
            baglan.Close();
            rdr2.Close();

            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            //x = Screen.PrimaryScreen.Bounds.Width;
            //y = Screen.PrimaryScreen.Bounds.Height;
            //fx = this.Width;
            //fy = this.Height;
            //oranx = Math.Round(1920 / x, 2);
            //orany = Math.Round(1080 / y, 2);
            //this.Width = Convert.ToInt32(1292 / oranx);
            //this.Height = Convert.ToInt32(756 / orany);
            //txtOgrenciAd.Width = Convert.ToInt32(417 / oranx);
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
            int ogrid=0;

            if (txtOgrenciAd.Text == "")
            { MessageBox.Show("Öğrenci Adı Giriniz."); }
            else if (txtOgrenciSoyad.Text == "")
            { MessageBox.Show("Öğrenci Soyadı Giriniz."); }
            else if (txtOgrenciAdres.Text == "")
            { MessageBox.Show("Adres Giriniz."); }
            else if (txtSemt.Text == "")
            { MessageBox.Show("Semt Giriniz."); }
            else if (txtIlce.Text == "")
            { MessageBox.Show("İlçe Giriniz."); }
            else if (txtil.Text == "")
            { MessageBox.Show("İl Giriniz."); }
            else if (txtPostaKodu.Text == "")
            { MessageBox.Show("Posta Kodu Giriniz."); }
            else if (txtEvTel.Text == "")
            { MessageBox.Show("Ev Telofon Bilgilerini Giriniz."); }
            else if (txtUyruk.Text == "")
            { MessageBox.Show("Uyruk Giriniz."); }
            else if (txtTcNo.Text == "")
            { MessageBox.Show("Tc No Giriniz."); }
            else if (txtKimlikSeriNo.Text == "")
            { MessageBox.Show("Seri No Giriniz."); }
            else if (txtDogumYeri.Text == "")
            { MessageBox.Show("Doğum Yeri Giriniz."); }
            else if (txtDogumTarihi.Text == "")
            { MessageBox.Show("Doğum Tarihi Giriniz."); }
            else if (txtKimlikil.Text == "")
            { MessageBox.Show("Kimlik Bilg. İl Giriniz."); }
            else if (txtKimlikilce.Text == "")
            { MessageBox.Show("Kimlik Bilg. İlçe Giriniz."); }
            else if (txtMahalle.Text == "")
            { MessageBox.Show("Mahalle Giriniz."); }
            else if (txtKoy.Text == "")
            { MessageBox.Show("Köy Giriniz."); }
            else if (txtCilt.Text == "")
            { MessageBox.Show("Cilt Bilg. Giriniz."); }
            else if (txtAile.Text == "")
            { MessageBox.Show("Kimlik Bilg. Aile Girniz."); }
            else if (txtSiraNo.Text == "")
            { MessageBox.Show("Kimlik Bilg.Sıra No Giriniz."); }
            else if (txtVerYeri.Text == "")
            { MessageBox.Show("Kimlik Bilg. Veriliş Yeri Giriniz."); }
            else if (txtKayitNo.Text == "")
            { MessageBox.Show("Kimlik Bilg. Kayıt No Giriniz."); }

            else
            {

                FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] resim = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                SqlCommand cmd = new SqlCommand("sp_OgrenciKayitEkle", baglan);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Adi", txtOgrenciAd.Text);
                cmd.Parameters.Add("@Soyadi", txtOgrenciSoyad.Text);
                cmd.Parameters.Add("@Adres", txtOgrenciAdres.Text);
                cmd.Parameters.Add("@Semt", txtSemt.Text);
                cmd.Parameters.Add("@ilce", txtIlce.Text);
                cmd.Parameters.Add("@il", txtil.Text);
                cmd.Parameters.Add("@PostaKodu", txtPostaKodu.Text);
                cmd.Parameters.Add("@EvTel", txtEvTel.Text);
                cmd.Parameters.Add("@KanGrubu", cmbKanGrubu.Text);
                cmd.Parameters.Add("@TcNo", txtTcNo.Text);
                cmd.Parameters.Add("@Uyruk", txtUyruk.Text);
                cmd.Parameters.Add("@Cinsiyet", cmbCinsiyet.Text);
                cmd.Parameters.Add("@KimlikSeriNo", txtKimlikSeriNo.Text);
                cmd.Parameters.Add("@DogumYeri", txtDogumYeri.Text);
                cmd.Parameters.Add("@DogumTarihi", txtDogumTarihi.Text);
                cmd.Parameters.Add("@Dogumili", txtKimlikil.Text);
                cmd.Parameters.Add("@Dogumilce", txtKimlikilce.Text);
                cmd.Parameters.Add("@Mahalle", txtMahalle.Text);
                cmd.Parameters.Add("@Koy", txtKoy.Text);
                cmd.Parameters.Add("@Cilt", txtCilt.Text);
                cmd.Parameters.Add("@Aile", txtAile.Text);
                cmd.Parameters.Add("@SiraNo", txtSiraNo.Text);
                cmd.Parameters.Add("@VerilisYeri", txtVerYeri.Text);
                cmd.Parameters.Add("@KayitNo", txtKayitNo.Text);
                cmd.Parameters.Add("@Resim", SqlDbType.Image, resim.Length).Value = resim;
                cmd.Parameters.Add("@SinifId", cmbSinif.SelectedIndex.ToString());
                cmd.Parameters.Add("@Sinifi", cmbSinif.Text);
                cmd.Parameters.Add("@Servisi", cmbServis.Text);
                cmd.Parameters.Add("@KayitTarihi", txtKayitTarihi.Text);
                cmd.Parameters.Add("@CikisTarihi", txtCikisTarihi.Text);
                cmd.Parameters.Add("@DavranisSorunu", txtDavranisSorunlari.Text);
                cmd.Parameters.Add("@Yapilanlar", txtYapilanlar.Text);
                cmd.Parameters.Add("@YasitlariylaIliskisi", txtYasitlariylailiskisi.Text);
                cmd.Parameters.Add("@Fobileri", txtFobileri.Text);
                cmd.Parameters.Add("@SevdigiYiyecekler", txtYiyecekler.Text);
                cmd.Parameters.Add("@Asilar", textBox9.Text);
                cmd.Parameters.Add("@GecirdigiHastaliklar", textBox1.Text);
                cmd.Parameters.Add("@Alerjiler", textBox3.Text);
                cmd.Parameters.Add("@Ameliyatlar", textBox4.Text);
                cmd.Parameters.Add("@SaglikSorunlari", textBox5.Text);
                cmd.Parameters.Add("@ilac", textBox6.Text);
                cmd.Parameters.Add("@Protez", textBox10.Text);
                cmd.Parameters.Add("@Diyet", txtDiyet.Text);
                cmd.Parameters.Add("@RuhsalDurum", textBox7.Text);
                try
                {
                    baglan.Open();
                    ogrid= Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Kayıt Eklendi.");
                }
                catch
                {
                    MessageBox.Show("Hata Oluştu");
                }
                finally
                {
                    baglan.Close();
                }
            }
            SqlCommand cmd2 = new SqlCommand("sp_VeliEkle",baglan);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@VeliAdi",txtVeliAdi.Text);
            cmd2.Parameters.Add("@VeliSoyadi", txtVeliSoyAdi.Text);
            cmd2.Parameters.Add("@VeliCeptel", txtVeliCep.Text);
            cmd2.Parameters.Add("@VeliEvTel", txtVeliEvTel.Text);
            cmd2.Parameters.Add("@VeliTcNo", txtVeliTc.Text);
            cmd2.Parameters.Add("@YakinlikDerecesi",txtVeliYakinlikDerecesi.Text);
            cmd2.Parameters.Add("@Meslek",txtVeliMeslek.Text);
            cmd2.Parameters.Add("@Email",txtVeliEmail.Text);
            //cmd2.Parameters.Add("@OgrenciId",SqlDbType.Int,0,"OgrenciId");
            cmd2.Parameters.Add("@OgrenciId", ogrid);
            //cmd2.Parameters("@OgrenciId").Direction = ParameterDirection.Output;
            try
            {
                baglan.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Veli Bilgileri EKlendi.");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
            finally
            {
                baglan.Close();
            }
            SqlCommand cmd3 = new SqlCommand("sp_UcuncuSahisEkle",baglan);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("@Adi",txtUcuncuSahisAd.Text);
            cmd3.Parameters.Add("@Soyadi",txtUcuncuSahisSoyad.Text);
            cmd3.Parameters.Add("@CepTel",txtUcuncuSahisCep.Text);
            cmd3.Parameters.Add("@EvTel",txtUcuncuSahisEvTel.Text);
            cmd3.Parameters.Add("@TcNo",txtUcuncuSahisTc.Text);
            cmd3.Parameters.Add("@YakinlikDerecesi",txtUcuncuSahisYakinlikDerecesi.Text);
            cmd3.Parameters.Add("@Meslek",txtUcuncuSahisMeslek.Text);
            cmd3.Parameters.Add("@Email",txtUcuncuSahisEmail.Text);
            cmd3.Parameters.Add("@OgrenciId",ogrid);
            try
            {
                baglan.Open();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Üçüncü Şahıs Bilgileri Eklendi.");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
            finally
            {
                baglan.Close();
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

    }
}
