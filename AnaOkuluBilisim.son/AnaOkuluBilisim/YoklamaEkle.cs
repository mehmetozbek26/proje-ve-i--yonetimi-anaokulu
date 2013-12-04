﻿using System;
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
    public partial class YoklamaEkle : Form
    {
        public YoklamaEkle()
        {
            InitializeComponent();
        }
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        private void YoklamaEkle_Load(object sender, EventArgs e)
        {
            cmbDurum.Items.Add("Katıldı");
            cmbDurum.Items.Add("Katılmadı");
            txtOgrenciAd.Enabled = false;
            txtSinifi.Enabled = false;
            txtOgrenciNo.Enabled = false;
            txtOgrenciSoyad.Enabled = false;
            var itemlist = client.TumSiniflar(par.KullaniciAdi, par.Sifre, par.Departman);       
            comboBox1.Items.Insert(0, "Seçiniz");
            foreach (var item in itemlist)
            {
                comboBox1.Items.Add(item.sinifAdi);
                comboBox1.Items.Insert(item.sinifId, item.sinifAdi);
            }
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //using (SqlDataAdapter da = new SqlDataAdapter("sp_SinifaGoreOgrenciGetir", cnn))
            //{
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            //    da.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //}
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtOgrenciNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtOgrenciAd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtOgrenciSoyad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSinifi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("sp_YoklamaEkle", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@OgrenciId", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            //cmd.Parameters.Add("@OgrenciAdi", dataGridView1.CurrentRow.Cells[3].Value.ToString());
            //cmd.Parameters.Add("@OgrenciSoyadi", dataGridView1.CurrentRow.Cells[4].Value.ToString());
            //cmd.Parameters.Add("@Sinifi", comboBox1.Text);
            //cmd.Parameters.Add("@Tarih", dateTimePicker1.Text);
            //cmd.Parameters.Add("@DevamsizlikTuru", cmbDurum.Text);
            //cmd.Parameters.Add("@Aciklama", txtAciklama.Text);
            //cmd.Parameters.Add("@SinifId", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            //try
            //{
            //    cnn.Open();
            //    cmd.ExecuteScalar();
            //    MessageBox.Show("Kayıt Başarılı");
            //}
            //catch
            //{
            //    MessageBox.Show("Hata Oluştu");
            //}
            //finally
            //{
            //    cnn.Close();
            //}
        }

        private void btnYoklamaDurum_Click(object sender, EventArgs e)
        {
            YoklamaDurum yoklama = new YoklamaDurum();
            yoklama.Show();
        }




    }
}
