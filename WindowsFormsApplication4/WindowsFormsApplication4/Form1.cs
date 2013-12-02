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
    public partial class DemirBasGuncelle : Form
    {
        public DemirbasKayit DmrBasKayit;
        public DemirBasGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.; database=AnaOkuluDB;integrated security=true");


       
        }
    }
}
