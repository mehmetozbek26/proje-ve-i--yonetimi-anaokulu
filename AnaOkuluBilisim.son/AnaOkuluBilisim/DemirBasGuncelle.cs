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
        
        private void DemirBasGuncelle_Load(object sender, EventArgs e)
        {
            txtDemirbasAdi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDemirbasTuru.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDemirbasCinsi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDemirbasAdeti.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDemirbasBirimi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAlindigiYer.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            alistarihi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtGirisTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtAlisFaturaNo.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtKdvOrani.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtKdvTutari.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtSatisYeri.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[12].Value.ToString();
            satisTarihi.Text = DmrBasKayit.dataGridView1.CurrentRow.Cells[13].Value.ToString();
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
                Demirbaslar temp = new Demirbaslar
                {
                    DEMIRBASID=id,
                    AlindigiYer=txtAlindigiYer.Text,
                    Turu=txtDemirbasTuru.Text,
                    SatisYeri=txtSatisYeri.Text,
                    SatisTutari=Convert.ToDecimal(txtSatisTutari.Text),
                    SatisTarihi=satisTarihi.Value,
                    SatisNedeni=txtSatisNedeni.Text,
                    SatisKdvTutari=Convert.ToDecimal(txtSatisKdvTutari.Text),
                    SatisFaturaNo=txtSatisFaturaNo.Text,
                    KdvTutari=Convert.ToDecimal(txtKdvTutari.Text),
                    KdvOrani=Convert.ToInt32(txtKdvOrani.Text),
                    GirisTutari=Convert.ToDecimal(txtGirisTutari.Text),
                    Cinsi=txtDemirbasCinsi.Text,
                    Birim=txtDemirbasBirimi.Text,
                    AlisTarihi=alistarihi.Value,
                    AlisFaturaNo=txtAlisFaturaNo.Text,
                    Adi=txtDemirbasAdi.Text,
                    Adet=Convert.ToInt32(txtDemirbasAdeti.Text)
                };
                if(client.DemirbasGunceller(par.KullaniciAdi,par.Sifre,par.Departman,temp))
                {
                    DmrBasKayit.DemirbasGetir();
                    MessageBox.Show("Kayıt Güncellendi.");
                    this.Close();
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
