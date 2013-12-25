using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace AnaOkuluBilisim
{
    public partial class frmnewaccount : Form
    {
        public frmnewaccount()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabaniCon"].ConnectionString);
        SqlCommand cmd;
        bool kapat = false;
        string qry;
        private void button1_Click(object sender, EventArgs e)
        {
            Information1.Text = "";
            try
            {
                if (validatedata() == 0)
                {
                    errorProvider1.Clear();
                    using (SqlCommand cmd = new SqlCommand("select * from pwd where firstname=@first and lastname=@last", cnn))
                    {
                        cmd.Parameters.AddWithValue("@first", textBox5.Text);
                        cmd.Parameters.AddWithValue("@last", textBox6.Text);
                        cnn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            MessageBox.Show("Data already inserted");
                            cnn.Close();
                        }
                        else
                        {
                            sdr.Close();
                            if (textBox3.Text == textBox4.Text)
                            {
                                using (SqlCommand cmd1 = new SqlCommand("insert into pwd values(@userid,@createpassword,@firstname,@lastname,@age,@gender,@year,@address,@tel,@comdepart,@day,@mount,@confirmpassword)", cnn))
                                {
                                    if (cnn.State != ConnectionState.Open)
                                        cnn.Open();
                                    cmd1.Parameters.AddWithValue("@userid", textBox2.Text);
                                    cmd1.Parameters.AddWithValue("@createpassword", textBox3.Text);
                                    cmd1.Parameters.AddWithValue("@firstname", textBox5.Text);
                                    cmd1.Parameters.AddWithValue("@lastname", textBox6.Text);
                                    cmd1.Parameters.AddWithValue("@age", Convert.ToInt32(comboBox3.Text));
                                    cmd1.Parameters.AddWithValue("@gender", comboBox2.Text);
                                    cmd1.Parameters.AddWithValue("@year", Convert.ToInt32(textBox7.Text));
                                    cmd1.Parameters.AddWithValue("@address", textBox8.Text);
                                    cmd1.Parameters.AddWithValue("@tel", txtcontact.Text);
                                    cmd1.Parameters.AddWithValue("@comdepart", comdepart.Text);
                                    cmd1.Parameters.AddWithValue("@day", Convert.ToInt32(comboBox4.Text));
                                    cmd1.Parameters.AddWithValue("@mount", Convert.ToInt32(comboBox5.Text));
                                    cmd1.Parameters.AddWithValue("@confirmpassword", textBox4.Text);
                                    int row = cmd1.ExecuteNonQuery();
                                    if (row > 0)
                                    {
                                        MessageBox.Show("New user accepted", "Message");
                                        kapat = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("The value of create password and varify password are not same.", "Error");
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("This user id has been created please create another userid.", "Error");
            }
            finally
            {
                cnn.Close();
                if (kapat)
                    this.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int validatedata()
        {
            int a = 0;
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox5, "Please enter First Name");
                a = 1;
            }
            else
            {
                textBox5.BackColor = Color.White;
            }
            if (comboBox4.Text == "")
            {
                comboBox4.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox4, "Please enter date");
                a = 1;
            }
            else
            {
                comboBox4.BackColor = Color.White;
            }
            if (comboBox5.Text == "")
            {
                comboBox5.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox5, "Please enter month");
                a = 1;
            }
            else
            {
                comboBox5.BackColor = Color.White;
            }
            if (textBox7.Text == "")
            {
                textBox7.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox7, "Please enter year");
                a = 1;
            }
            else
            {
                textBox7.BackColor = Color.White;
            }
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox6, "Please enter last Name");
                a = 1;
            }
            else
            {
                textBox6.BackColor = Color.White;
            }
            if (comboBox3.Text == "")
            {
                comboBox3.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox3, "Please enter your Age");
                a = 1;
            }
            else
            {
                comboBox3.BackColor = Color.White;
            }
            if (comboBox2.Text == "")
            {
                comboBox2.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox2, "Please enter your Gender");
                a = 1;
            }
            else
            {
                comboBox2.BackColor = Color.White;
            }
            if (textBox8.Text == "")
            {
                textBox8.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox8, "Please enter your full address");
                a = 1;
            }
            else
            {
                textBox8.BackColor = Color.White;
            }
            if (txtcontact.Text.Length < 6)
            {
                txtcontact.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtcontact, "Please enter your contact No.");
                a = 1;
            }
            else
            {
                txtcontact.BackColor = Color.White;
            }
           
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox2, "Please enter your user Id");
                a = 1;
            }
            else
            {
                textBox2.BackColor = Color.White;
            }
            if (textBox3.Text.Length < 4)
            {
                textBox3.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox3, "Please enter your password and password length should be minimum four characters");
                a = 1;
            }
            else
            {
                textBox3.BackColor = Color.White;
            }
            if (textBox4.Text.Length < 4)
            {
                textBox4.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox4, "Please varify your password");
                a = 1;
            }
            else
            {
                textBox4.BackColor = Color.White;
            }
           
           
           
            if (comdepart.Text == "")
            {
                comdepart.BackColor = Color.LightCoral;
                errorProvider1.SetError(comdepart, "Please enter the department");
            }
            else
            {
                comdepart.BackColor = Color.White;
            }
            return a;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Name";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your last Name";
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your gender";
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Date of Birth";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please create your user Id";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please create your password";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please varify your password";
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please choose your security question";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter the answer";
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your full address";
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your contact no.";
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your qualification";
        }
        int d;
        private void frmnewaccount_Load(object sender, EventArgs e)
        {
            d = System.DateTime.Now.Year;
            for (int i = 18; i < 100; i++)
            {
                comboBox3.Items.Add(i);
            }
            d = System.DateTime.Now.Year;
            for (int j = 1; j < 32; j++)
            {
                comboBox4.Items.Add(j);
            }
            for (int k = 1; k < 13; k++)
            {
                comboBox5.Items.Add(k);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == false)
            {
                e.Handled = true;
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Age";
        }

        private void txtcontact_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your contact no.";
        }

        private void comqualification_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter your Qualification";
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(comboBox3.SelectedItem);
            int c = d - a;
            textBox7.Text = c.ToString();
        }
        string str2;
        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = textBox5.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                textBox5.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }
        
        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = textBox6.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                textBox6.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }
    }
}