﻿using AnaOkuluBilisim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnaOkuluBilisim
{
    public partial class ListeForm : Form
    {
        Parola par = Parola.GET();
  
        public ListeForm()
        {
         
            InitializeComponent();
            if (par.Departman=="OGRETMEN")
            {
                personelİşlemleriToolStripMenuItem.Enabled = false;
                demirbaşlarToolStripMenuItem.Enabled = false;
                yemeklerToolStripMenuItem.Enabled = false;
                hesapEkleToolStripMenuItem.Enabled = false;
            }

            if (par.Departman == "MUHASEBE")
            {
                hesabımToolStripMenuItem.Enabled = false;
                ogrenciİToolStripMenuItem.Enabled = false;
                personelİşlemleriToolStripMenuItem.Enabled = false;
                hesapEkleToolStripMenuItem.Enabled = false;
                yoklamaEkleToolStripMenuItem.Enabled = false;
                yoklamalarToolStripMenuItem.Enabled = false;
            }

            
        }
        private void öğrencilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciKayit frm = new OgrenciKayit();
            frm.MdiParent = this;
           // frm.Width = this.Width-20;
           // frm.Height = this.Height-20;
            
           
            frm.Show();
        }
        private void öğrencilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ogrenciler frm = new Ogrenciler();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personelKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelKayit prskyt = new PersonelKayit();
            prskyt.MdiParent = this;
            prskyt.Show();

        }

        private void sınıfEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinifEkle snfekle = new SinifEkle();
            snfekle.MdiParent = this;
            snfekle.Show();
        }

        private void demirbaşKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DemirbasKayit dmrbas = new DemirbasKayit();
            dmrbas.MdiParent = this;
            dmrbas.Show();
        }

        private void yoklamaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoklamaEkle yoklama = new YoklamaEkle();
            yoklama.MdiParent = this;
            yoklama.Show();
        }

        private void yemeklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YemekList yemek = new YemekList();
            yemek.MdiParent = this;
            yemek.Show();
        }

        private void ListeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void hesabımToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void hesabımToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SifreDegistir changePassword = new SifreDegistir();
            changePassword.MdiParent = this;
            changePassword.Show();
        }

        private void hesapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciEkle hesapekle = new KullaniciEkle();
            hesapekle.MdiParent = this;
            hesapekle.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
