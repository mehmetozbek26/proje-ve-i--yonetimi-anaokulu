using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace AnaOkuluBilisim
{
    public partial class SinifEkle : Form
    {
        
        public SinifEkle()
        {
            InitializeComponent();
           

        }
        int ogrId = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        public void sinifbilgileri()
        {
            DataTable dtt = new DataTable();
            cnn.Open();
            SqlDataAdapter dat = new SqlDataAdapter("Select * from Siniflar", cnn);
            dat.Fill(dtt);
            dataGridView2.DataSource = dtt;
            cnn.Close();
            dataGridView2.Columns["sinifId"].Visible = false;
            dataGridView2.Columns["ögretmenId"].Visible = false;
        }
        private void SinifEkle_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogretmenler", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();
            dataGridView1.Columns["KayitId"].Visible = false;
            dataGridView1.Columns["PersonelID"].Visible = false;
            sinifbilgileri();
            txtOgretmenAdi.Enabled = false;
            txtOgretmenSoyAdi.Enabled = false;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
          

            SqlCommand cmd = new SqlCommand("sp_SinifEkle", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SinifAdi", txtSinifAdi.Text);
            cmd.Parameters.Add("@KapaSitesi", Convert.ToInt32(txtKapasite.Text));
            cmd.Parameters.Add("@OgretmenId", ogrId);

            cnn.Open();
            cmd.ExecuteScalar();

            MessageBox.Show("Sinif Eklendi.");
            cnn.Close();
            sinifbilgileri();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "Delete from Siniflar where sinifId='" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'";
            cmd.ExecuteNonQuery();
            cnn.Close();
            sinifbilgileri();
            MessageBox.Show("Sinif Silindi");


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtOgretmenAdi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            txtOgretmenSoyAdi.Text = dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
            ogrId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KayitId"].Value);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     






    }
}
