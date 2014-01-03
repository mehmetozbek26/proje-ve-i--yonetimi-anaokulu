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

       
        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'anaOkuluDBDataSet.Ogrenciler' table. You can move, or remove it, as needed.


            dataGridView1.RowTemplate.Height = 100; 


            tablo.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,s.sinifAdi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from Ogrenciler o,Siniflar s where s.sinifId=o.SinifId", cnn);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;                     
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
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,Sinifi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,Sinifi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler where OgrenciId='" + textBox1.Text + "'  ", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cnn.Open();
            if (textBox2.Text.Trim() == "")
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,Sinifi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,Sinifi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler where Adi='" + textBox2.Text + "'  ", cnn);
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            cnn.Close();
        }
        //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;          
        //    int secilensatir = Convert.ToInt32((dataGridView1.CurrentCell.RowIndex + 1).ToString());                     
        //    SqlCommand cmd = new SqlCommand("Select Resim From Ogrenciler Where OgrenciId=" + secilensatir, cnn);
        //    if (cnn.State != ConnectionState.Open)
        //    {
        //        cnn.Open();
        //    }
        //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        //    byte[] byteResim = new byte[50];
        //    MemoryStream ms = new MemoryStream();
        //    BinaryWriter bw = new BinaryWriter(ms);
        //    long donenDeger;
        //    long baslangicIndeks = 0;
        //    while (dr.Read())
        //    {
        //        donenDeger = dr.GetBytes(0, 0, byteResim, 0, 50);
        //        while (donenDeger == 50)
        //        {
        //            bw.Write(byteResim);
        //            bw.Flush();
        //            baslangicIndeks += 50;
        //            donenDeger = dr.GetBytes(0, baslangicIndeks, byteResim, 0, 50);
        //        }
        //        bw.Write(byteResim);
        //        pictureBox1.Image = Image.FromStream(ms);
        //        bw.Flush();
        //        ms.Close();
        //    }
        //    dr.Close();
        //    cnn.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            cnn.Open(); 
            cmd.Connection = cnn;
            cmd.CommandText = "Delete from Ogrenciler where OgrenciId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            cmd1.Connection = cnn;
            cmd1.CommandText = "Delete from Veliler where OgrenciId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            cmd2.Connection = cnn;
            cmd2.CommandText = "Delete from UcuncuSahislar where OgrenciId='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter("select OgrenciId,Adi,Soyadi,Sinifi,Adres,il,ilce,EvTel,TcNo,Cinsiyet,DogumTarihi,Resim from ogrenciler ", cnn);
            tablo.Clear();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Refresh();
          cnn.Close();
        }
        public OgrDuzenle frm;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["OgrenciId"].Value==null )
            {
                frm = new OgrDuzenle();
                GlobalClass.Ogrid = dataGridView1.CurrentRow.Cells["OgrenciId"].Value.ToString();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Kayıtlı Öğrenci Yok");
        }



       

       
    }
}

