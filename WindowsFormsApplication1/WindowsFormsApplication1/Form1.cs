﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Blue;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Show();
            radioButton1.ForeColor = Color.Blue;
            panel2.BackColor = Color.Yellow;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        
    }
}
