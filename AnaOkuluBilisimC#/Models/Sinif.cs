using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaOkuluBilisim.Models
{
   public class Sinif
    {
       public int SinifID { get; set; }
       public string SinifAdi { get; set; }
       public string SinifKapasite { get; set; }
       public string OgretmenID { get; set; }
    }
}
