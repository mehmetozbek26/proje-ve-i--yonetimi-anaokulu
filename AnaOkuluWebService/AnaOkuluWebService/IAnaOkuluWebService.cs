using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AnaOkuluWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAnaOkuluWebService" in both code and config file together.
    [ServiceContract]
    public interface IAnaOkuluWebService
    {
        [OperationContract]
        bool GirisKontrol(string userid, string userpass, string departman);

        [OperationContract]
        bool ParolaDegistir(string oldpassword, string createpassword, string userid, string departman);

        [OperationContract]
        List<Yemekler> TumYemekler(string userid, string userpass, string departman);

        [OperationContract]
        List<string> VeliEmailler(string userid, string userpass, string departman);

        [OperationContract]
        bool YemekEkle(string userid, string userpass, string departman, string corba, string anayemek, string tatli, string tarih);

        [OperationContract]
        bool YemekSil(string userid, string userpass, string departman, int id);

        [OperationContract]
        List<Siniflar> TumSiniflar(string userid, string userpass, string departman);

        [OperationContract]
        List<OgretmelerDB> TumOgretmenler(string userid, string userpass, string departman);

        [OperationContract]
        bool SinifSil(string userid, string userpass, string departman, int sinifid);

        [OperationContract]
        bool SinifEkle(string userid, string userpass, string departman, string sinifadi, int sinifkapasitesi, int ogretmenid);

        [OperationContract]
        bool DemirbasGunceller(string userid, string userpass, string departman,int demirbasid,string DemirbasAdi,string DemirbasTuru,string DemirbasCinsi,string DemirbasAdeti,string DemirbasBirimi,string AlindigiYer,string AlisTarihi,string GirisTutari,string AlisFaturaNo,string KdvOrani,string KdvTutari,string SatisYeri,string SatisTarihi,string SatisTutari,string SatisFaturaNo,string SatisKdvTutari,string SatisNedeni);

    }
    [DataContract]
    public class OgretmelerDB
    {
        [DataMember]
        public string AD;
        [DataMember]
        public string SOYAD;
        [DataMember]
        public string TC;
        [DataMember]
        public int ID;
    }
}
