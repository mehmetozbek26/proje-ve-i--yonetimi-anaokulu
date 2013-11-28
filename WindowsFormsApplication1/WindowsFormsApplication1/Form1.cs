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
            ////
            ////
            ////