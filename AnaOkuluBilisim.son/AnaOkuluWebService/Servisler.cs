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
    
    public partial class Servisler
    {
        public Servisler()
        {
            this.Ogrencilers = new HashSet<Ogrenciler>();
        }
    
        public int ServisID { get; set; }
        public string ServisAdi { get; set; }
    
        public virtual ICollection<Ogrenciler> Ogrencilers { get; set; }
    }
}
