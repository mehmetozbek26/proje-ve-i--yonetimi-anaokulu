using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnaOkuluBilisim
{
    public partial class DERSEKLE : Form
    {
        public DERSEKLE()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void DERSEKLE_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt=new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogretmenler", cnn))
                {
                    cnn.Open();
                    da.Fill(dt);
                    dersdatagrid.DataSource = dt;
                    dersdatagrid.Update();
                    cnn.Close();
                }
                dersdatagrid.Columns["KayitId"].Visible = false;
                dersdatagrid.Columns["PersonelID"].Visible = false;
            }
            catch (Exception err)
            {


            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

        }

        private void dersdatagrid_MouseClick(object sender, MouseEventArgs e)
        {
            txtOgrAdi.Text = dersdatagrid.CurrentRow.Cells["Adi"].Value.ToString();
            txtOgrSoyad.Text = dersdatagrid.CurrentRow.Cells["Soyadi"].Value.ToString();
            txtOgrAdi.Enabled = false;
            txtOgrSoyad.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOgrAdi.Text == null || txtOgrAdi.Text == "") throw new Exception("Ogretmen Adı Boş Olamaz");
                if (txtOgrSoyad.Text == null || txtOgrSoyad.Text == "") throw new Exception("Ogretmen Soyadı Boş Olamaz");

                using (SqlCommand cmd = new SqlCommand("INSERT INTO DERSLER (DERSADI,OGRETMENID) VALUES ('" +
                    txtDersAdi.Text.ToUpper() + "'," + Convert.ToInt32(dersdatagrid.CurrentRow.Cells["KayitId"].Value) + ")", cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    Temizle();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata Oluştu " + err.Message);

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }
        private void Temizle()
        {
            txtDersAdi.Clear();
            txtOgrAdi.Clear();
            txtOgrSoyad.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
