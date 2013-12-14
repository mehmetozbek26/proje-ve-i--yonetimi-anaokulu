using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uygula_Click(object sender, EventArgs e)
        {
           
            if(comboBox.Items.Contains(textBox1.Text)==false){
                comboBox.Items.Add(textBox1.Text);
            }

             else {
            MessageBox.Show("sehir mevcut!");
             }
        }
    }
}
