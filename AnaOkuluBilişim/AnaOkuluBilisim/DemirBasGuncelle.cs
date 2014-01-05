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
    public partial class DemirBasGuncelle : Form
    {
        public DemirbasKayit DmrBasKayit;
        int id;
        public DemirBasGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);


        private void DemirBasGuncelle_Load(object sender, EventArgs e)
        {
            
            txtDemirbasAdi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            txtDemirbasTuru.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["Turu"].Value.ToString();
            txtDemirbasCinsi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["Cinsi"].Value.ToString();
            txtDemirbasAdeti.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["Adet"].Value.ToString();
            txtDemirbasBirimi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["Birim"].Value.ToString();
            txtAlindigiYer.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["AlindigiYer"].Value.ToString();
            txtAlisTarihi.Value = Convert.ToDateTime(DmrBasKayit.dataGridView1.CurrentRow.Cells["AlisTarihi"].Value.ToString());
            txtGirisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["GirisTutari"].Value.ToString();
            txtAlisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["AlisFaturaNo"].Value.ToString();
            txtKdvOrani.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["KdvOrani"].Value.ToString();
            txtKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["KdvTutari"].Value.ToString();
            txtSatisYeri.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisYeri"].Value.ToString();
            txtSatisTarihi.Value = Convert.ToDateTime(DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisTarihi"].Value.ToString());
            txtSatisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisTutari"].Value.ToString();
            txtSatisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisFaturaNo"].Value.ToString();
            txtSatisKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisKdvTutari"].Value.ToString();
            txtSatisNedeni.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells["SatisNedeni"].Value.ToString();
            id = Convert.ToInt32(DmrBasKayit.dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                cnn.Open();
                SqlCommand cmd = new SqlCommand(" update Demirbaslar set Adi=@ad," +
                    "Turu=@turu," +
                    "Cinsi=@cinsi," +
                    "Adet=@adet," +
                    "Birim=@birim," +
                    "AlindigiYer=@alindigiyer," +
                    "AlisTarihi=@alistarihi," +
                    "GirisTutari=@giristutari," +
                    "AlisFaturaNo=@faturano," +
                    "KdvOrani=@kdvorani," +
                    "KdvTutari=@kdvtutari," +
                    "SatisYeri=@satisyeri," +
                    "SatisTarihi=@satistarihi," +
                    "SatisTutari=@satistutari," +
                    "SatisFaturaNo=@satisFaturano," +
                    "SatisKdvTutari=@satiskdvtutari," +
                    "SatisNedeni=@satisnedeni where DEMIRBASID=@id", cnn);
                cmd.Parameters.Add("@ad", txtDemirbasAdi.Text);
                cmd.Parameters.Add("@turu", txtDemirbasTuru.Text);
                cmd.Parameters.Add("@cinsi", txtDemirbasCinsi.Text);
                cmd.Parameters.Add("@adet", txtDemirbasAdeti.Text);
                cmd.Parameters.Add("@birim", txtDemirbasBirimi.Text);
                cmd.Parameters.Add("@alindigiyer", txtAlindigiYer.Text);
                cmd.Parameters.Add("@alistarihi", txtAlisTarihi.Value);
                cmd.Parameters.Add("@giristutari", Convert.ToDecimal(txtGirisTutari.Text));
                cmd.Parameters.Add("@faturano", txtAlisFaturaNo.Text);
                cmd.Parameters.Add("@kdvorani", Convert.ToInt32(txtKdvOrani.Text));
                cmd.Parameters.Add("@kdvtutari", Convert.ToDecimal(txtKdvTutari.Text));
                cmd.Parameters.Add("@satisyeri", txtSatisYeri.Text);
                cmd.Parameters.Add("@satistarihi", txtSatisTarihi.Value);
                cmd.Parameters.Add("@satistutari", Convert.ToDecimal(txtSatisTutari.Text));
                cmd.Parameters.Add("@satisfaturano", txtSatisFaturaNo.Text);
                cmd.Parameters.Add("@satiskdvtutari", Convert.ToDecimal(txtSatisKdvTutari.Text));
                cmd.Parameters.Add("@satisnedeni", txtSatisNedeni.Text);
                cmd.Parameters.Add("@id", id);
                cmd.ExecuteNonQuery();
                cnn.Close();
                DmrBasKayit.DemirbasGetir();
                MessageBox.Show("Kayıt Güncellendi.");
            }
            catch (Exception err)
            {

            }
        }
    }
}
