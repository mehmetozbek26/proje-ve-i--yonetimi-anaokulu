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
    public partial class PersonelGuncelle : Form
    {
        public PersonelKayit prskayit;

        public PersonelGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        int id = 0;
        private void PersonelGuncelle_Load(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(prskayit.dataGridView1.CurrentRow.Cells["PersonelId"].Value);
                txtAd.Text = prskayit.dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
                txtSoyad.Text = prskayit.dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
                txtSicilNo.Text = prskayit.dataGridView1.CurrentRow.Cells["SicilNo"].Value.ToString();
                txtBasvuruTarihi.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["BasvuruTarihi"].Value;
                txtBaslamaTarihi.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["BaslamaTarihi"].Value;
                for (int i = 0; i < cmbAskerlikDurumu.Items.Count; i++)
                    if (cmbAskerlikDurumu.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["AskerlikDurumu"].Value.ToString())
                    {
                        cmbAskerlikDurumu.SelectedIndex = i;
                        break;
                    }

                txtTecilBitisYili.Text = prskayit.dataGridView1.CurrentRow.Cells["TecilBitisYili"].Value.ToString();
                for (int i = 0; i < cmbKanGrubu.Items.Count; i++)
                    if (cmbKanGrubu.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["KanGrubu"].Value.ToString())
                    {
                        cmbKanGrubu.SelectedIndex = i;
                        break;
                    }
                for (int i = 0; i < cmbCinsiyet.Items.Count; i++)
                    if (cmbCinsiyet.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString())
                    {
                        cmbCinsiyet.SelectedIndex = i;
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                txtAdres.Text = prskayit.dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
                txtSemt.Text = prskayit.dataGridView1.CurrentRow.Cells["Semt"].Value.ToString();
                txtilce.Text = prskayit.dataGridView1.CurrentRow.Cells["Ilce"].Value.ToString();
                txtil.Text = prskayit.dataGridView1.CurrentRow.Cells["il"].Value.ToString();
                txtMail.Text = prskayit.dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
                txtEvTel.Text = prskayit.dataGridView1.CurrentRow.Cells["EvTel"].Value.ToString();
                txtCepTel.Text = prskayit.dataGridView1.CurrentRow.Cells["CepTel"].Value.ToString();
                for (int i = 0; i < cmbOgrenimDurumu.Items.Count; i++)
                    if (cmbOgrenimDurumu.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["EgitimDurumu"].Value.ToString())
                    {
                        cmbOgrenimDurumu.SelectedIndex = i;
                        break;
                    }


                txtTcNo.Text = prskayit.dataGridView1.CurrentRow.Cells["TcNo"].Value.ToString();
                textBox1.Text = txtTcNo.Text;
                for (int i = 0; i < cmbDepartman.Items.Count; i++)
                    if (cmbDepartman.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["Departman"].Value.ToString())
                    {
                        cmbDepartman.SelectedIndex = i;
                        break;
                    }

                textBox1.Text = prskayit.dataGridView1.CurrentRow.Cells[21].Value.ToString();
                for (int i = 0; i < txtUyruk.Items.Count; i++)
                    if (txtUyruk.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["Kuyruk"].Value.ToString())
                    {
                        txtUyruk.SelectedIndex = i;
                        break;
                    }


                for (int i = 0; i < cmbKayitDurumu.Items.Count; i++)
                    if (cmbKayitDurumu.Items[i].ToString() == prskayit.dataGridView1.CurrentRow.Cells["Durumu"].Value.ToString())
                    {
                        cmbKayitDurumu.SelectedIndex = i;
                        break;
                    }
                txtKimlikSeriNo.Text = prskayit.dataGridView1.CurrentRow.Cells["KkimlikSeriNo"].Value.ToString();
                txtDogumYeri.Text = prskayit.dataGridView1.CurrentRow.Cells["KdogumYeri"].Value.ToString();
                txtDogumTarihi.Value = (DateTime)prskayit.dataGridView1.CurrentRow.Cells["KdogumTarihi"].Value;
                txtKimlikil.Text = prskayit.dataGridView1.CurrentRow.Cells["Kdogumili"].Value.ToString();
                txtKimlikilce.Text = prskayit.dataGridView1.CurrentRow.Cells["Kdogumilce"].Value.ToString();
                txtMahalle.Text = prskayit.dataGridView1.CurrentRow.Cells["Kmahalle"].Value.ToString();
                txtKoy.Text = prskayit.dataGridView1.CurrentRow.Cells["Kkoy"].Value.ToString();
                txtCilt.Text = prskayit.dataGridView1.CurrentRow.Cells["Kcilt"].Value.ToString();
                txtAile.Text = prskayit.dataGridView1.CurrentRow.Cells["Kaile"].Value.ToString();
                txtSiraNo.Text = prskayit.dataGridView1.CurrentRow.Cells["KSiraNo"].Value.ToString();
                txtVerYeri.Text = prskayit.dataGridView1.CurrentRow.Cells["KVerilisYeri"].Value.ToString();
                txtKayitNo.Text = prskayit.dataGridView1.CurrentRow.Cells["KKayitNo"].Value.ToString();

            }
            catch (Exception err)
            {


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State != ConnectionState.Open)
                    cnn.Open();
                if (cmbDepartman.SelectedIndex < 0) throw new Exception("Departman Seçiniz");
                if (cmbAskerlikDurumu.SelectedIndex < 0) throw new Exception("Askerlik Durumunu Seçiniz");
                if (cmbKanGrubu.SelectedIndex < 0) throw new Exception("Kan Grubu Seçiniz");
                if (cmbCinsiyet.SelectedIndex < 0) throw new Exception("Cinsiyeti Seçiniz");
                if (cmbOgrenimDurumu.SelectedIndex < 0) throw new Exception("Öğrenim Durumunu Seçiniz");
                if (cmbKayitDurumu.SelectedIndex < 0) throw new Exception("Kayıt Durumunu Seçiniz");


                SqlCommand cmd = new SqlCommand("update Personeller set " +
                    "Adi='" + txtAd.Text + "'," +
                    "SoyAdi='" + txtSoyad.Text + "'," +
                    "SicilNo='" + txtSicilNo.Text + "'," +
                    "BasvuruTarihi='" + txtBasvuruTarihi.Value.Year + "-" + txtBasvuruTarihi.Value.Month + "-" + txtBasvuruTarihi.Value.Day + "'," +
                    "BaslamaTarihi='" + txtBaslamaTarihi.Value.Year + "-" + txtBaslamaTarihi.Value.Month + "-" + txtBaslamaTarihi.Value.Day + "'," +
                    "AskerlikDurumu='" + cmbAskerlikDurumu.Items[cmbAskerlikDurumu.SelectedIndex].ToString() + "'," +
                    "TecilBitisYili='" + txtTecilBitisYili.Text + "'," +
                    "KanGrubu='" + cmbKanGrubu.Items[cmbKanGrubu.SelectedIndex].ToString() + "'," +
                    "Cinsiyet='" + cmbCinsiyet.Items[cmbCinsiyet.SelectedIndex].ToString() + "'," +
                    "Adres='" + txtAdres.Text + "'," +
                    "Semt='" + txtSemt.Text + "'," +
                    "Ilce='" + txtilce.Text + "'," +
                    "il='" + txtil.Text + "'," +
                    "Mail='" + txtMail.Text + "'," +
                    "EvTel='" + txtEvTel.Text + "'," +
                    "CepTel='" + txtCepTel.Text + "'," +
                    "EgitimDurumu='" + cmbOgrenimDurumu.Items[cmbOgrenimDurumu.SelectedIndex].ToString() + "'," +
                    "TcNo='" + txtTcNo.Text + "'," +
                    "Durumu='" + cmbKayitDurumu.Items[cmbKayitDurumu.SelectedIndex].ToString() + "'," +
                    "Departman='" + cmbDepartman.Items[cmbDepartman.SelectedIndex].ToString() + "'," +
                    "Kuyruk='" + txtUyruk.Text + "'," +
                    "KkimlikSeriNo='" + txtKimlikSeriNo.Text + "'," +
                    "KdogumYeri='" + txtDogumYeri.Text + "'," +
                    "KdogumTarihi='" + txtDogumTarihi.Value.Year + "-" + txtDogumTarihi.Value.Month + "-" + txtDogumTarihi.Value.Day + "'," +
                    "Kdogumili='" + txtKimlikil.Text + "'," +
                    "Kdogumilce='" + txtKimlikilce.Text + "'," +
                    "Kmahalle='" + txtMahalle.Text + "'," +
                    "Kkoy='" + txtKoy.Text + "'," +
                    "Kcilt='" + txtCilt.Text + "'," +
                    "Kaile='" + txtAile.Text + "'," +
                    "KSiraNo='" + txtSiraNo.Text + "'," +
                    "KVerilisYeri='" + txtVerYeri.Text + "'," +
                    "KKayitNo='" + txtKayitNo.Text + "' WHERE PersonelId=" + id, cnn);
                cmd.ExecuteNonQuery();
                if (cmbDepartman.SelectedIndex == 0)
                {
                    cmd.CommandText = "Update Ogretmenler set Adi='" + txtAd.Text + "'," + "SoyAdi='" + txtSoyad.Text + "' where PersonelID=" + id;
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
                prskayit.PersonelGetir();
                MessageBox.Show("Güncelleme gerçekleşti.");
                this.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
