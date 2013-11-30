using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LoginFormNew
{
    public partial class Update_Student_Details : Form
    {
        public Update_Student_Details()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string qry;
        SqlConnection con= new SqlConnection("server=.;uid=sa;pwd=niit;database=Eramodel");
        SqlCommand cmd;
        SqlDataAdapter adap;
        DataSet ds;
        DataTable dt;
        int row;
        DataRow dr;

        private void button1_Click(object sender, EventArgs e)
        {
            inform.Text = "";
            Information1.Text = "";
            try
            {
                if (validatedata() == 0)
                {
                    errorProvider1.Clear();
                    qry = "update studentadmission set roll='" + txtuproll.Text + "',classadmission='" + comupclass.Text + "',section='" + comboBox1.Text + "',firstname='" + txtupfirststu.Text + "',lastname='" + txtuplaststuname.Text + "',fathername='" + txtupfather.Text + "',dobyear='" + textBox5.Text + "',poc='" + txtuppob.Text + "',gender='" + comupgender.Text + "',age='" + comage.Text + "',religion='" + txtupreligion.Text + "',address='" + txtupaddress.Text + "',nation='" + txtupnation.Text + "',pin='" + txtpin.Text + "',contact='" + txtcontact.Text + "',dobday='" + comboBox2.Text + "',dobmonth='" + comboBox3.Text + "' where regno='" + txtupregistration.Text + "'";
                    //MessageBox.Show(qry);
                    con.Open();
                    cmd = new SqlCommand(qry, con);
                    row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Updation Successful","Message");
                    }
                    else
                    {
                        MessageBox.Show("Updation not done","Message");

                    }
                }
            }
            catch
            {
                MessageBox.Show("The characters length is out of range","Message");
            }
            finally
            {
                con.Close();
            }
        }
        private void txtupregistration_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmregistation reg = new frmregistation();
                DialogResult res = reg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtupregistration.Text = reg.str1;
                    qry = "select *from studentadmission where regno='" + txtupregistration.Text + "'";
                    adap = new SqlDataAdapter(qry, con);
                    ds = new DataSet();
                    adap.Fill(ds);
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];
                        txtuproll.Text = dr[1].ToString();
                        comupclass.Text = dr[2].ToString();
                        comboBox1.Text = dr[3].ToString();
                        txtupfirststu.Text = dr[4].ToString();
                        txtuplaststuname.Text = dr[5].ToString();
                        txtupfather.Text = dr[6].ToString();
                        txtuppob.Text = dr[9].ToString();
                        comupgender.Text = dr[10].ToString();
                        comage.Text = dr[11].ToString();
                        txtupreligion.Text = dr[12].ToString();
                        txtupaddress.Text = dr[13].ToString();
                        txtupnation.Text = dr[18].ToString();
                        txtpin.Text = dr[19].ToString();
                        txtcontact.Text = dr[20].ToString();
                        textBox5.Text = dr[8].ToString();
                        comboBox2.Text = dr[23].ToString();
                        comboBox3.Text = dr[24].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int validatedata()
        {
            int i = 0;
            if (txtupregistration.Text == "")
            {
                txtupregistration.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtupregistration, "Please select registration No.");
                i = 1;
            }
            else
            {
                txtupregistration.BackColor = Color.White;
            }
                if (txtuproll.Text == "")
                {
                    txtuproll.BackColor = Color.LightCoral;
                    errorProvider1.SetError(txtuproll, "Please enter roll no.");
                    i = 1;
                }
                else
                {
                    txtuproll.BackColor = Color.White;
                }
                if (comupclass.Text == "")
                {
                    comupclass.BackColor = Color.LightCoral;
                    errorProvider1.SetError(comupclass, "Please enter class");
                    i = 1;
                }
                else
                {   
                    comupclass.BackColor = Color.White;
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.BackColor = Color.LightCoral;
                    errorProvider1.SetError(comboBox1, "Please enter section");
                    i = 1;
                }
                else
                {   
                    comboBox1.BackColor = Color.White;
                }
                if (txtupfirststu.Text == "")
                {
                    txtupfirststu.BackColor = Color.LightCoral;
                    errorProvider1.SetError(txtupfirststu, "Please enter student first name");
                    i = 1;
                }
                else
                {   
                    txtupfirststu.BackColor = Color.White;
                }
                if (txtuplaststuname.Text == "")
                {
                    txtuplaststuname.BackColor = Color.LightCoral;
                    errorProvider1.SetError(txtuplaststuname, "Please enter student last name");
                    i = 1;
                }
                else
                {   
                    txtuplaststuname.BackColor = Color.White;
                }
                if (txtupfather.Text == "")
                {
                    txtupfather.BackColor = Color.LightCoral;
                    errorProvider1.SetError(txtupfather, "Please enter father name");
                    i = 1;
                }
                else
                {   
                    txtupfather.BackColor = Color.White;
                }
          
            if (txtuppob.Text == "")
            {
                txtuppob.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtuppob, "Please enter place of birth");
                i = 1;
            }
            else
            {
                txtuppob.BackColor = Color.White;
            }
            if (comupgender.Text == "")
            {
                comupgender.BackColor = Color.LightCoral;
                errorProvider1.SetError(comupgender, "Please enter gender");
                i = 1;
            }
            else
            {   
                comupgender.BackColor = Color.White;
            }
            if (comage.Text == "")
            {
                comage.BackColor = Color.LightCoral;
                errorProvider1.SetError(comage, "Please enter age");
                i = 1;
            }
            else
            {   
                comage.BackColor = Color.White;
            }
            if (txtupreligion.Text == "")
            {
                txtupreligion.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtupreligion, "Please enter religion");
                i = 1;
            }
            else
            {   
                txtupreligion.BackColor = Color.White;
            }
            if (txtupaddress.Text == "")
            {
                txtupaddress.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtupaddress, "Please enter address");
                i = 1;
            }
            else
            {   
                txtupaddress.BackColor = Color.White;
            }
            if (txtupnation.Text == "")
            {
                txtupnation.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtupnation, "Please enter address");
                i = 1;
            }
            else
            {   
                txtupnation.BackColor = Color.White;
            }
            if (txtpin.Text.Length < 7)
            {
                txtpin.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtpin, "Please enter correct pin code");
                i = 1;
            }
            else
            {
                txtpin.BackColor = Color.White;
            }
            if (txtcontact.Text.Length < 6)
            {
                txtcontact.BackColor = Color.LightCoral;
                errorProvider1.SetError(txtcontact, "Please enter correct contact no.");
                i = 1;
            }
            else
            {
                txtcontact.BackColor = Color.White;
            }
            if (comboBox2.Text == "")
            {
                comboBox2.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox2, "Please enter correct date");
                i = 1;
            }
            else
            {
                comboBox2.BackColor = Color.White;
            }
            if (comboBox3.Text == "")
            {
                comboBox3.BackColor = Color.LightCoral;
                errorProvider1.SetError(comboBox3, "Please enter correct date");
                i = 1;
            }
            else
            {
                comboBox3.BackColor = Color.White;
            }
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightCoral;
                errorProvider1.SetError(textBox5, "Please enter correct year");
                i = 1;
            }
            else
            {
                textBox5.BackColor = Color.White;
            }
            return i;
        }        

        private void txtupregistration_Enter(object sender, EventArgs e)
        {
            Information1.Text = "Please enter student registration no.";
        }

        int d;
        private void Update_Student_Details_Load(object sender, EventArgs e)
        {
            d = System.DateTime.Now.Year;
            for (int i = 5; i < 50; i++)
            {
                comage.Items.Add(i);
            }
            for (int j = 1; j < 32; j++)
            {
                comboBox2.Items.Add(j);
            }
            for (int k = 1; k < 13; k++)
            {
                comboBox3.Items.Add(k);
            }
        }

        private void txtpin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtupregistration_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtupregistration, "Double click this box");
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(comage.SelectedItem);
            int c = d - a;
            textBox5.Text = c.ToString();
        }
        string str2;
        private void txtupfirststu_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtupfirststu.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtupfirststu.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtuplaststuname_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtuplaststuname.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtuplaststuname.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtupfather_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtupfather.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtupfather.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtuppob_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtuppob.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtuppob.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtupaddress_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtupaddress.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtupaddress.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtupreligion_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtupreligion.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtupreligion.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void txtupnation_KeyUp(object sender, KeyEventArgs e)
        {
            str2 = txtupnation.Text;
            if (str2.StartsWith("1") || (str2.StartsWith("2") || (str2.StartsWith("3") || (str2.StartsWith("4") || (str2.StartsWith("5") || (str2.StartsWith("6") || (str2.StartsWith("7") || (str2.StartsWith("8") || (str2.StartsWith("9") || (str2.StartsWith("0") || (str2.StartsWith("!") || (str2.StartsWith("@") || (str2.StartsWith("#") || (str2.StartsWith("$") || (str2.StartsWith("%") || (str2.StartsWith("^") || (str2.StartsWith("&") || (str2.StartsWith("*") || (str2.StartsWith("(") || (str2.StartsWith(")") || (str2.StartsWith("-") || (str2.StartsWith("_") || (str2.StartsWith("+") || (str2.StartsWith("=") || (str2.StartsWith("[") || (str2.StartsWith("{") || (str2.StartsWith("]") || (str2.StartsWith("}") || (str2.StartsWith(":") || (str2.StartsWith(";") || (str2.StartsWith("'") || (str2.StartsWith("<") || (str2.StartsWith(",") || (str2.StartsWith(">") || (str2.StartsWith(".") || (str2.StartsWith("/") || (str2.StartsWith("?")) || (str2.StartsWith("|"))))))))))))))))))))))))))))))))))))))
            {
                txtupnation.Clear();
                inform.Text = "Please enter correct format";
                inform.Visible = true;
            }
            else
            {
                inform.Visible = false;
            }
        }

        private void comage_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void txtuproll_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}