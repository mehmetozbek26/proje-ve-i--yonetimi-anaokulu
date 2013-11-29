using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        private void DemirbasKayit_Load(object sender, EventArgs e)
        {            
            DemirbasGetir();
            DemirbasMekanGetir();
        }
        int DemirId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("sp_DemirbasEkle", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Adi", txtDemirbasAdi.Text);
            cmd.Parameters.Add("@Turu", txtDemirbasTuru.Text);
            cmd.Parameters.Add("@Cinsi", txtDemirbasCinsi.Text);
            cmd.Parameters.Add("@Adet", txtDemirbasAdeti.Text);
            cmd.Parameters.Add("@Birim", txtDemirbasBirimi.Text);
            cmd.Parameters.Add("@Alindigiyer", txtAlindigiYer.Text);
            cmd.Parameters.Add("@AlisTarihi", txtAlisTarihi.Text);
            cmd.Parameters.Add("@GirisTutari", txtGirisTutari.Text);
            cmd.Parameters.Add("@AlisFaturaNo", txtAlisFaturaNo.Text);
            cmd.Parameters.Add("@KdvOrani", txtKdvOrani.Text);
            cmd.Parameters.Add("@KdvTutari", txtKdvTutari.Text);
            cmd.Parameters.Add("@SatisYeri", txtSatisYeri.Text);
            cmd.Parameters.Add("@SatisTarihi", txtSatisTarihi.Text);
            cmd.Parameters.Add("@SatisTutari", txtSatisTutari.Text);
            cmd.Parameters.Add("@SatisFaturaNo", txtSatisFaturaNo.Text);
            cmd.Parameters.Add("@SatisKdvTutari", txtSatisKdvTutari.Text);
            cmd.Parameters.Add("@SatisNedeni", txtSatisNedeni.Text);
            try
            {
                cnn.Open();
                DemirId = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("Kayıt Başarılı.");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu.");
            }
            finally
            {
                cnn.Close();
                DemirbasGetir();
            }
        }