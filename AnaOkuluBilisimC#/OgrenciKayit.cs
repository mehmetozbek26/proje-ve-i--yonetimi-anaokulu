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
using AnaOkuluBilisim.Models;
using WebCam_Capture;
namespace AnaOkuluBilisim
{
    public partial class OgrenciKayit : Form
    {
        public Form1 frm1;
        double x, y, fx, fy, oranx, orany;
        IList<Sinif> siniflar = new List<Sinif>();
        IList<Servis> servisler = new List<Servis>();
        WebCamCapture cma;


        public OgrenciKayit()
        {
            InitializeComponent();
        }
        string resimPath;
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void servislerupdate()
        {
            servisler.Clear();
            cmbServis.Items.Clear();
            using (SqlCommand cmd2 = new SqlCommand("Select * from Servisler", baglan))
            {
                baglan.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
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
                baglan.Close();
                rdr2.Close();
            }
        }
        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", baglan))
                {

                    baglan.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
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
                    baglan.Close();

                }
                servislerupdate();


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


        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";
            openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                resimPath = openFileDialog1.FileName.ToString();
            }
        }

        private void btnOgrenciKaydet_Click_1(object sender, EventArgs e)
        {
            int ogrid = 0;
            try
            {
                if (textBox2.Text == "" || txtVeliSoyAdi.Text == "") throw new Exception("Veli Kısmını Giriniz");
                if (txtUcuncuSahisAd.Text == "" || txtUcuncuSahisSoyad.Text == "") throw new Exception("Ucuncu Sahis Kısmını Doldurunuz");
                if (txtOgrenciAd.Text == "") throw new Exception("Öğrenci Adı Giriniz.");
                else if (txtOgrenciSoyad.Text == "") throw new Exception("Öğrenci Soyadı Giriniz.");
                else if (txtOgrenciAdres.Text == "") throw new Exception("Adres Giriniz.");
                else if (txtSemt.Text == "") throw new Exception("Semt Giriniz.");
                else if (txtIlce.Text == "") MessageBox.Show("İlçe Giriniz.");
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
                    byte[] resim = null;
                    if (resimPath != null)
                    {
                        FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        resim = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                    }

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
                    if (resim != null)
                        cmd.Parameters.Add("@Resim", SqlDbType.Image, resim.Length).Value = resim;
                    else if (pictureBox1.Image != null)
                    {
                        var mem = new MemoryStream();
                        pictureBox1.Image.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Byte[] temp = mem.GetBuffer();
                        cmd.Parameters.Add("@Resim", SqlDbType.Image, temp.Length).Value = temp;
                    }
                    else
                        throw new Exception("Lütfen Resim Ekleyiniz");
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
                    cmd.Parameters.Add(new SqlParameter("@ReturnId", SqlDbType.Int));
                    cmd.Parameters["@ReturnId"].Direction = ParameterDirection.Output;
                    try
                    {
                        baglan.Open();
                        cmd.ExecuteNonQuery();
                        ogrid = Convert.ToInt32(cmd.Parameters["@ReturnId"].Value);
                        if (ogrid < 0) throw new Exception("Sınıf Kapasitesi Doldu Litfen Başka Sınıf Seçiniz");
                        MessageBox.Show("Kayıt Eklendi.");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Hata Oluştu " + err.Message);
                    }
                    finally
                    {
                        baglan.Close();
                    }

                    SqlCommand cmd2 = new SqlCommand("sp_VeliEkle", baglan);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@VeliAdi", textBox2.Text);
                    cmd2.Parameters.Add("@VeliSoyadi", txtVeliSoyAdi.Text);
                    cmd2.Parameters.Add("@VeliCeptel", txtVeliCep.Text);
                    cmd2.Parameters.Add("@VeliEvTel", txtVeliEvTel.Text);
                    cmd2.Parameters.Add("@VeliTcNo", txtVeliTc.Text);
                    cmd2.Parameters.Add("@YakinlikDerecesi", txtVeliYakinlikDerecesi.Text);
                    cmd2.Parameters.Add("@Meslek", txtVeliMeslek.Text);
                    cmd2.Parameters.Add("@Email", txtVeliEmail.Text);
                    cmd2.Parameters.Add("@OgrenciId", ogrid);
                    try
                    {
                        baglan.Open();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Veli Bilgileri EKlendi.");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Hata Oluştu");
                    }
                    finally
                    {
                        baglan.Close();
                    }
                    SqlCommand cmd3 = new SqlCommand("sp_UcuncuSahisEkle", baglan);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.Add("@Adi", txtUcuncuSahisAd.Text);
                    cmd3.Parameters.Add("@Soyadi", txtUcuncuSahisSoyad.Text);
                    cmd3.Parameters.Add("@CepTel", txtUcuncuSahisCep.Text);
                    cmd3.Parameters.Add("@EvTel", txtUcuncuSahisEvTel.Text);
                    cmd3.Parameters.Add("@TcNo", txtUcuncuSahisTc.Text);
                    cmd3.Parameters.Add("@YakinlikDerecesi", txtUcuncuSahisYakinlikDerecesi.Text);
                    cmd3.Parameters.Add("@Meslek", txtUcuncuSahisMeslek.Text);
                    cmd3.Parameters.Add("@Email", txtUcuncuSahisEmail.Text);
                    cmd3.Parameters.Add("@OgrenciId", ogrid);
                    try
                    {
                        baglan.Open();
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Üçüncü Şahıs Bilgileri Eklendi.");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Hata Oluştu");
                    }
                    finally
                    {
                        baglan.Close();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnIptal_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes(panel5);
            ClearTextBoxes(panel2);
            ClearTextBoxes(panel3);
            ClearTextBoxes(panel4);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Servisler (ServisAdi) VALUES ('" + textBox8.Text.ToUpper() + "')", baglan))
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                }
                MessageBox.Show("Servis Eklendi");
                textBox8.Clear();
                servislerupdate();

            }
            catch (Exception err)
            {


            }
        }

    }
}
