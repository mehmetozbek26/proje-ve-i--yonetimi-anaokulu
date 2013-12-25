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
    public partial class DersProgramıEKLE : Form
    {
        public DersProgramıEKLE(int i=0)
        {
            InitializeComponent();
            sinifid = i;
        }
        private int sinifid=0;
        IList<Sinif> siniflar = new List<Sinif>();
        IList<Dersler> dersler = new List<Dersler>();
        SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        private void DersProgramı_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Siniflar", baglan))
                {

                    baglan.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    siniflar.Clear();
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
                           DERSID=Convert.ToInt32(rdr["DERSID"].ToString()),
                           DERSADI=rdr["DERSADI"].ToString(),
                           OGRETMENID=Convert.ToInt32(rdr["OGRETMENID"].ToString())
    
                        });
                        comboBox1.Items.Add(rdr["DERSADI"].ToString());
                        comboBox2.Items.Add(rdr["DERSADI"].ToString());
                        comboBox3.Items.Add(rdr["DERSADI"].ToString());
                        comboBox4.Items.Add(rdr["DERSADI"].ToString());

                        comboBox6.Items.Add(rdr["DERSADI"].ToString());
                        comboBox7.Items.Add(rdr["DERSADI"].ToString());
                        comboBox8.Items.Add(rdr["DERSADI"].ToString());
                        comboBox9.Items.Add(rdr["DERSADI"].ToString());
                        comboBox10.Items.Add(rdr["DERSADI"].ToString());
                        comboBox11.Items.Add(rdr["DERSADI"].ToString());
                        comboBox12.Items.Add(rdr["DERSADI"].ToString());
                        comboBox13.Items.Add(rdr["DERSADI"].ToString());

                        comboBox15.Items.Add(rdr["DERSADI"].ToString());
                        comboBox16.Items.Add(rdr["DERSADI"].ToString());
                        comboBox17.Items.Add(rdr["DERSADI"].ToString());
                        comboBox18.Items.Add(rdr["DERSADI"].ToString());
                        comboBox19.Items.Add(rdr["DERSADI"].ToString());
                        comboBox20.Items.Add(rdr["DERSADI"].ToString());
                        comboBox21.Items.Add(rdr["DERSADI"].ToString());
                        comboBox22.Items.Add(rdr["DERSADI"].ToString());

                        comboBox24.Items.Add(rdr["DERSADI"].ToString());
                        comboBox25.Items.Add(rdr["DERSADI"].ToString());
                        comboBox26.Items.Add(rdr["DERSADI"].ToString());
                        comboBox27.Items.Add(rdr["DERSADI"].ToString());
                        comboBox28.Items.Add(rdr["DERSADI"].ToString());
                        comboBox29.Items.Add(rdr["DERSADI"].ToString());
                        comboBox30.Items.Add(rdr["DERSADI"].ToString());
                        comboBox31.Items.Add(rdr["DERSADI"].ToString());

                        comboBox33.Items.Add(rdr["DERSADI"].ToString());
                        comboBox34.Items.Add(rdr["DERSADI"].ToString());
                        comboBox35.Items.Add(rdr["DERSADI"].ToString());
                        comboBox36.Items.Add(rdr["DERSADI"].ToString());
                        comboBox37.Items.Add(rdr["DERSADI"].ToString());
                        comboBox38.Items.Add(rdr["DERSADI"].ToString());
                        comboBox39.Items.Add(rdr["DERSADI"].ToString());
                        comboBox40.Items.Add(rdr["DERSADI"].ToString());

                        comboBox42.Items.Add(rdr["DERSADI"].ToString());
                        comboBox43.Items.Add(rdr["DERSADI"].ToString());
                        comboBox44.Items.Add(rdr["DERSADI"].ToString());
                        comboBox45.Items.Add(rdr["DERSADI"].ToString());
                     
                    }
                    baglan.Close();
                }
                if (sinifid != 0)
                {
                    using (SqlCommand cmd = new SqlCommand("select * from DersTablo where SINIFID="+sinifid,baglan))
                    {
                        baglan.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        
                        comboBox1.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL0"].ToString()));
                        comboBox2.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL1"].ToString()));
                        comboBox3.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL2"].ToString()));
                        comboBox4.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL3"].ToString()));

                        comboBox6.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL4"].ToString()));
                        comboBox7.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL5"].ToString()));
                        comboBox8.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL6"].ToString()));
                        comboBox9.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL7"].ToString()));

                        comboBox10.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL8"].ToString()));
                        comboBox11.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL9"].ToString()));
                        comboBox12.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL10"].ToString()));
                        comboBox13.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL11"].ToString()));

                        comboBox15.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL12"].ToString()));
                        comboBox16.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL13"].ToString()));
                        comboBox17.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL14"].ToString()));
                        comboBox18.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL15"].ToString()));

                        comboBox19.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL16"].ToString()));
                        comboBox20.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL17"].ToString()));
                        comboBox21.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL18"].ToString()));
                        comboBox22.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL19"].ToString()));

                        comboBox24.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL20"].ToString()));
                        comboBox25.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL21"].ToString()));
                        comboBox26.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL22"].ToString()));
                        comboBox27.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL23"].ToString()));

                        comboBox28.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL24"].ToString()));
                        comboBox29.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL25"].ToString()));
                        comboBox30.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL26"].ToString()));
                        comboBox31.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL27"].ToString()));

                        comboBox33.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL28"].ToString()));
                        comboBox34.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL29"].ToString()));
                        comboBox35.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL30"].ToString()));
                        comboBox36.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL31"].ToString()));

                        comboBox37.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL32"].ToString()));
                        comboBox38.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL33"].ToString()));
                        comboBox39.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL34"].ToString()));
                        comboBox40.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL35"].ToString()));

                        comboBox42.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL36"].ToString()));
                        comboBox43.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL37"].ToString()));
                        comboBox44.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL38"].ToString()));
                        comboBox45.SelectedIndex = BulDers(Convert.ToInt32(rdr["CL39"].ToString()));
                        rdr.Close();
                        baglan.Close();
                        for (int i = 0; i < siniflar.Count; i++)
                            if (siniflar[i].SinifID == sinifid)
                                cmbSinif.SelectedIndex = i;
                    }
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
        private int BulDers(int id)
        {
            for (int i = 0; i < dersler.Count; i++)
                if (dersler[i].DERSID == id)
                    return i;
            return 0;

        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       // private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (comboBox1.SelectedIndex < 0) throw new Exception("Pazartesi 08:00 - 09:00 Ders Seçiniz");
        //        if (comboBox2.SelectedIndex < 0) throw new Exception("Pazartesi 09:00 - 10:00 Ders Seçiniz");
        //        if (sinifid != 0)
        //        {
        //            using (SqlCommand cmd = new SqlCommand("UPDATE DersTablo SET " +
        //                 "CL0=" + dersler[comboBox1.SelectedIndex].DERSID + "," +
        //                 "CL1=" + dersler[comboBox2.SelectedIndex].DERSID + "," +
        //                 "CL2=" + dersler[comboBox3.SelectedIndex].DERSID + "," +
        //                 "CL3=" + dersler[comboBox4.SelectedIndex].DERSID + "," +
        //                 "CL4=" + dersler[comboBox6.SelectedIndex].DERSID + "," +
        //                 "CL5=" + dersler[comboBox7.SelectedIndex].DERSID + "," +
        //                 "CL6=" + dersler[comboBox8.SelectedIndex].DERSID + "," +
        //                 "CL7=" + dersler[comboBox9.SelectedIndex].DERSID + "," +
        //                 "CL8=" + dersler[comboBox10.SelectedIndex].DERSID + "," +
        //                 "CL9=" + dersler[comboBox11.SelectedIndex].DERSID + "," +
        //                 "CL10=" + dersler[comboBox12.SelectedIndex].DERSID + "," +
        //                 "CL11=" + dersler[comboBox13.SelectedIndex].DERSID + "," +
        //                 "CL12=" + dersler[comboBox15.SelectedIndex].DERSID + "," +
        //                 "CL13=" + dersler[comboBox16.SelectedIndex].DERSID + "," +
        //                 "CL14=" + dersler[comboBox17.SelectedIndex].DERSID + "," +
        //                 "CL15=" + dersler[comboBox18.SelectedIndex].DERSID + "," +
        //                 "CL16=" + dersler[comboBox19.SelectedIndex].DERSID + "," +
        //                 "CL17=" + dersler[comboBox20.SelectedIndex].DERSID + "," +
        //                 "CL18=" + dersler[comboBox21.SelectedIndex].DERSID + "," +
        //                 "CL19=" + dersler[comboBox22.SelectedIndex].DERSID + "," +
        //                 "CL20=" + dersler[comboBox24.SelectedIndex].DERSID + "," +
        //                 "CL21=" + dersler[comboBox25.SelectedIndex].DERSID + "," +
        //                 "CL22=" + dersler[comboBox26.SelectedIndex].DERSID + "," +
        //                 "CL23=" + dersler[comboBox27.SelectedIndex].DERSID + "," +
        //                 "CL24=" + dersler[comboBox28.SelectedIndex].DERSID + "," +
        //                 "CL25=" + dersler[comboBox29.SelectedIndex].DERSID + "," +
        //                 "CL26=" + dersler[comboBox30.SelectedIndex].DERSID + "," +
        //                 "CL27=" + dersler[comboBox31.SelectedIndex].DERSID + "," +
        //                 "CL28=" + dersler[comboBox33.SelectedIndex].DERSID + "," +
        //                 "CL29=" + dersler[comboBox34.SelectedIndex].DERSID + "," +
        //                 "CL30=" + dersler[comboBox35.SelectedIndex].DERSID + "," +
        //                 "CL31=" + dersler[comboBox36.SelectedIndex].DERSID + "," +
        //                 "CL32=" + dersler[comboBox37.SelectedIndex].DERSID + "," +
        //                 "CL33=" + dersler[comboBox38.SelectedIndex].DERSID + "," +
        //                 "CL34=" + dersler[comboBox39.SelectedIndex].DERSID + "," +
        //                 "CL35=" + dersler[comboBox40.SelectedIndex].DERSID + "," +
        //                 "CL36=" + dersler[comboBox42.SelectedIndex].DERSID + "," +
        //                 "CL37=" + dersler[comboBox43.SelectedIndex].DERSID + "," +
        //                 "CL38=" + dersler[comboBox44.SelectedIndex].DERSID + "," +
        //                 "CL39=" + dersler[comboBox45.SelectedIndex].DERSID + " WHERE SINIFID=" + siniflar[cmbSinif.SelectedIndex].SinifID, baglan))
        //            {
        //                baglan.Open();
        //                cmd.ExecuteNonQuery();
        //                baglan.Close();
        //                MessageBox.Show("Ders Programı Guncellendi");
        //                this.Close();
        //            }



        //        }
        //        else
        //        {
        //            using (SqlCommand cmd = new SqlCommand("INSERT INTO DersTablo VALUES (" +
        //                siniflar[cmbSinif.SelectedIndex].SinifID + "," +
        //                dersler[comboBox1.SelectedIndex].DERSID + "," +
        //                dersler[comboBox2.SelectedIndex].DERSID + "," +
        //                dersler[comboBox3.SelectedIndex].DERSID + "," +
        //                dersler[comboBox4.SelectedIndex].DERSID + "," +
        //                dersler[comboBox6.SelectedIndex].DERSID + "," +
        //                dersler[comboBox7.SelectedIndex].DERSID + "," +
        //                dersler[comboBox8.SelectedIndex].DERSID + "," +
        //                dersler[comboBox9.SelectedIndex].DERSID + "," +
        //                dersler[comboBox10.SelectedIndex].DERSID + "," +
        //                dersler[comboBox11.SelectedIndex].DERSID + "," +
        //                dersler[comboBox12.SelectedIndex].DERSID + "," +
        //                dersler[comboBox13.SelectedIndex].DERSID + "," +
        //                dersler[comboBox15.SelectedIndex].DERSID + "," +
        //                dersler[comboBox16.SelectedIndex].DERSID + "," +
        //                dersler[comboBox17.SelectedIndex].DERSID + "," +
        //                dersler[comboBox18.SelectedIndex].DERSID + "," +
        //                dersler[comboBox19.SelectedIndex].DERSID + "," +
        //                dersler[comboBox20.SelectedIndex].DERSID + "," +
        //                dersler[comboBox21.SelectedIndex].DERSID + "," +
        //                dersler[comboBox22.SelectedIndex].DERSID + "," +
        //                dersler[comboBox24.SelectedIndex].DERSID + "," +
        //                dersler[comboBox25.SelectedIndex].DERSID + "," +
        //                dersler[comboBox26.SelectedIndex].DERSID + "," +
        //                dersler[comboBox27.SelectedIndex].DERSID + "," +
        //                dersler[comboBox28.SelectedIndex].DERSID + "," +
        //                dersler[comboBox29.SelectedIndex].DERSID + "," +
        //                dersler[comboBox30.SelectedIndex].DERSID + "," +
        //                dersler[comboBox31.SelectedIndex].DERSID + "," +
        //                dersler[comboBox33.SelectedIndex].DERSID + "," +
        //                dersler[comboBox34.SelectedIndex].DERSID + "," +
        //                dersler[comboBox35.SelectedIndex].DERSID + "," +
        //                dersler[comboBox36.SelectedIndex].DERSID + "," +
        //                dersler[comboBox37.SelectedIndex].DERSID + "," +
        //                dersler[comboBox38.SelectedIndex].DERSID + "," +
        //                dersler[comboBox39.SelectedIndex].DERSID + "," +
        //                dersler[comboBox40.SelectedIndex].DERSID + "," +
        //                dersler[comboBox42.SelectedIndex].DERSID + "," +
        //                dersler[comboBox43.SelectedIndex].DERSID + "," +
        //                dersler[comboBox44.SelectedIndex].DERSID + "," +
        //                dersler[comboBox45.SelectedIndex].DERSID + ")", baglan))
        //            {
        //                baglan.Open();
        //                cmd.ExecuteNonQuery();
        //                baglan.Close();
        //                MessageBox.Show("Ders Programı Kaydedildi");
        //                this.Close();
        //            }
        //        }


        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show("Kayıt Yapılamadı");

        //    }
        //    finally
        //    {
        //        if (baglan.State == ConnectionState.Open)
        //            baglan.Close();
        //    }


        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex < 0) throw new Exception("Pazartesi 08:00 - 09:00 Ders Seçiniz");
                if (comboBox2.SelectedIndex < 0) throw new Exception("Pazartesi 09:00 - 10:00 Ders Seçiniz");
                if (sinifid != 0)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE DersTablo SET " +
                         "CL0=" + dersler[comboBox1.SelectedIndex].DERSID + "," +
                         "CL1=" + dersler[comboBox2.SelectedIndex].DERSID + "," +
                         "CL2=" + dersler[comboBox3.SelectedIndex].DERSID + "," +
                         "CL3=" + dersler[comboBox4.SelectedIndex].DERSID + "," +
                         "CL4=" + dersler[comboBox6.SelectedIndex].DERSID + "," +
                         "CL5=" + dersler[comboBox7.SelectedIndex].DERSID + "," +
                         "CL6=" + dersler[comboBox8.SelectedIndex].DERSID + "," +
                         "CL7=" + dersler[comboBox9.SelectedIndex].DERSID + "," +
                         "CL8=" + dersler[comboBox10.SelectedIndex].DERSID + "," +
                         "CL9=" + dersler[comboBox11.SelectedIndex].DERSID + "," +
                         "CL10=" + dersler[comboBox12.SelectedIndex].DERSID + "," +
                         "CL11=" + dersler[comboBox13.SelectedIndex].DERSID + "," +
                         "CL12=" + dersler[comboBox15.SelectedIndex].DERSID + "," +
                         "CL13=" + dersler[comboBox16.SelectedIndex].DERSID + "," +
                         "CL14=" + dersler[comboBox17.SelectedIndex].DERSID + "," +
                         "CL15=" + dersler[comboBox18.SelectedIndex].DERSID + "," +
                         "CL16=" + dersler[comboBox19.SelectedIndex].DERSID + "," +
                         "CL17=" + dersler[comboBox20.SelectedIndex].DERSID + "," +
                         "CL18=" + dersler[comboBox21.SelectedIndex].DERSID + "," +
                         "CL19=" + dersler[comboBox22.SelectedIndex].DERSID + "," +
                         "CL20=" + dersler[comboBox24.SelectedIndex].DERSID + "," +
                         "CL21=" + dersler[comboBox25.SelectedIndex].DERSID + "," +
                         "CL22=" + dersler[comboBox26.SelectedIndex].DERSID + "," +
                         "CL23=" + dersler[comboBox27.SelectedIndex].DERSID + "," +
                         "CL24=" + dersler[comboBox28.SelectedIndex].DERSID + "," +
                         "CL25=" + dersler[comboBox29.SelectedIndex].DERSID + "," +
                         "CL26=" + dersler[comboBox30.SelectedIndex].DERSID + "," +
                         "CL27=" + dersler[comboBox31.SelectedIndex].DERSID + "," +
                         "CL28=" + dersler[comboBox33.SelectedIndex].DERSID + "," +
                         "CL29=" + dersler[comboBox34.SelectedIndex].DERSID + "," +
                         "CL30=" + dersler[comboBox35.SelectedIndex].DERSID + "," +
                         "CL31=" + dersler[comboBox36.SelectedIndex].DERSID + "," +
                         "CL32=" + dersler[comboBox37.SelectedIndex].DERSID + "," +
                         "CL33=" + dersler[comboBox38.SelectedIndex].DERSID + "," +
                         "CL34=" + dersler[comboBox39.SelectedIndex].DERSID + "," +
                         "CL35=" + dersler[comboBox40.SelectedIndex].DERSID + "," +
                         "CL36=" + dersler[comboBox42.SelectedIndex].DERSID + "," +
                         "CL37=" + dersler[comboBox43.SelectedIndex].DERSID + "," +
                         "CL38=" + dersler[comboBox44.SelectedIndex].DERSID + "," +
                         "CL39=" + dersler[comboBox45.SelectedIndex].DERSID + " WHERE SINIFID=" + siniflar[cmbSinif.SelectedIndex].SinifID, baglan))
                    {
                        baglan.Open();
                        cmd.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Ders Programı Guncellendi");
                        this.Close();
                    }



                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO DersTablo VALUES (" +
                        siniflar[cmbSinif.SelectedIndex].SinifID + "," +
                        dersler[comboBox1.SelectedIndex].DERSID + "," +
                        dersler[comboBox2.SelectedIndex].DERSID + "," +
                        dersler[comboBox3.SelectedIndex].DERSID + "," +
                        dersler[comboBox4.SelectedIndex].DERSID + "," +
                        dersler[comboBox6.SelectedIndex].DERSID + "," +
                        dersler[comboBox7.SelectedIndex].DERSID + "," +
                        dersler[comboBox8.SelectedIndex].DERSID + "," +
                        dersler[comboBox9.SelectedIndex].DERSID + "," +
                        dersler[comboBox10.SelectedIndex].DERSID + "," +
                        dersler[comboBox11.SelectedIndex].DERSID + "," +
                        dersler[comboBox12.SelectedIndex].DERSID + "," +
                        dersler[comboBox13.SelectedIndex].DERSID + "," +
                        dersler[comboBox15.SelectedIndex].DERSID + "," +
                        dersler[comboBox16.SelectedIndex].DERSID + "," +
                        dersler[comboBox17.SelectedIndex].DERSID + "," +
                        dersler[comboBox18.SelectedIndex].DERSID + "," +
                        dersler[comboBox19.SelectedIndex].DERSID + "," +
                        dersler[comboBox20.SelectedIndex].DERSID + "," +
                        dersler[comboBox21.SelectedIndex].DERSID + "," +
                        dersler[comboBox22.SelectedIndex].DERSID + "," +
                        dersler[comboBox24.SelectedIndex].DERSID + "," +
                        dersler[comboBox25.SelectedIndex].DERSID + "," +
                        dersler[comboBox26.SelectedIndex].DERSID + "," +
                        dersler[comboBox27.SelectedIndex].DERSID + "," +
                        dersler[comboBox28.SelectedIndex].DERSID + "," +
                        dersler[comboBox29.SelectedIndex].DERSID + "," +
                        dersler[comboBox30.SelectedIndex].DERSID + "," +
                        dersler[comboBox31.SelectedIndex].DERSID + "," +
                        dersler[comboBox33.SelectedIndex].DERSID + "," +
                        dersler[comboBox34.SelectedIndex].DERSID + "," +
                        dersler[comboBox35.SelectedIndex].DERSID + "," +
                        dersler[comboBox36.SelectedIndex].DERSID + "," +
                        dersler[comboBox37.SelectedIndex].DERSID + "," +
                        dersler[comboBox38.SelectedIndex].DERSID + "," +
                        dersler[comboBox39.SelectedIndex].DERSID + "," +
                        dersler[comboBox40.SelectedIndex].DERSID + "," +
                        dersler[comboBox42.SelectedIndex].DERSID + "," +
                        dersler[comboBox43.SelectedIndex].DERSID + "," +
                        dersler[comboBox44.SelectedIndex].DERSID + "," +
                        dersler[comboBox45.SelectedIndex].DERSID + ")", baglan))
                    {
                        baglan.Open();
                        cmd.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Ders Programı Kaydedildi");
                        this.Close();
                    }
                }


            }
            catch (Exception err)
            {
                MessageBox.Show("Kayıt Yapılamadı");

            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }


        }
    }
}
