using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication10
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=SEDATPC; initial Catalog=anaokulu;Integrated Security=true");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            bag.Open();
            MessageBox.Show("database baglandi.");
            bag.Close();
            MessageBox.Show("baglanti kesildi.");
        }
    }
}
