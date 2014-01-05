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

namespace AnaOkuluBilisim
{
    public partial class DemirbasKayit : Form
    {
        DemirBasGuncelle DmrBasGuncelle;

        public DemirbasKayit()
        {
            InitializeComponent();
            DmrBasGuncelle = new DemirBasGuncelle();
            DmrBasGuncelle.DmrBasKayit = this;
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void DemirbasKayit_Load(object sender, EventArgs e)
        {            
            DemirbasGetir();
            DemirbasMekanGetir();
        }
        int DemirId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           try
           { 

                SqlCommand cmd = new SqlCommand("sp_DemirbasEkle", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Adi", txtDemirbasAdi.Text);
                cmd.Parameters.Add("@Turu", txtDemirbasTuru.Text);
                cmd.Parameters.Add("@Cinsi", txtDemirbasCinsi.Text);
                cmd.Parameters.Add("@Adet", Convert.ToInt32(txtDemirbasAdeti.Text));
                cmd.Parameters.Add("@Birim", txtDemirbasBirimi.Text);
                cmd.Parameters.Add("@Alindigiyer", txtAlindigiYer.Text);
                cmd.Parameters.Add("@AlisTarihi", txtAlisTarihi.Value);
                cmd.Parameters.Add("@GirisTutari", Convert.ToDecimal(txtGirisTutari.Text));
                cmd.Parameters.Add("@AlisFaturaNo", txtAlisFaturaNo.Text);
                cmd.Parameters.Add("@KdvOrani", Convert.ToInt32(txtKdvOrani.Text));
                cmd.Parameters.Add("@KdvTutari", Convert.ToDecimal(txtKdvTutari.Text));
                cmd.Parameters.Add("@SatisYeri", txtSatisYeri.Text);
                cmd.Parameters.Add("@SatisTarihi", txtSatisTarihi.Value);
                cmd.Parameters.Add("@SatisTutari", Convert.ToDecimal(txtSatisTutari.Text));
                cmd.Parameters.Add("@SatisFaturaNo", txtSatisFaturaNo.Text);
                cmd.Parameters.Add("@SatisKdvTutari", Convert.ToDecimal(txtSatisKdvTutari.Text));
                cmd.Parameters.Add("@SatisNedeni", txtSatisNedeni.Text);
                cmd.Parameters.Add(new SqlParameter("@DemirbasID", SqlDbType.Int));
                cmd.Parameters["@DemirbasID"].Direction = ParameterDirection.Output;
           
                cnn.Open();
                cmd.ExecuteNonQuery();

                DemirId = Convert.ToInt32(cmd.Parameters["@DemirbasID"].Value);
                txtdemirbasidno.Text = DemirId.ToString();
                txtAdeti.Text = txtDemirbasAdeti.Text;
                txtTeslimTarihi.Value = txtAlisTarihi.Value;
                MessageBox.Show("Kayıt Başarılı.");
            }
            catch(Exception err)
            {
                MessageBox.Show("Hata Oluştu."+err.Message);
            }
            finally
            {
                cnn.Close();
                DemirbasGetir();
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
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(panel1);
            ClearTextBoxes(panel2);
        }
        public void DemirbasGetir()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select * from demirbaslar", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    public void DemirbasMekanGetir ()
    {
        DataTable dt = new DataTable();
        dt.Clear();
        SqlDataAdapter da = new SqlDataAdapter("select * from demirbasmekanlari",cnn);
        da.Fill(dt);
        dataGridView2.DataSource = dt;

    }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("delete from Demirbaslar where DEMIRBASID=@id",cnn))
                {
                    cnn.Open();
                    cmd.Parameters.Add("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value));
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                DemirbasGetir();
                MessageBox.Show("Kayıt Silindi.");
            }
            catch (Exception err)
            {



            }
            finally
            {
                cnn.Close();
            }

        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            DmrBasGuncelle.ShowDialog();
        }

        private void btnMekanKaydet_Click(object sender, EventArgs e)
        {
            
            try
            {

                using (SqlCommand cmd = new SqlCommand("sp_DemirbasMekaniEkle", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DemirbasId", Convert.ToInt32(txtdemirbasidno.Text));
                    cmd.Parameters.Add("@BulunduguYer", txtBulunduguYer.Text);
                    cmd.Parameters.Add("@Adet", Convert.ToInt32(txtAdeti.Text));
                    cmd.Parameters.Add("@Sorumlusu", txtSorumlusu.Text);
                    cmd.Parameters.Add("@TeslimTarihi", txtTeslimTarihi.Value);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mekanlar Eklendi");
                    DemirbasMekanGetir();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Hata Oluştu");
            }
            finally
            {
                cnn.Close();

            }
        }
        private void btnMekanSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from DemirbasMekanlari where MekanId='"+dataGridView2.CurrentRow.Cells[0].Value.ToString()+"'  ",cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Veri Silindi.");
            DemirbasMekanGetir();         
        }

        private void txtKdvOrani_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKdvOrani_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGirisTutari.Text == null || txtGirisTutari.Text == "") throw new Exception("Giriş Tutarı boş");
                txtKdvTutari.Text = ((Convert.ToDecimal(txtGirisTutari.Text) * Convert.ToInt32(txtKdvOrani.Text) / 100) + Convert.ToDecimal(txtGirisTutari.Text)).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtSatisKdvOrani_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSatisTutari.Text == null || txtSatisTutari.Text == "") throw new Exception("Giriş Tutarı boş");
                txtSatisKdvTutari.Text = ((Convert.ToDecimal(txtSatisTutari.Text) * Convert.ToInt32(txtSatisKdvOrani.Text) / 100) + Convert.ToDecimal(txtSatisTutari.Text)).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBulunduguYer.Clear();
            txtSorumlusu.Clear();
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {

        }

 

   

   

     

      

      










    }


}
