using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form2 frm;
        public Form1()
        {
            InitializeComponent();
            frm = new Form2();
            frm.frm1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm.Show();
        }
    }
}
