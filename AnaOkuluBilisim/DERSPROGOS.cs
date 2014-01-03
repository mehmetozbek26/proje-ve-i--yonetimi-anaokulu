using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnaOkuluBilisim.Models;

namespace AnaOkuluBilisim
{
    public partial class DERSPROGOS : Form
    {
        public DERSPROGOS()
        {
            InitializeComponent();
        }
        IList<Sinif> siniflar = new List<Sinif>();
        IList<Dersler> dersler = new List<Dersler>();
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void DERSPROGOS_Load(object sender, EventArgs e)
        {
            try
            {
                Temizle();
                using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", baglan))
                {

                    baglan.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    siniflar.Clear();
                    cmbSinif.Items.Clear();
                    while (rdr.Read())
                    {
                        var oid = rdr["ögretmenId"].ToString();
                        var kap = rdr["sinifkapasite"].ToString();
                        siniflar.Add(new Sinif
                        {
                            OgretmenID = oid,
                            SinifAdi = rdr["sinifAdi"].ToString(),
                            SinifID = Convert.ToInt32(rdr["sinifId"].ToString()),
                            SinifKapasite = kap
                        });
                        cmbSinif.Items.Add(rdr["sinifAdi"].ToString());
                    }
                    baglan.Close();
                }
                using (SqlCommand cmd = new SqlCommand("Select * from DERSLER", baglan))
                {

                    baglan.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    dersler.Clear();
                    while (rdr.Read())
                    {

                        dersler.Add(new Dersler
                        {
                            DERSID = Convert.ToInt32(rdr["DERSID"].ToString()),
                            DERSADI = rdr["DERSADI"].ToString(),
                            OGRETMENID = Convert.ToInt32(rdr["OGRETMENID"].ToString())

                        });
                    }
                    baglan.Close();
                }
            }
            catch (Exception err)
            {

            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void cmbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using(SqlCommand cmd=new SqlCommand("select * from DersTablo where SINIFID="+siniflar[cmbSinif.SelectedIndex].SinifID,baglan))
                {
                    baglan.Open();
                    SqlDataReader rdr=cmd.ExecuteReader();
                    if (!rdr.Read()) throw new Exception("Ders Programı Yok");

                    label17.Text = DersAdiBul(Convert.ToInt32(rdr["CL0"].ToString()));
                    label18.Text=DersAdiBul(Convert.ToInt32(rdr["CL1"].ToString()));
                    label19.Text=DersAdiBul(Convert.ToInt32(rdr["CL2"].ToString()));
                    label20.Text=DersAdiBul(Convert.ToInt32(rdr["CL3"].ToString()));

                    label22.Text=DersAdiBul(Convert.ToInt32(rdr["CL4"].ToString()));
                    label23.Text=DersAdiBul(Convert.ToInt32(rdr["CL5"].ToString()));
                    label24.Text=DersAdiBul(Convert.ToInt32(rdr["CL6"].ToString()));
                    label25.Text=DersAdiBul(Convert.ToInt32(rdr["CL7"].ToString()));

                    label26.Text=DersAdiBul(Convert.ToInt32(rdr["CL8"].ToString()));
                    label27.Text=DersAdiBul(Convert.ToInt32(rdr["CL9"].ToString()));
                    label28.Text=DersAdiBul(Convert.ToInt32(rdr["CL10"].ToString()));
                    label29.Text=DersAdiBul(Convert.ToInt32(rdr["CL11"].ToString()));

                    label31.Text=DersAdiBul(Convert.ToInt32(rdr["CL12"].ToString()));
                    label32.Text=DersAdiBul(Convert.ToInt32(rdr["CL13"].ToString()));
                    label33.Text=DersAdiBul(Convert.ToInt32(rdr["CL14"].ToString()));
                    label34.Text=DersAdiBul(Convert.ToInt32(rdr["CL15"].ToString()));

                    label44.Text=DersAdiBul(Convert.ToInt32(rdr["CL16"].ToString()));
                    label45.Text=DersAdiBul(Convert.ToInt32(rdr["CL17"].ToString()));
                    label46.Text=DersAdiBul(Convert.ToInt32(rdr["CL18"].ToString()));
                    label47.Text=DersAdiBul(Convert.ToInt32(rdr["CL19"].ToString()));

                    label49.Text=DersAdiBul(Convert.ToInt32(rdr["CL20"].ToString()));
                    label50.Text=DersAdiBul(Convert.ToInt32(rdr["CL21"].ToString()));
                    label51.Text=DersAdiBul(Convert.ToInt32(rdr["CL22"].ToString()));
                    label52.Text=DersAdiBul(Convert.ToInt32(rdr["CL23"].ToString()));

                    label35.Text=DersAdiBul(Convert.ToInt32(rdr["CL24"].ToString()));
                    label36.Text=DersAdiBul(Convert.ToInt32(rdr["CL25"].ToString()));
                    label37.Text=DersAdiBul(Convert.ToInt32(rdr["CL26"].ToString()));
                    label38.Text=DersAdiBul(Convert.ToInt32(rdr["CL27"].ToString()));

                    label40.Text=DersAdiBul(Convert.ToInt32(rdr["CL28"].ToString()));
                    label41.Text=DersAdiBul(Convert.ToInt32(rdr["CL29"].ToString()));
                    label42.Text=DersAdiBul(Convert.ToInt32(rdr["CL30"].ToString()));
                    label43.Text=DersAdiBul(Convert.ToInt32(rdr["CL31"].ToString()));

                    label53.Text=DersAdiBul(Convert.ToInt32(rdr["CL32"].ToString()));
                    label54.Text=DersAdiBul(Convert.ToInt32(rdr["CL33"].ToString()));
                    label55.Text=DersAdiBul(Convert.ToInt32(rdr["CL34"].ToString()));
                    label56.Text=DersAdiBul(Convert.ToInt32(rdr["CL35"].ToString()));

                    label58.Text=DersAdiBul(Convert.ToInt32(rdr["CL36"].ToString()));
                    label59.Text=DersAdiBul(Convert.ToInt32(rdr["CL37"].ToString()));
                    label60.Text=DersAdiBul(Convert.ToInt32(rdr["CL38"].ToString()));
                    label61.Text=DersAdiBul(Convert.ToInt32(rdr["CL39"].ToString()));
                    rdr.Close();
                    baglan.Close();
                }


            }
            catch (Exception err)
            {
                Temizle();
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }
        private void Temizle()
        {
            label17.Text = " -----  ";
            label18.Text = " -----  ";
            label19.Text = " -----  ";
            label20.Text = " -----  ";

            label22.Text = " -----  ";
            label23.Text = " -----  ";
            label24.Text = " -----  ";
            label25.Text = " -----  ";

            label26.Text = " -----  ";
            label27.Text = " -----  ";
            label28.Text = " -----  ";
            label29.Text = " -----  ";

            label31.Text = " -----  ";
            label32.Text = " -----  ";
            label33.Text = " -----  ";
            label34.Text = " -----  ";

            label44.Text = " -----  ";
            label45.Text = " -----  ";
            label46.Text = " -----  ";
            label47.Text = " -----  ";

            label49.Text = " -----  ";
            label50.Text = " -----  ";
            label51.Text = " -----  ";
            label52.Text = " -----  ";

            label35.Text = " -----  ";
            label36.Text = " -----  ";
            label37.Text = " -----  ";
            label38.Text = " -----  ";

            label40.Text = " -----  ";
            label41.Text = " -----  ";
            label42.Text = " -----  ";
            label43.Text = " -----  ";

            label53.Text = " -----  ";
            label54.Text = " -----  ";
            label55.Text = " -----  ";
            label56.Text = " -----  ";

            label58.Text = " -----  ";
            label59.Text = " -----  ";
            label60.Text = " -----  ";
            label61.Text = " -----  ";
        }
        private string DersAdiBul(int id)
        {
            for (int i = 0; i < dersler.Count; i++)
                if (dersler[i].DERSID == id)
                    return dersler[i].DERSADI;
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM DersTablo WHERE SINIFID=" + siniflar[cmbSinif.SelectedIndex].SinifID, baglan))
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                    Temizle();
                }

            }
            catch (Exception err)
            {


            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (label17.Text == " -----  ") throw new Exception("Seçili Sınıfın Ders Programı Yok");
                var dersduz = new DersProgramıEKLE(siniflar[cmbSinif.SelectedIndex].SinifID);
                dersduz.MdiParent = this.MdiParent;
                dersduz.Show();
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
