using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaOkuluBilisim.Models
{
    public class Parola
    {
        private Parola()
        { }
        private static Parola temp=new Parola();
        internal static Parola GET()
        {                        
                return temp;          
        }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Departman { get; set; }

        
    }
}
