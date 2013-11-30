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
    public partial class accountants : Form
    {
        public accountants()
        {
            InitializeComponent();
        }
        string str;
        string s;
        int i;
        string user;
        string qry;
        SqlConnection conn = new SqlConnection("server=shivam;uid=sa;pwd=niit;database=shivammodel");
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "select userid,password from accountantpwd where userid='" + txtuserid.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    user = sdr[0].ToString();
                    s = sdr[1].ToString();
                }
                if ((txtuserid.Text == user) && (txtpwd.Text == s))
                {
                    //MessageBox.Show("You have Logged on=" + str + "", "WELCOME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main_Form main = new Main_Form();
                    main.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Incorrect user name or password");
                    txtuserid.Clear();
                    txtpwd.Clear();

                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}