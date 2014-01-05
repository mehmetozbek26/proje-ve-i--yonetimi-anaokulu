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
    public partial class Ogrenciler : Form
    {
        public OgrDuzenle ogrdznle;

        public Ogrenciler()
        {
            InitializeComponent();
            ogrdznle = new OgrDuzenle();
            ogrdznle.ogrenciler = this;
            //this.dataGridView1.MouseClick += new
            //System.Windows.Forms.MouseEventHandler(dataGridView1_MouseClick);
        }
        IList<Sinif> siniflar = new List<Sinif>();
        IList<Dersler> dersler = new List<Dersler>();
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        DataTable tablo = new DataTable();

        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'anaOkuluDBDataSet.Ogrenciler' table. You can move, or remove it, as needed.
            try
            {
                pictureBox1.Visible = false;
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
                tablo.Clear();
                using (SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId", cnn))
                {
                    cnn.Open();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    cnn.Close();
                }
                dataGridView1.Columns["OgrenciId"].Visible = false;
                dataGridView1.Columns["Resim"].Visible = false;
            }
            catch (Exception err)
            {


            }
            finally
            {
                cnn.Close();
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ogrdznle.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId and OgrenciId=" + Convert.ToInt32(textBox1.Text), cnn);

                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId and Adi like '%" + textBox2.Text + "%'  ", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Image im = (Image)dataGridView1.CurrentRow.Cells["Resim"].Value;
            pictureBox1.Image = im;
            pictureBox1.Visible = true;

            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //int secilensatir = Convert.ToInt32((dataGridView1.CurrentCell.RowIndex + 1).ToString());
            //SqlCommand cmd = new SqlCommand("Select Resim From Ogrenciler Where OgrenciId=" + secilensatir, cnn);
            //if (cnn.State != ConnectionState.Open)
            //{
            //    cnn.Open();
            //}
            //SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            //byte[] byteResim = new byte[50];
            //MemoryStream ms = new MemoryStream();
            //BinaryWriter bw = new BinaryWriter(ms);
            //long donenDeger;
            //long baslangicIndeks = 0;
            //while (dr.Read())
            //{
            //    donenDeger = dr.GetBytes(0, 0, byteResim, 0, 50);
            //    while (donenDeger == 50)
            //    {
            //        bw.Write(byteResim);
            //        bw.Flush();
            //        baslangicIndeks += 50;
            //        donenDeger = dr.GetBytes(0, baslangicIndeks, byteResim, 0, 50);
            //    }
            //    bw.Write(byteResim);
            //    pictureBox1.Image = Image.FromStream(ms);
            //    bw.Flush();
            //    ms.Close();
            //}
            //dr.Close();
            //cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Ogrenciler WHERE OgrenciId=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["OgrenciId"].Value);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    Ogrenciler_Load(sender, e);
                }
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
        public OgrDuzenle frm;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frm = new OgrDuzenle();
                var a = (string)dataGridView1.CurrentRow.Cells["OgrenciId"].Value.ToString();
                GlobalClass.Ogrid = dataGridView1.CurrentRow.Cells["OgrenciId"].Value.ToString();
                frm.Show();
                Ogrenciler_Load(sender, e);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ogrenci Yok");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Byte[] data = (Byte[])dataGridView1.CurrentRow.Cells["Resim"].Value;
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      

        private string DersAdiBul(int id)
        {
            for (int i = 0; i < dersler.Count; i++)
                if (dersler[i].DERSID == id)
                    return dersler[i].DERSADI;
            return "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSinif.SelectedIndex == 0) throw new Exception("Sınıf Seçiniz");
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler o,Siniflar s where o.SinifId=s.sinifId and s.sinifId=" + siniflar[cmbSinif.SelectedIndex - 1].SinifID, cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
      

              
        }
    }
}

