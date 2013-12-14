using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaOkuluBilisim.Models
{
   public class Sinif
    {
        private int sinifid;

        public int Sinifid
        {
            get { return sinifid; }
            set { sinifid = value; }
        }
        private string sinifadi;

        public string Sinifadi
        {
            get { return sinifadi; }
            set { sinifadi = value; }
        }
        private string kapasitesi;

        public string Kapasitesi
        {
            get { return kapasitesi; }
            set { kapasitesi = value; }
        }
        private int ogretmenid;

        public int Ogretmenid
        {
            get { return ogretmenid; }
            set { ogretmenid = value; }
        }
    }
}
