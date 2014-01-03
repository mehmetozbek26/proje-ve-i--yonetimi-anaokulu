using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using AnaOkuluBilisim.AnaOkuluService;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class SinifEkle : Form
    {
        AnaOkuluWebServiceClient client = new AnaOkuluWebServiceClient();
        Parola par = Parola.GET();
        public SinifEkle()
        {
            InitializeComponent();        
        }
        int ogrId = 0;
        
        public void sinifbilgileri()
        {
            try
            {
                dataGridView2.DataSource = client.TumSiniflar(par.KullaniciAdi, par.Sifre, par.Departman);
                dataGridView2.Columns["sinifId"].Visible = false;
                dataGridView2.Columns["ögretmenId"].Visible = false;
                dataGridView2.Columns["sinifAdi"].DisplayIndex = 0;
                dataGridView2.Columns["sinifkapasite"].DisplayIndex = 1;
            }
            catch (Exception err)
            {

            }
        }
        private void SinifEkle_Load(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = client.TumOgretmenler(par.KullaniciAdi, par.Sifre, par.Departman);
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["KAYITID"].Visible = false;
                dataGridView1.Columns["TC"].Visible = false;
                dataGridView1.Columns["AD"].DisplayIndex = 0;
                dataGridView1.Columns["SOYAD"].DisplayIndex = 1;
                sinifbilgileri();
                txtOgretmenAdi.Enabled = false;
                txtOgretmenSoyAdi.Enabled = false;
            }
            catch (Exception err)
            {

            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSinifAdi.Text == "" || txtSinifAdi.Text == null) throw new Exception("Sınıf Adını Giriniz");
                if (txtKapasite.Text == "" || txtKapasite.Text == null) throw new Exception("Sınıf Kapasite Giriniz");
                if (txtOgretmenAdi.Text == "" || txtOgretmenAdi.Text == null) throw new Exception("Ogretmen Adını Giriniz");
                if (txtOgretmenSoyAdi.Text == "" || txtOgretmenSoyAdi.Text == null) throw new Exception("Ogretmen Soyadını Giriniz");              
                if (client.SinifEkle(par.KullaniciAdi, par.Sifre, par.Departman, txtSinifAdi.Text.ToUpper(), Convert.ToInt32(txtKapasite.Text), Convert.ToInt32(dataGridView1.CurrentRow.Cells["KAYITID"].Value)))
                    MessageBox.Show("Kayıt Eklendi");
                else
                    MessageBox.Show("Kayıt Eklenemedi");
                sinifbilgileri();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.SinifSil(par.KullaniciAdi, par.Sifre, par.Departman, Convert.ToInt32(dataGridView2.CurrentRow.Cells["sinifId"].Value)))
                {
                    sinifbilgileri();
                    MessageBox.Show("Kayıt Silindi");
                }
                else
                    MessageBox.Show("Kayıt Silinemedi");
            }
            catch (Exception err)
            {

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtOgretmenAdi.Text = dataGridView1.CurrentRow.Cells["AD"].Value.ToString();
            txtOgretmenSoyAdi.Text = dataGridView1.CurrentRow.Cells["SOYAD"].Value.ToString();
        }

     






    }
}
