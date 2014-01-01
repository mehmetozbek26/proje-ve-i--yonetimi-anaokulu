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
using System.Configuration;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class OgrDuzenle : Form
    {
        public Ogrenciler ogrenciler;
         IList<Sinif> siniflar = new List<Sinif>();
         IList<Servis> servisler = new List<Servis>();
         double x, y, fx, fy, oranx, orany;
         string resimPath;
         int ogrid = Convert.ToInt32(GlobalClass.Ogrid);
         byte[] resim;
        public OgrDuzenle()
        {        
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        DataGridView dataGridView1 = new DataGridView();
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void OgrDuzenle_Load(object sender, EventArgs e)
        {

            try
            {
                ogrid = Convert.ToInt32(GlobalClass.Ogrid);
                dataGridView1.RowTemplate.Height = 100;
                using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", cnn))
                {

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cmbSinif.Items.Clear();
                    cmbSinif.Items.Insert(0, "Seçiniz");
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
                        cmbSinif.Items.Add(rdr["sinifAdi"].ToString());
                    }
                    cnn.Close();

                }
                servisler.Clear();
                using (SqlCommand cmd2 = new SqlCommand("Select * from Servisler", cnn))
                {
                    cnn.Open();
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    cmbServis.Items.Clear();
                    cmbServis.Items.Insert(0, "Seçiniz");
                    while (rdr2.Read())
                    {
                        servisler.Add(new Servis
                        {
                            ServisAdi = rdr2["ServisAdi"].ToString(),
                            ServisID = Convert.ToInt32(rdr2["ServisID"].ToString())
                        });
                        cmbServis.Items.Add(rdr2["ServisAdi"].ToString());
                    }
                    cnn.Close();
                    rdr2.Close();
                }
                using (SqlCommand cmd = new SqlCommand("select * from Ogrenciler o where o.OgrenciId=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", ogrid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    txtPostaKodu.Text = dr["PostaKodu"].ToString();
                    txtAile.Text = dr["Aile"].ToString();
                    txtOgrenciAd.Text = dr["Adi"].ToString();
                    textBox3.Text = dr["Alerjiler"].ToString();
                    txtOgrenciSoyad.Text = dr["Soyadi"].ToString();
                    txtOgrenciAdres.Text = dr["Adres"].ToString();
                    txtSemt.Text = dr["Semt"].ToString();
                    txtIlce.Text = dr["ilce"].ToString();
                    txtil.Text = dr["il"].ToString();
                    txtDogumYeri.Text = dr["DogumYeri"].ToString();
                    
                    txtKimlikil.Text = dr["Dogumili"].ToString();
                    txtKimlikilce.Text = dr["Dogumilce"].ToString();
                    txtMahalle.Text = dr["Mahalle"].ToString();
                    txtKoy.Text = dr["Koy"].ToString();
                    txtCilt.Text = dr["Cilt"].ToString();
                    txtSiraNo.Text = dr["SiraNo"].ToString();
                    txtVerYeri.Text = dr["VerilisYeri"].ToString();
                    txtKayitNo.Text = dr["KayitNo"].ToString();                                                                 
                    txtDavranisSorunlari.Text = dr["DavranisSorunu"].ToString();
                    txtYapilanlar.Text = dr["Yapilanlar"].ToString();
                    txtYasitlariylailiskisi.Text = dr["YasitlariylaIliskisi"].ToString();
                    txtFobileri.Text = dr["Fobileri"].ToString();
                    txtYiyecekler.Text = dr["SevdigiYiyecekler"].ToString();
                    textBox9.Text = dr["Asilar"].ToString();
                    textBox1.Text = dr["GecirdigiHastaliklar"].ToString();
                    textBox4.Text = dr["Ameliyatlar"].ToString();
                    textBox5.Text = dr["SaglikSorunlari"].ToString();
                    textBox6.Text = dr["ilac"].ToString();
                    textBox10.Text = dr["Protez"].ToString();
                    txtDiyet.Text = dr["Diyet"].ToString();
                    textBox7.Text = dr["RuhsalDurum"].ToString();
                    txtEvTel.Text = dr["EvTel"].ToString();
                    for (int i = 0; i < txtUyruk.Items.Count; i++)
                        if (txtUyruk.Items[i].ToString() == dr["Uyruk"].ToString())
                        {
                            txtUyruk.SelectedIndex = i;
                            break;
                        }                 
                    txtKimlikSeriNo.Text = dr["KimlikSeriNo"].ToString();
                    txtTcNo.Text = dr["TcNo"].ToString();
                    var kan=dr["KanGrubu"].ToString();
                    var cin = (dr["Cinsiyet"].ToString());

                    for (int i = 0; i < cmbKanGrubu.Items.Count; i++)
                        if (cmbKanGrubu.Items[i].ToString() == kan)
                        {
                            cmbKanGrubu.SelectedIndex = i;
                            break;
                        }
                    for (int i = 0; i < cmbCinsiyet.Items.Count; i++)
                        if (cmbCinsiyet.Items[i].ToString() == cin)
                        {
                            cmbCinsiyet.SelectedIndex = i;
                            break;
                        }
                    for (int i = 0; i < siniflar.Count; i++)
                        if (siniflar[i].SinifID == Convert.ToInt32(dr["SinifId"].ToString()))
                        {
                            cmbSinif.SelectedIndex = i+1;
                            break;
                        }
                    for (int i = 0; i < servisler.Count; i++)
                        if (servisler[i].ServisID == Convert.ToInt32(dr["ServisId"].ToString()))
                        {
                            cmbServis.SelectedIndex = i+1;
                            break;
                        }

                    if (dr["KayitTarihi"].ToString() != null)
                        txtKayitTarihi.Value = Convert.ToDateTime(dr["KayitTarihi"].ToString());
                    else
                        txtKayitTarihi.Value = DateTime.MinValue;
                    if (dr["DogumTarihi"].ToString() != null)
                        txtDogumTarihi.Value = Convert.ToDateTime(dr["DogumTarihi"].ToString());
                    else
                        txtDogumTarihi.Value = DateTime.MinValue;
                    byte[] resim = dr["Resim"] as byte[];
                    if (resim != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        ms.Write(resim, 0, resim.Length);
                        Image img = Image.FromStream(ms);
                        pictureBox1.Image = img;
                    }
                    else
                    {
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
                    dr.Close();
                    cnn.Close();

                }
                using (SqlCommand cmd = new SqlCommand("select * from Veliler v where v.OgrenciId=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", ogrid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    txtVeliCep.Text = dr["CepTel"].ToString();
                    textBox2.Text = dr["Adi"].ToString();
                    txtVeliSoyAdi.Text = dr["Soyadi"].ToString();
                    txtVeliEvTel.Text = dr["EvTel"].ToString();
                    txtVeliTc.Text = dr["TcNo"].ToString();
                    txtVeliYakinlikDerecesi.Text = dr["YakinlikDerecesi"].ToString();
                    txtVeliMeslek.Text = dr["Meslek"].ToString();
                    txtVeliEmail.Text = dr["Email"].ToString();
                    dr.Close();
                    cnn.Close();
                }
                using (SqlCommand cmd = new SqlCommand("select * from UcuncuSahislar u where u.OgrenciId=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", ogrid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    txtUcuncuSahisCep.Text = dr["CepTel"].ToString();
                    txtUcuncuSahisAd.Text = dr["Adi"].ToString();
                    txtUcuncuSahisSoyad.Text = dr["Soyadi"].ToString();
                    txtUcuncuSahisEvTel.Text = dr["EvTel"].ToString();
                    txtUcuncuSahisTc.Text = dr["TcNo"].ToString();
                    txtUcuncuSahisYakinlikDerecesi.Text = dr["YakinlikDerecesi"].ToString();
                    txtUcuncuSahisMeslek.Text = dr["Meslek"].ToString();
                    txtUcuncuSahisEmail.Text = dr["Email"].ToString();
                    dr.Close();
                    cnn.Close();
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

            }

        }

        private void btnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || txtVeliSoyAdi.Text == "") throw new Exception("Veli Kısmını Giriniz");
                if (txtUcuncuSahisAd.Text == "" || txtUcuncuSahisSoyad.Text == "") throw new Exception("Ucuncu Sahis Kısmını Doldurunuz");
                if (txtOgrenciAd.Text == "") throw new Exception("Öğrenci Adı Giriniz.");
                else if (txtOgrenciSoyad.Text == "") throw new Exception("Öğrenci Soyadı Giriniz.");
                else if (txtOgrenciAdres.Text == "") throw new Exception("Adres Giriniz.");
                else if (txtSemt.Text == "") throw new Exception("Semt Giriniz.");
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
                    
                    
                    using (SqlCommand cmd = new SqlCommand("Update Ogrenciler set " +
                        "Adi=@Adi," +
                        "Soyadi=@Soyadi," +
                        "Adres=@Adres," +
                        "Semt=@Semt," +
                        "ilce=@ilce," +
                        "il=@il," +
                        "PostaKodu=@PostaKodu," +
                        "EvTel=@EvTel," +
                        "KanGrubu=@KanGrubu," +
                        "TcNo=@TcNo," +
                        "Uyruk=@Uyruk," +
                        "Cinsiyet=@Cinsiyet," +
                        "KimlikSeriNo=@KimlikSeriNo," +
                        "DogumYeri=@DogumYeri," +
                        "DogumTarihi=@DogumTarihi," +
                        "Dogumili=@Dogumili," +
                        "Dogumilce=@Dogumilce," +
                        "Mahalle=@Mahalle," +
                        "Koy=@Koy," +
                        "Cilt=@Cilt," +
                        "Aile=@Aile," +
                        "SiraNo=@SiraNo," +
                        "VerilisYeri=@VerilisYeri," +
                        "KayitNo=@KayitNo," +
                        "Resim=@Resim," +
                        "SinifId=@SinifId," +
                        "ServisId=@ServisId," +
                        "KayitTarihi=@KayitTarihi," +
                        "DavranisSorunu=@DavranisSorunu," +
                        "Yapilanlar=@Yapilanlar," +
                        "YasitlariylaIliskisi=@YasitlariylaIliskisi," +
                        "Fobileri=@Fobileri," +
                        "SevdigiYiyecekler=@SevdigiYiyecekler," +
                        "Asilar=@Asilar," +
                        "GecirdigiHastaliklar=@GecirdigiHastaliklar," +
                        "Alerjiler=@Alerjiler," +
                        "Ameliyatlar=@Ameliyatlar," +
                        "SaglikSorunlari=@SaglikSorunlari," +
                        "ilac=@ilac," +
                        "Protez=@Protez," +
                        "Diyet=@Diyet," +
                        "RuhsalDurum=@RuhsalDurum WHERE OgrenciId=@id", cnn))
                    {
                        cnn.Open();
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
                        cmd.Parameters.Add("@DogumTarihi", txtDogumTarihi.Value);
                        cmd.Parameters.Add("@Dogumili", txtKimlikil.Text);
                        cmd.Parameters.Add("@Dogumilce", txtKimlikilce.Text);
                        cmd.Parameters.Add("@Mahalle", txtMahalle.Text);
                        cmd.Parameters.Add("@Koy", txtKoy.Text);
                        cmd.Parameters.Add("@Cilt", txtCilt.Text);
                        cmd.Parameters.Add("@Aile", txtAile.Text);
                        cmd.Parameters.Add("@SiraNo", txtSiraNo.Text);
                        cmd.Parameters.Add("@VerilisYeri", txtVerYeri.Text);
                        cmd.Parameters.Add("@KayitNo", txtKayitNo.Text);
                        if (pictureBox1.Image != null)
                        {
                            var mem=new MemoryStream();
                            pictureBox1.Image.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Byte[] temp = mem.GetBuffer();
                            cmd.Parameters.Add("@Resim", SqlDbType.Image, temp.Length).Value = temp;
                        }
                        else
                            throw new Exception("Resim Seçiniz");
                        if (cmbSinif.SelectedIndex < 1) throw new Exception("Lütfen Sinif Seçiniz");
                        cmd.Parameters.Add("@SinifId", siniflar[cmbSinif.SelectedIndex - 1].SinifID);
                        if (cmbServis.SelectedIndex < 1) throw new Exception("Lütfen Servis Seçiniz");
                        cmd.Parameters.Add("@ServisId", servisler[cmbServis.SelectedIndex - 1].ServisID);
                        cmd.Parameters.Add("@KayitTarihi", txtKayitTarihi.Value);
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
                        cmd.Parameters.Add("@id", ogrid);
                        cmd.ExecuteNonQuery();
                        cnn.Close();

                    }
                    MessageBox.Show("Kayıt Güncellendi.");
                    using (SqlCommand cmd2 = new SqlCommand("Update Veliler set " +
                        "Adi=@VeliAdi," +
                        "Soyadi=@VeliSoyadi," +
                        "Ceptel=@VeliCeptel," +
                        "EvTel=@VeliEvTel," +
                        "TcNo=@VeliTcNo," +
                        "YakinlikDerecesi=@YakinlikDerecesi," +
                        "Email=@Email," +
                        "Meslek=@Meslek WHERE OgrenciId=@id", cnn))
                    {
                        cnn.Open();
                        cmd2.Parameters.Add("@VeliAdi", textBox2.Text);
                        cmd2.Parameters.Add("@VeliSoyadi", txtVeliSoyAdi.Text);
                        cmd2.Parameters.Add("@VeliCeptel", txtVeliCep.Text);
                        cmd2.Parameters.Add("@VeliEvTel", txtVeliEvTel.Text);
                        cmd2.Parameters.Add("@VeliTcNo", txtVeliTc.Text);
                        cmd2.Parameters.Add("@YakinlikDerecesi", txtVeliYakinlikDerecesi.Text);
                        cmd2.Parameters.Add("@Meslek", txtVeliMeslek.Text);
                        cmd2.Parameters.Add("@Email", txtVeliEmail.Text);
                        cmd2.Parameters.Add("@id", ogrid);
                        cmd2.ExecuteNonQuery();
                        cnn.Close();
                    }
                    MessageBox.Show("Veli Bilgileri Güncellendi.");
                    using (SqlCommand cmd3 = new SqlCommand("Update UcuncuSahislar set " +
                        "Adi=@Adi," +
                        "Soyadi=@Soyadi," +
                        "CepTel=@CepTel," +
                        "EvTel=@EvTel," +
                        "TcNo=@TcNo," +
                        "YakinlikDerecesi=@YakinlikDerecesi," +
                        "Meslek=@Meslek," +
                        "Email=@Email WHERE OgrenciId=@id", cnn))
                    {
                        cnn.Open();
                        cmd3.Parameters.Add("@Adi", txtUcuncuSahisAd.Text);
                        cmd3.Parameters.Add("@Soyadi", txtUcuncuSahisSoyad.Text);
                        cmd3.Parameters.Add("@CepTel", txtUcuncuSahisCep.Text);
                        cmd3.Parameters.Add("@EvTel", txtUcuncuSahisEvTel.Text);
                        cmd3.Parameters.Add("@TcNo", txtUcuncuSahisTc.Text);
                        cmd3.Parameters.Add("@YakinlikDerecesi", txtUcuncuSahisYakinlikDerecesi.Text);
                        cmd3.Parameters.Add("@Meslek", txtUcuncuSahisMeslek.Text);
                        cmd3.Parameters.Add("@Email", txtUcuncuSahisEmail.Text);
                        cmd3.Parameters.Add("@id", ogrid);
                        cmd3.ExecuteNonQuery();
                        cnn.Close();

                    }
                }
                MessageBox.Show("Üçüncü Şahıs Bilgileri Güncellendi.");

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";
            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                resimPath = openFileDialog1.FileName.ToString();
            }
            //if (resimPath != null)
            //{
            //    FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    resim = br.ReadBytes((int)fs.Length);
            //    br.Close();
            //    fs.Close();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(panel1);
            ClearTextBoxes(panel2);
            ClearTextBoxes(panel3);
            ClearTextBoxes(panel4);
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

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        


    

     
    }
}