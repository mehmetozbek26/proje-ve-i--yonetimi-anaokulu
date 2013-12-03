using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class DemirBasGuncelle : Form
    {
        public DemirbasKayit DmrBasKayit;
        int id = 0;
        public DemirBasGuncelle()
        {
            InitializeComponent();
        }
        //SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        SqlConnection cnn = new SqlConnection("Data Source=MERKANPC;Initial Catalog=AnaOkuluDB;Integrated Security=True");
        
        private void DemirBasGuncelle_Load(object sender, EventArgs e)
        {
            txtDemirbasAdi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDemirbasTuru.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDemirbasCinsi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDemirbasAdeti.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDemirbasBirimi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAlindigiYer.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtGirisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtAlisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtKdvOrani.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtSatisYeri.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dateTimePicker1.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtSatisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txtSatisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txtSatisKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[16].Value.ToString();
            txtSatisNedeni.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[17].Value.ToString();
            id=Convert.ToInt32(DmrBasKayit.dataGridView1.CurrentRow.Cells["DEMIRBASID"].Value.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Parola par = Parola.GET();
                AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
                if(client.DemirbasGunceller(par.KullaniciAdi,par.Sifre,par.Departman,id,txtDemirbasAdi.Text,txtDemirbasTuru.Text,txtDemirbasCinsi.Text,txtDemirbasAdeti.Text,txtDemirbasBirimi.Text,txtAlindigiYer.Text,dateTimePicker1.Value.ToShortDateString(),txtGirisTutari.Text,txtAlisFaturaNo.Text,txtKdvOrani.Text,txtKdvTutari.Text,txtSatisYeri.Text,dateTimePicker2.Value.ToShortDateString(),txtSatisTutari.Text,txtSatisFaturaNo.Text,txtSatisKdvTutari.Text,txtSatisNedeni.Text))
                {
                    DmrBasKayit.DemirbasGetir();
                    MessageBox.Show("Kayıt Güncellendi.");
                }
                else
                    throw new Exception("Kayıt Güncellenemedi");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
