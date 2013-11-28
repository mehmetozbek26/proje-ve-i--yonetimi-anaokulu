using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AnaOkuluBilisim
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        SqlCommand cmd;
        string qry;
    
        private void btncreatepwd_Click_1(object sender, EventArgs e)
            ///////////////////////////////////////////////////f
            ///////////////////////////////////////////////////i
            ///////////////////////////////////////////////////r
            ///////////////////////////////////////////////////s
            ///////////////////////////////////////////////////t
      
        SqlConnection conn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");
        SqlCommand cmd;
        string qry;
    
        private void btncreatepwd_Click_1(object sender, EventArgs e)
        {
            Information.Text = "";
            try
            {
                if (validatedata() == 0)
                {
                    errorProvider1.Clear();
                    if (txtnewpwd.Text.Length == txtconfirmpwd.Text.Length)
                    {
                        qry = "update pwd  set createpassword='" + txtnewpwd.Text + "' where userid='" + txtuserid.Text + "'and createpassword='" + txtoldpwd.Text + "'";
                        cmd = new SqlCommand(qry, conn);
                        //MessageBox.Show(qry);
                        conn.Open();
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0)
                        {
                            MessageBox.Show("Password changed", "Message");
                        }
                       ///////////////////////////////////////////////////s
                        //////////////////////////////////////////////////e
                        //////////////////////////////////////////////////c
                        //////////////////////////////////////////////////o
                        //////////////////////////////////////////////////n
                        //////////////////////////////////////////////////d