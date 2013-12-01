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
    public partial class DemirBasGuncelle : Form
    {
        public DemirbasKayit DmrBasKayit;
        public DemirBasGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");


        private void DemirBasGuncelle_Load(object sender, EventArgs e)
        {
            txtDemirbasAdi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDemirbasTuru.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDemirbasCinsi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDemirbasAdeti.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDemirbasBirimi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAlindigiYer.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtAlisTarihi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtGirisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtAlisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtKdvOrani.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtSatisYeri.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtSatisTarihi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtSatisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txtSatisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txtSatisKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[16].Value.ToString();
            txtSatisNedeni.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[17].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(" update Demirbaslar set Adi='" + txtDemirbasAdi.Text + "',Turu='" + txtDemirbasTuru.Text + "',Cinsi='" + txtDemirbasCinsi.Text + "',Adet='" + txtDemirbasAdeti.Text + "',Birim='" + txtDemirbasBirimi.Text + "',AlindigiYer='" + txtAlindigiYer.Text + "',AlisTarihi='" + txtAlisTarihi.Text + "',GirisTutari='" + txtGirisTutari.Text + "',AlisFaturaNo='" + txtAlisFaturaNo.Text + "',KdvOrani='" + txtKdvOrani.Text + "',KdvTutari='" + txtKdvTutari.Text + "',SatisYeri='" + txtSatisYeri.Text + "',SatisTarihi='" + txtSatisTarihi.Text + "',SatisTutari='" + txtSatisTutari.Text + "',SatisFaturaNo='" + txtSatisFaturaNo.Text + "',SatisKdvTutari='" + txtSatisKdvTutari.Text + "',SatisNedeni='" + txtSatisNedeni.Text + "'", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            DmrBasKayit.DemirbasGetir();
            MessageBox.Show("Kayıt Güncellendi.");
        }
    }
}
