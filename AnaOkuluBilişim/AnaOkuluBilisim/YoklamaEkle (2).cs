using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class YoklamaEkle : Form
    {
        public YoklamaEkle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        IList<Sinif> siniflar = new List<Sinif>();
        private void YoklamaEkle_Load(object sender, EventArgs e)
        {
            cmbDurum.Items.Add("Katıldı");
            cmbDurum.Items.Add("Katılmadı");
            txtOgrenciAd.Enabled = false;
            txtSinifi.Enabled = false;
            txtOgrenciNo.Enabled = false;
            txtOgrenciSoyad.Enabled = false;
            using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", cnn))
            {

                cnn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
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
                    comboBox1.Items.Add(rdr["sinifAdi"].ToString());
                }
                cnn.Close();

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("select o.OgrenciId as OgreciNo,o.Adi as OgrenciAdi,o.Soyadi as OgrenciSoyadi from Siniflar s,Ogrenciler o where s.sinifId=o.SinifId and s.sinifId=@id", cnn))
                {
                    cnn.Open();
                    da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = siniflar[comboBox1.SelectedIndex].SinifID;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    cnn.Close();
                }
            }
            catch (Exception err)
            {


            }

        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
          
                SqlCommand cmd = new SqlCommand("sp_YoklamaEkle", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OgrenciId", Convert.ToInt32(dataGridView1.CurrentRow.Cells["OgreciNo"].Value));
                cmd.Parameters.Add("@Tarih", dateTimePicker1.Value);
                cmd.Parameters.Add("@DevamsizlikTuru", cmbDurum.Text);
                cmd.Parameters.Add("@Aciklama", txtAciklama.Text);
                cmd.Parameters.Add("@SinifId", siniflar[comboBox1.SelectedIndex].SinifID);
         
          
            try
            {
                cnn.Open();
                cmd.ExecuteScalar();
                MessageBox.Show("Kayıt Başarılı");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu. Bu kişiyi Daha Önceden Kayıt Etmiş Olabilirsiniz");
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnYoklamaDurum_Click(object sender, EventArgs e)
        {
            YoklamaDurum yoklama = new YoklamaDurum();
            yoklama.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtOgrenciNo.Text = dataGridView1.CurrentRow.Cells["OgreciNo"].Value.ToString();
                txtOgrenciAd.Text = dataGridView1.CurrentRow.Cells["OgrenciAdi"].Value.ToString();
                txtOgrenciSoyad.Text = dataGridView1.CurrentRow.Cells["OgrenciSoyadi"].Value.ToString();
                txtSinifi.Text = siniflar[comboBox1.SelectedIndex].SinifAdi;
            }
            catch (Exception err)
            {
                MessageBox.Show("hata olustu");
            }
        }




    }
}
