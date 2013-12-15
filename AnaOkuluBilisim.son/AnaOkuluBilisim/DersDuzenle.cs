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
    public partial class DersDuzenle : Form
    {
        public DersDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        IList<Ogretmenler> ogretmeler = new List<Ogretmenler>();
        IList<Dersler> dersler = new List<Dersler>();
        private void DersDuzenle_Load(object sender, EventArgs e)
        {
            try
            {

                using (SqlDataAdapter da = new SqlDataAdapter("SELECT d.DERSID,d.DERSADI,o.Adi,o.Soyadi FROM DERSLER d,Ogretmenler o where d.OGRETMENID=o.KayitId", cnn))
                {
                    DataTable dt = new DataTable();
                    cnn.Open();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Update();
                    cnn.Close();
                }
                dataGridView1.Columns["DERSID"].Visible = false;
                using (SqlCommand cmd = new SqlCommand("Select * from Ogretmenler", cnn))
                {

                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ogretmeler.Clear();
                    while (rdr.Read())
                    {
                       
                        ogretmeler.Add(new Ogretmenler
                        {
                            KayitId=Convert.ToInt32(rdr["KayitId"].ToString()),
                            OGRADI=rdr["Adi"].ToString(),
                            OGRSOY=rdr["Soyadi"].ToString(),
                            PersonelID=Convert.ToInt32(rdr["PersonelID"].ToString())
                        });
                        comboBox1.Items.Add(rdr["Adi"].ToString()+" "+rdr["Soyadi"].ToString());
                    }
                    cnn.Close();

                }
                comboBox2.Items.Clear();
                using (SqlCommand cmd = new SqlCommand("Select * from DERSLER", cnn))
                {

                    cnn.Open();
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
                        comboBox2.Items.Add(rdr["DERSADI"].ToString());
                    }
                    cnn.Close();
                }
                panel1.Visible=false;
                panel2.Visible = true;
                label4.Visible = false;
            }
            catch (Exception err)
            {


            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("update DERSLER set DERSADI='"+textBox1.Text.ToUpper()+"',OGRETMENID="+ogretmeler[comboBox1.SelectedIndex].KayitId+" where DERSID=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["DERSID"].Value), cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    DersDuzenle_Load(sender, e);
                }
            }
            catch (Exception err)
            {


            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string temp = textBox1.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
            for (int i = 0; i < comboBox1.Items.Count; i++)
                if (comboBox1.Items[i].ToString() == temp)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }

           textBox1.Text=dataGridView1.CurrentRow.Cells["DERSADI"].Value.ToString();
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM DERSLER WHERE DERSID=" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["DERSID"].Value), cnn))
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    DersDuzenle_Load(sender, e);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Bu Ders Ders Programında Bulnuyorsa İlk Önce Ders Programını Siliniz");

            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            label4.Visible = false;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select o.Adi,o.Soyadi  from Ogretmenler o,DERSLER d where d.OGRETMENID=o.KayitId and d.DERSID="+dersler[comboBox2.SelectedIndex].DERSID, cnn))
                {
                    cnn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    label4.Text = rdr["Adi"].ToString() + " " + rdr["Soyadi"].ToString();
                    label4.Visible = true;
                    cnn.Close();

                }
            }
            catch (Exception err)
            {


            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }
    }
}
