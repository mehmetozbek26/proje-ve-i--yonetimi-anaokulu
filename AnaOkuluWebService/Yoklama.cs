//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnaOkuluWebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yoklama
    {
        public int ID { get; set; }
        public int OgrenciId { get; set; }
        public int SinifId { get; set; }
        public System.DateTime Tarih { get; set; }
        public string DevamsizlikTuru { get; set; }
        public string Aciklama { get; set; }
    
        public virtual Ogrenciler Ogrenciler { get; set; }
        public virtual Siniflar Siniflar { get; set; }
    }
}
