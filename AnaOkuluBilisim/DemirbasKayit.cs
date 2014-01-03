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
                DemirId=client.DemirbasEkle(par.KullaniciAdi, par.Sifre, par.Departman, new DemirbaslarDB
                {
                    Adi = txtDemirbasAdi.Text.ToUpper(),
                    Turu = txtDemirbasTuru.Text.ToUpper(),
                    Cinsi = txtDemirbasCinsi.Text.ToUpper(),
                    Adet = Convert.ToInt32(txtDemirbasAdeti.Text),
                    Birim = txtDemirbasBirimi.Text.ToUpper(),
                    AlindigiYer = txtAlindigiYer.Text.ToUpper(),
                    GirisTutari = Convert.ToDecimal(txtGirisTutari.Text),
                    AlisFaturaNo = txtAlisFaturaNo.Text.ToUpper(),
                    KdvOrani = Convert.ToInt32(txtKdvOrani.Text),
                    KdvTutari = Convert.ToDecimal(txtKdvTutari.Text),
                    SatisYeri = txtSatisYeri.Text.ToUpper(),
                    SatisTarihi = dateTimePicker2.Value,
                    SatisTutari = Convert.ToDecimal(txtSatisTutari.Text),
                    SatisFaturaNo = txtSatisFaturaNo.Text.ToUpper(),
                    SatisKdvTutari = Convert.ToDecimal(txtSatisKdvTutari.Text),
                    SatisNedeni = txtSatisNedeni.Text.ToUpper(),
                });
                if (DemirId != 0)
                {
                    textBox1.Text = DemirId.ToString();
                    textBox1.Enabled = false;
                    MessageBox.Show("Kayıt Başarılı.");
                }
                else
                    MessageBox.Show("Kayıt Başarısız.");
            }
            catch(Exception err)
            {
                MessageBox.Show("Hata Oluştu."+err);
            }
            finally
            {
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
            try
            {
                dataGridView1.DataSource = client.TumDemirbaslar(par.KullaniciAdi, par.Sifre, par.Departman);
                dataGridView1.Columns["DEMIRBASID"].Visible = false;
                dataGridView1.Columns["SatisNedeni"].Visible = false;
                dataGridView1.Columns["SatisKdvTutari"].Visible = false;
                dataGridView1.Columns["SatisFaturaNo"].Visible = false;
                dataGridView1.Columns["SatisTutari"].Visible = false;
                dataGridView1.Columns["SatisTarihi"].Visible = false;
                dataGridView1.Columns["SatisYeri"].Visible = false;
                dataGridView1.Columns["KdvTutari"].Visible = false;
                dataGridView1.Columns["KdvOrani"].Visible = false;
                
            }
            catch (Exception err)
            {
                this.Close();
            }
        }
    public void DemirbasMekanGetir ()
    {
        try
        {
            dataGridView2.DataSource = client.TumDemirbasMekanlari(par.KullaniciAdi, par.Sifre, par.Departman);
            dataGridView2.Columns["MekanId"].Visible = false;
            dataGridView2.Columns["DemirbasId"].Visible = false;
        }
        catch (Exception err)
        {
            this.Close();
        }

    }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (client.DemirbasSil(par.KullaniciAdi, par.Sifre, par.Departman, Convert.ToInt32(dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value)))
            {
                DemirbasGetir();
                MessageBox.Show("Kayıt Silindi.");
            }
            else
                MessageBox.Show("Kayıt Silinemedi");

        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            DmrBasGuncelle.ShowDialog();
        }

        private void btnMekanKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DemirId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value);
                if (client.DemirbasMekanlariEkle(par.KullaniciAdi, par.Sifre, par.Departman, new DemirbasMekanlariDB
                {
                    Adet=Convert.ToInt32(txtAdeti.Text),
                    BulunduguYer=txtBulunduguYer.Text.ToUpper(),
                    DemirbasId=DemirId,
                    Sorumlusu=txtSorumlusu.Text.ToUpper(),
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
        }
        private void btnMekanSil_Click(object sender, EventArgs e)
        {
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
            txtAdeti.Clear();
            txtAlindigiYer.Clear();
            txtAlisFaturaNo.Clear();
            txtBulunduguYer.Clear();
            txtDemirbasAdeti.Text="0";
            txtDemirbasAdi.Clear();
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

        private void txtKdvOrani_Leave(object sender, EventArgs e)
        {
            try
            {
                txtKdvTutari.Text = (Convert.ToDecimal(txtGirisTutari.Text) * Convert.ToInt32(txtKdvOrani.Text) / 100).ToString();
                txtKdvTutari.Enabled = false;
            }
            catch (Exception err)
            {
                txtKdvOrani.Text = "0";
            }
        }

        private void txtSatisKdvOrani_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSatisKdvTutari.Text = (Convert.ToDecimal(txtSatisTutari.Text) * Convert.ToInt32(txtSatisKdvOrani.Text) / 100).ToString();
                txtSatisKdvTutari.Enabled = false;
            }
            catch (Exception err)
            {
                txtSatisKdvOrani.Text = "0";
            }
        }

 

   

   

     

      

      










    }


}
