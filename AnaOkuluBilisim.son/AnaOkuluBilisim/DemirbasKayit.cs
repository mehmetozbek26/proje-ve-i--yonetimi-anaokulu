using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.Models;
using AnaOkuluBilisim.AnaOkuluService;

namespace AnaOkuluBilisim
{
    public partial class DemirbasKayit : Form
    {
        #region DEĞİŞKENLER
        DemirBasGuncelle DmrBasGuncelle;
        Parola par = Parola.GET();
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        #endregion

        public DemirbasKayit()
        {
            InitializeComponent();
            DmrBasGuncelle = new DemirBasGuncelle();
            DmrBasGuncelle.DmrBasKayit = this;
        }
        //SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        SqlConnection cnn = new SqlConnection("Data Source=MERKANPC;Initial Catalog=AnaOkuluDB;Integrated Security=True");
        private void DemirbasKayit_Load(object sender, EventArgs e)
        {            
            DemirbasGetir();
            DemirbasMekanGetir();
        }
        int DemirId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            //SqlCommand cmd = new SqlCommand("sp_DemirbasEkle", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@Adi", txtDemirbasAdi.Text);
            //cmd.Parameters.Add("@Turu", txtDemirbasTuru.Text);
            //cmd.Parameters.Add("@Cinsi", txtDemirbasCinsi.Text);
            //cmd.Parameters.Add("@Adet", txtDemirbasAdeti.Text);
            //cmd.Parameters.Add("@Birim", txtDemirbasBirimi.Text);
            //cmd.Parameters.Add("@Alindigiyer", txtAlindigiYer.Text);
            //cmd.Parameters.Add("@AlisTarihi", dateTimePicker1.Value);
            //cmd.Parameters.Add("@GirisTutari", txtGirisTutari.Text);
            //cmd.Parameters.Add("@AlisFaturaNo", txtAlisFaturaNo.Text);
            //cmd.Parameters.Add("@KdvOrani", txtKdvOrani.Text);
            //cmd.Parameters.Add("@KdvTutari", txtKdvTutari.Text);
            //cmd.Parameters.Add("@SatisYeri", txtSatisYeri.Text);
            //cmd.Parameters.Add("@SatisTarihi",dateTimePicker2.Value);
            //cmd.Parameters.Add("@SatisTutari", txtSatisTutari.Text);
            //cmd.Parameters.Add("@SatisFaturaNo", txtSatisFaturaNo.Text);
            //cmd.Parameters.Add("@SatisKdvTutari", txtSatisKdvTutari.Text);
            //cmd.Parameters.Add("@SatisNedeni", txtSatisNedeni.Text);
            //cmd.Parameters.Add(new SqlParameter("@DemirbasID", SqlDbType.Int));
            //cmd.Parameters["@DemirbasID"].Direction = ParameterDirection.Output;
            try
            {
                if (client.DemirbasEkle(par.KullaniciAdi, par.Sifre, par.Departman, new DemirbaslarDB
                {
                    Adi = txtDemirbasAdi.Text,
                    Turu = txtDemirbasTuru.Text,
                    Cinsi = txtDemirbasCinsi.Text,
                    Adet = Convert.ToInt32(txtDemirbasAdeti.Text),
                    Birim = txtDemirbasBirimi.Text,
                    AlindigiYer = txtAlindigiYer.Text,
                    AlisTarihi = dateTimePicker1.Value,
                    GirisTutari = Convert.ToDecimal(txtGirisTutari.Text),
                    AlisFaturaNo = txtAlisFaturaNo.Text,
                    KdvOrani = Convert.ToInt32(txtKdvOrani.Text),
                    KdvTutari = Convert.ToDecimal(txtKdvTutari.Text),
                    SatisYeri = txtSatisYeri.Text,
                    SatisTarihi = dateTimePicker2.Value,
                    SatisTutari = Convert.ToDecimal(txtSatisTutari.Text),
                    SatisFaturaNo = txtSatisFaturaNo.Text,
                    SatisKdvTutari = Convert.ToDecimal(txtSatisKdvTutari.Text),
                    SatisNedeni = txtSatisNedeni.Text,
                }))
                    MessageBox.Show("Kayıt Başarılı.");
                else
                    MessageBox.Show("Kayıt Başarısız.");
                //cnn.Open();
                //cmd.ExecuteNonQuery();
                //DemirId = Convert.ToInt32(cmd.Parameters["@DemirbasID"].Value.ToString());
                //MessageBox.Show("Kayıt Başarılı." + DemirId);
            }
            catch(Exception err)
            {
                MessageBox.Show("Hata Oluştu."+err);
            }
            finally
            {
                //cnn.Close();
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
            //DataTable dt = new DataTable();
            //dt.Clear();
            //SqlDataAdapter da = new SqlDataAdapter("select * from demirbaslar", cnn);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            dataGridView1.DataSource = client.TumDemirbaslar(par.KullaniciAdi, par.Sifre, par.Departman);
        }
    public void DemirbasMekanGetir ()
    {
        //DataTable dt = new DataTable();
        //dt.Clear();
        //SqlDataAdapter da = new SqlDataAdapter("select * from demirbasmekanlari",cnn);
        //da.Fill(dt);
        //dataGridView2.DataSource = dt;
        dataGridView2.DataSource = client.TumDemirbasMekanlari(par.KullaniciAdi, par.Sifre, par.Departman);

    }
        private void btnSil_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand();
            //cnn.Open();
            //cmd.Connection = cnn;
            //cmd.CommandText = "delete from Demirbaslar where DEMIRBASID ='" + dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value.ToString() + "' ";
            //cmd.ExecuteNonQuery();

            if (client.DemirbasSil(par.KullaniciAdi, par.Sifre, par.Departman, Convert.ToInt32(dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value)))
            {
                DemirbasGetir();
                MessageBox.Show("Kayıt Silindi.");
            }

        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            DmrBasGuncelle.ShowDialog();
        }

        private void btnMekanKaydet_Click(object sender, EventArgs e)
        {
            

            //SqlCommand cmd = new SqlCommand("sp_DemirbasMekaniEkle", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@DemirbasId", DemirId);
            //cmd.Parameters.Add("@BulunduguYer",txtBulunduguYer.Text);
            //cmd.Parameters.Add("@Adet",txtAdeti.Text);
            //cmd.Parameters.Add("@Sorumlusu",txtSorumlusu.Text);
            //cmd.Parameters.Add("@TeslimTarihi",txtTeslimTarihi.Text);
            try
            {
                //cnn.Open();
                //cmd.ExecuteNonQuery();
                DemirId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value);
                if (client.DemirbasMekanlariEkle(par.KullaniciAdi, par.Sifre, par.Departman, new DemirbasMekanlariDB
                {
                    Adet=txtAdeti.Text,
                    BulunduguYer=txtBulunduguYer.Text,
                    DemirbasId=DemirId,
                    Sorumlusu=txtSorumlusu.Text,
                    TeslimTarihi=dateTimePicker3.Value
                }))
                {
                    MessageBox.Show("Mekanlar Eklendi");
                    DemirbasMekanGetir();
                }
                else
                    MessageBox.Show("Mekanlar Eklenemedi");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
            //finally
            //{
            //    cnn.Close();

            //}
        }
        private void btnMekanSil_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("Delete from DemirbasMekanlari where MekanId='"+dataGridView2.CurrentRow.Cells[0].Value.ToString()+"'  ",cnn);
            //cnn.Open();
            //cmd.ExecuteNonQuery();
            //cnn.Close();
            if (client.DemirbasMekanlariSil(par.KullaniciAdi, par.Sifre, par.Departman, Convert.ToInt32(dataGridView2.CurrentRow.Cells["MekanId"].Value.ToString())))
            {
                MessageBox.Show("Veri Silindi.");
                DemirbasMekanGetir();
            }
            else
                MessageBox.Show("Veri Silinemedi.");
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 

   

   

     

      

      










    }


}
