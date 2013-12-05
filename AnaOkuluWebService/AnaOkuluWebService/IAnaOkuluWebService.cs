﻿using System;
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
        #region KULLANICI

        [OperationContract]
        bool GirisKontrol(string userid, string userpass, string departman);
        [OperationContract]
        bool ParolaDegistir(string oldpassword, string createpassword, string userid, string departman);
        [OperationContract]
        bool KullaniciEkle(string userid, string userpass, string departman, pwd pwd);
        [OperationContract]
        List<pwd> TumKullanicilar(string userid, string userpass, string departman);
        [OperationContract]
        bool KontrolAdVeSoyad(string userid, string userpass, string departman, string ad, string soyad);

        #endregion

        #region SERVİSLER
        [OperationContract]
        IList<ServislerDB> TumServisler();
        #endregion

        #region UCUNCU SAHIS
        [OperationContract]
        List<UcuncuSahislar> TumUcuncuSahis();
        #endregion

        #region VELİLER
        [OperationContract]
        List<string> VeliEmailler(string userid, string userpass, string departman);
        [OperationContract]
        List<Veliler> TumVeliler();
        #endregion

        #region OGRETMENLER
        [OperationContract]
        List<OgretmelerDB> TumOgretmenler(string userid, string userpass, string departman);
        #endregion

        #region OGRENCİLER
        [OperationContract]
        List<Ogrenciler> TumOgrenciler();
        #endregion

        #region    PERSONEL
        [OperationContract]
        List<Personeller> TumPersoneller();

        #endregion

        #region SINIF
        [OperationContract]
        bool SinifEkle(string userid, string userpass, string departman, string sinifadi, int sinifkapasitesi, int ogretmenid);
        [OperationContract]
        bool SinifSil(string userid, string userpass, string departman, int sinifid);
        [OperationContract]
        List<Siniflar> TumSiniflar(string userid, string userpass, string departman);
        #endregion

        #region YEMEK
        [OperationContract]
        bool YemekEkle(string userid, string userpass, string departman, string corba, string anayemek, string tatli, string tarih);
        [OperationContract]
        List<Yemekler> TumYemekler(string userid, string userpass, string departman);
        [OperationContract]
        bool YemekSil(string userid, string userpass, string departman, int id);
        #endregion

        #region DEMİRBAS
        [OperationContract]
        IList<DemirbaslarDB> TumDemirbaslar(string userid, string userpass, string departman);
        [OperationContract]
        bool DemirbasEkle(string userid, string userpass, string departman, DemirbaslarDB demirbas);
        [OperationContract]
        bool DemirbasGunceller(string userid, string userpass, string departman, Demirbaslar demirbas);
        [OperationContract]
        bool DemirbasSil(string userid, string userpass, string departman,int demirbasid);
        #endregion

        #region YOKLAMA

        [OperationContract]
        IEnumerable<Yoklama> TumYoklama();
        [OperationContract]
        Yoklama Yoklama(int ogrenciid);
        #endregion

        #region DEMİRBAS MEKANLARI
        [OperationContract]
        IList<DemirbasMekanlariDB> TumDemirbasMekanlari(string userid, string userpass, string departman);
        [OperationContract]
        bool DemirbasMekanlariSil(string userid, string userpass, string departman, int id);
        [OperationContract]
        bool DemirbasMekanlariEkle(string userid, string userpass, string departman, DemirbasMekanlariDB demirbasmekanlari);
        #endregion
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

    [DataContract]
    public class ServislerDB
    {
        [DataMember]
        public int ID;
        [DataMember]
        public string AD;
    }

    [DataContract]
    public class YoklamaDB
    {
        [DataMember]
        public int ID;
        [DataMember]
        public int OgrenciId;
        [DataMember]
        public int SinifId;
        [DataMember]
        public DateTime Tarih;
        [DataMember]
        public string DevamsizlikTuru;
        [DataMember]
        public string Aciklama;   
    }

    [DataContract]
    public class YemeklerDB
    {
        [DataMember] public int  YemekId;
        [DataMember] public string Corba;
        [DataMember] public string AnaYemek;
        [DataMember] public string Tatli;
        [DataMember] public DateTime Tarih;
    }

    [DataContract]
    public class VelilerDB
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string TcNo;
        [DataMember]
        public string Adi;
        [DataMember]
        public string Soyadi;
        [DataMember]
        public string Ceptel;
        [DataMember]
        public string EvTel;
        [DataMember]
        public string YakinlikDerecesi;
        [DataMember]
        public string Meslek;
        [DataMember]
        public int OgrenciId;
        [DataMember]
        public string Email;
    }

    [DataContract]
    public class UcuncuSahisDB
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string Adi;
        [DataMember]
        public string Soyadi;
        [DataMember]
        public string TcNo;
        [DataMember]
        public string Ceptel;
        [DataMember]
        public string EvTel;
        [DataMember]
        public string YakinlikDerecesi;
        [DataMember]
        public string Meslek;
        [DataMember]
        public int OgrenciId;
        [DataMember]
        public string Email;
    }

    [DataContract]
    public class DemirbaslarDB
    {
        [DataMember]
        public int DEMIRBASID;
        [DataMember]
        public string Adi;
        [DataMember]
        public string Turu;
        [DataMember]
        public string Cinsi;
        [DataMember]
        public int Adet;
        [DataMember]
        public string Birim;
        [DataMember]
        public string AlindigiYer;
        [DataMember]
        public DateTime AlisTarihi;
        [DataMember]
        public decimal GirisTutari;
        [DataMember]
        public string AlisFaturaNo;
        [DataMember]
        public int KdvOrani;
        [DataMember]
        public decimal KdvTutari;
        [DataMember]
        public string SatisYeri;
        [DataMember]
        public DateTime SatisTarihi;
        [DataMember]
        public decimal SatisTutari;
        [DataMember]
        public string SatisFaturaNo;
        [DataMember]
        public decimal SatisKdvTutari;
        [DataMember]
        public string SatisNedeni;
    }

    [DataContract]
    public class DemirbasMekanlariDB
    {
        [DataMember]
        public int MekanId;
        [DataMember]
        public int DemirbasId;
        [DataMember]
        public string BulunduguYer;
        [DataMember]
        public string Adet;
        [DataMember]
        public string Sorumlusu;
        [DataMember]
        public DateTime TeslimTarihi;
    }





    

}
