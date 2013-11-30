using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AnaOkuluBilisim
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            txtpwd.Text = "niit";
            comboBox1.SelectedIndex = 1;
            txtuserid.Text = "mahmut";



        }
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");

       



    }
}
