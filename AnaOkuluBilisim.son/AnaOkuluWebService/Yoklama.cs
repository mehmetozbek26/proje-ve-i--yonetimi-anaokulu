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
        public int Id { get; set; }
        public Nullable<int> OgrenciId { get; set; }
        public Nullable<int> SinifID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string DevamsizlikTuru { get; set; }
        public string Aciklama { get; set; }
    
        public virtual Siniflar Siniflar { get; set; }
    }
}
