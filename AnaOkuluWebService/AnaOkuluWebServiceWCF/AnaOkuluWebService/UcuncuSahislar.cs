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
    
    public partial class UcuncuSahislar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcNo { get; set; }
        public string Ceptel { get; set; }
        public string EvTel { get; set; }
        public string YakinlikDerecesi { get; set; }
        public string Meslek { get; set; }
        public int OgrenciId { get; set; }
        public string Email { get; set; }
    
        public virtual Ogrenciler Ogrenciler { get; set; }
    }
}