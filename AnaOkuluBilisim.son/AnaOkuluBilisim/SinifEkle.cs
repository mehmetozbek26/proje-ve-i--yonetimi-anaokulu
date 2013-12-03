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
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["MERKANVERTB"].ToString());
        //SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        public void sinifbilgileri()
        {
            DataTable dtt = new DataTable();
            cnn.Open();
            SqlDataAdapter dat = new SqlDataAdapter("Select * from Siniflar", cnn);
            dat.Fill(dtt);
            dataGridView2.DataSource = dtt;
            cnn.Close();
        }
        private void SinifEkle_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select o.PersonelID, o.Adi,o.Soyadi,p.TcNo from Ogretmenler o,Personeller p where o.PersonelID=p.PersonelId", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cnn.Close();

            sinifbilgileri();



            txtOgretmenAdi.Enabled = false;
            txtOgretmenSoyAdi.Enabled = false;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtOgretmenAdi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            txtOgretmenSoyAdi.Text = dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["PersonelID"].Value == null || dataGridView1.CurrentRow.Cells["PersonelID"].Value == "")
                    throw new Exception("Öğtermen Seçilmedi");
                SqlCommand cmd = new SqlCommand("sp_SinifEkle", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SinifAdi", txtSinifAdi.Text);
                cmd.Parameters.Add("@KapaSitesi", txtKapasite.Text);
                cmd.Parameters.Add("@OgretmenId", dataGridView1.CurrentRow.Cells["PersonelID"].Value.ToString());
                cmd.Parameters.Add(new SqlParameter("@Returnid", SqlDbType.Int));
                cmd.Parameters["@Returnid"].Direction = ParameterDirection.Output;
                cnn.Open();
                cmd.ExecuteNonQuery();

                ogrId = Convert.ToInt32(cmd.Parameters["@Returnid"].Value.ToString());

                MessageBox.Show("Sinif Eklendi." + ogrId);
                cnn.Close();
                sinifbilgileri();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
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

     






    }
}
