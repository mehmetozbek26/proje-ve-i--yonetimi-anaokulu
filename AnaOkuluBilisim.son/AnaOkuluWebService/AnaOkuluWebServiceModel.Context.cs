﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AnaOkuluDBEntities : DbContext
    {
        public AnaOkuluDBEntities()
            : base("name=AnaOkuluDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Demirbaslar> Demirbaslars { get; set; }
        public DbSet<DemirbasMekanlari> DemirbasMekanlaris { get; set; }
        public DbSet<Ogrenciler> Ogrencilers { get; set; }
        public DbSet<Ogretmenler> Ogretmenlers { get; set; }
        public DbSet<Personeller> Personellers { get; set; }
        public DbSet<pwd> pwds { get; set; }
        public DbSet<Servisler> Servislers { get; set; }
        public DbSet<Siniflar> Siniflars { get; set; }
        public DbSet<Yemekler> Yemeklers { get; set; }
        public DbSet<Yoklama> Yoklamas { get; set; }
    
        
    
        public virtual int sp_DemirbasEkle(string adi, string turu, string cinsi, Nullable<int> adet, string birim, string alindigiYer, string alisTarihi, Nullable<decimal> girisTutari, string alisFaturaNo, Nullable<int> kdvOrani, Nullable<decimal> kdvTutari, string satisYeri, Nullable<System.DateTime> satisTarihi, Nullable<decimal> satisTutari, string satisFaturaNo, Nullable<decimal> satisKdvTutari, string satisNedeni, ObjectParameter demirbasID)
        {
            var adiParameter = adi != null ?
                new ObjectParameter("Adi", adi) :
                new ObjectParameter("Adi", typeof(string));
    
            var turuParameter = turu != null ?
                new ObjectParameter("Turu", turu) :
                new ObjectParameter("Turu", typeof(string));
    
            var cinsiParameter = cinsi != null ?
                new ObjectParameter("Cinsi", cinsi) :
                new ObjectParameter("Cinsi", typeof(string));
    
            var adetParameter = adet.HasValue ?
                new ObjectParameter("Adet", adet) :
                new ObjectParameter("Adet", typeof(int));
    
            var birimParameter = birim != null ?
                new ObjectParameter("Birim", birim) :
                new ObjectParameter("Birim", typeof(string));
    
            var alindigiYerParameter = alindigiYer != null ?
                new ObjectParameter("AlindigiYer", alindigiYer) :
                new ObjectParameter("AlindigiYer", typeof(string));
    
            var alisTarihiParameter = alisTarihi != null ?
                new ObjectParameter("AlisTarihi", alisTarihi) :
                new ObjectParameter("AlisTarihi", typeof(string));
    
            var girisTutariParameter = girisTutari.HasValue ?
                new ObjectParameter("GirisTutari", girisTutari) :
                new ObjectParameter("GirisTutari", typeof(decimal));
    
            var alisFaturaNoParameter = alisFaturaNo != null ?
                new ObjectParameter("AlisFaturaNo", alisFaturaNo) :
                new ObjectParameter("AlisFaturaNo", typeof(string));
    
            var kdvOraniParameter = kdvOrani.HasValue ?
                new ObjectParameter("KdvOrani", kdvOrani) :
                new ObjectParameter("KdvOrani", typeof(int));
    
            var kdvTutariParameter = kdvTutari.HasValue ?
                new ObjectParameter("KdvTutari", kdvTutari) :
                new ObjectParameter("KdvTutari", typeof(decimal));
    
            var satisYeriParameter = satisYeri != null ?
                new ObjectParameter("SatisYeri", satisYeri) :
                new ObjectParameter("SatisYeri", typeof(string));
    
            var satisTarihiParameter = satisTarihi.HasValue ?
                new ObjectParameter("SatisTarihi", satisTarihi) :
                new ObjectParameter("SatisTarihi", typeof(System.DateTime));
    
            var satisTutariParameter = satisTutari.HasValue ?
                new ObjectParameter("SatisTutari", satisTutari) :
                new ObjectParameter("SatisTutari", typeof(decimal));
    
            var satisFaturaNoParameter = satisFaturaNo != null ?
                new ObjectParameter("SatisFaturaNo", satisFaturaNo) :
                new ObjectParameter("SatisFaturaNo", typeof(string));
    
            var satisKdvTutariParameter = satisKdvTutari.HasValue ?
                new ObjectParameter("SatisKdvTutari", satisKdvTutari) :
                new ObjectParameter("SatisKdvTutari", typeof(decimal));
    
            var satisNedeniParameter = satisNedeni != null ?
                new ObjectParameter("SatisNedeni", satisNedeni) :
                new ObjectParameter("SatisNedeni", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DemirbasEkle", adiParameter, turuParameter, cinsiParameter, adetParameter, birimParameter, alindigiYerParameter, alisTarihiParameter, girisTutariParameter, alisFaturaNoParameter, kdvOraniParameter, kdvTutariParameter, satisYeriParameter, satisTarihiParameter, satisTutariParameter, satisFaturaNoParameter, satisKdvTutariParameter, satisNedeniParameter, demirbasID);
        }
    
        public virtual int sp_DemirbasMekaniEkle(Nullable<int> demirbasId, string bulunduguYer, string adet, string sorumlusu, string teslimTarihi)
        {
            var demirbasIdParameter = demirbasId.HasValue ?
                new ObjectParameter("DemirbasId", demirbasId) :
                new ObjectParameter("DemirbasId", typeof(int));
    
            var bulunduguYerParameter = bulunduguYer != null ?
                new ObjectParameter("BulunduguYer", bulunduguYer) :
                new ObjectParameter("BulunduguYer", typeof(string));
    
            var adetParameter = adet != null ?
                new ObjectParameter("Adet", adet) :
                new ObjectParameter("Adet", typeof(string));
    
            var sorumlusuParameter = sorumlusu != null ?
                new ObjectParameter("Sorumlusu", sorumlusu) :
                new ObjectParameter("Sorumlusu", typeof(string));
    
            var teslimTarihiParameter = teslimTarihi != null ?
                new ObjectParameter("TeslimTarihi", teslimTarihi) :
                new ObjectParameter("TeslimTarihi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DemirbasMekaniEkle", demirbasIdParameter, bulunduguYerParameter, adetParameter, sorumlusuParameter, teslimTarihiParameter);
        }
    
        public virtual int sp_OgrenciKayitEkle(string adi, string soyadi, string adres, string semt, string ilce, string il, string postaKodu, string evTel, string kanGrubu, string tcNo, string uyruk, string cinsiyet, string kimlikSeriNo, string dogumYeri, Nullable<System.DateTime> dogumTarihi, string dogumili, string dogumilce, string mahalle, string koy, string cilt, string aile, string siraNo, string verilisYeri, string kayitNo, byte[] resim, Nullable<int> sinifId, Nullable<int> servisId, Nullable<System.DateTime> kayitTarihi, Nullable<System.DateTime> cikisTarihi, string davranisSorunu, string yapilanlar, string yasitlariylaIliskisi, string fobileri, string sevdigiYiyecekler, string asilar, string gecirdigiHastaliklar, string alerjiler, string ameliyatlar, string saglikSorunlari, string ilac, string protez, string diyet, string ruhsalDurum, ObjectParameter returnId)
        {
            var adiParameter = adi != null ?
                new ObjectParameter("Adi", adi) :
                new ObjectParameter("Adi", typeof(string));
    
            var soyadiParameter = soyadi != null ?
                new ObjectParameter("Soyadi", soyadi) :
                new ObjectParameter("Soyadi", typeof(string));
    
            var adresParameter = adres != null ?
                new ObjectParameter("Adres", adres) :
                new ObjectParameter("Adres", typeof(string));
    
            var semtParameter = semt != null ?
                new ObjectParameter("Semt", semt) :
                new ObjectParameter("Semt", typeof(string));
    
            var ilceParameter = ilce != null ?
                new ObjectParameter("ilce", ilce) :
                new ObjectParameter("ilce", typeof(string));
    
            var ilParameter = il != null ?
                new ObjectParameter("il", il) :
                new ObjectParameter("il", typeof(string));
    
            var postaKoduParameter = postaKodu != null ?
                new ObjectParameter("PostaKodu", postaKodu) :
                new ObjectParameter("PostaKodu", typeof(string));
    
            var evTelParameter = evTel != null ?
                new ObjectParameter("EvTel", evTel) :
                new ObjectParameter("EvTel", typeof(string));
    
            var kanGrubuParameter = kanGrubu != null ?
                new ObjectParameter("KanGrubu", kanGrubu) :
                new ObjectParameter("KanGrubu", typeof(string));
    
            var tcNoParameter = tcNo != null ?
                new ObjectParameter("TcNo", tcNo) :
                new ObjectParameter("TcNo", typeof(string));
    
            var uyrukParameter = uyruk != null ?
                new ObjectParameter("Uyruk", uyruk) :
                new ObjectParameter("Uyruk", typeof(string));
    
            var cinsiyetParameter = cinsiyet != null ?
                new ObjectParameter("Cinsiyet", cinsiyet) :
                new ObjectParameter("Cinsiyet", typeof(string));
    
            var kimlikSeriNoParameter = kimlikSeriNo != null ?
                new ObjectParameter("KimlikSeriNo", kimlikSeriNo) :
                new ObjectParameter("KimlikSeriNo", typeof(string));
    
            var dogumYeriParameter = dogumYeri != null ?
                new ObjectParameter("DogumYeri", dogumYeri) :
                new ObjectParameter("DogumYeri", typeof(string));
    
            var dogumTarihiParameter = dogumTarihi.HasValue ?
                new ObjectParameter("DogumTarihi", dogumTarihi) :
                new ObjectParameter("DogumTarihi", typeof(System.DateTime));
    
            var dogumiliParameter = dogumili != null ?
                new ObjectParameter("Dogumili", dogumili) :
                new ObjectParameter("Dogumili", typeof(string));
    
            var dogumilceParameter = dogumilce != null ?
                new ObjectParameter("Dogumilce", dogumilce) :
                new ObjectParameter("Dogumilce", typeof(string));
    
            var mahalleParameter = mahalle != null ?
                new ObjectParameter("Mahalle", mahalle) :
                new ObjectParameter("Mahalle", typeof(string));
    
            var koyParameter = koy != null ?
                new ObjectParameter("Koy", koy) :
                new ObjectParameter("Koy", typeof(string));
    
            var ciltParameter = cilt != null ?
                new ObjectParameter("Cilt", cilt) :
                new ObjectParameter("Cilt", typeof(string));
    
            var aileParameter = aile != null ?
                new ObjectParameter("Aile", aile) :
                new ObjectParameter("Aile", typeof(string));
    
            var siraNoParameter = siraNo != null ?
                new ObjectParameter("SiraNo", siraNo) :
                new ObjectParameter("SiraNo", typeof(string));
    
            var verilisYeriParameter = verilisYeri != null ?
                new ObjectParameter("VerilisYeri", verilisYeri) :
                new ObjectParameter("VerilisYeri", typeof(string));
    
            var kayitNoParameter = kayitNo != null ?
                new ObjectParameter("KayitNo", kayitNo) :
                new ObjectParameter("KayitNo", typeof(string));
    
            var resimParameter = resim != null ?
                new ObjectParameter("Resim", resim) :
                new ObjectParameter("Resim", typeof(byte[]));
    
            var sinifIdParameter = sinifId.HasValue ?
                new ObjectParameter("SinifId", sinifId) :
                new ObjectParameter("SinifId", typeof(int));
    
            var servisIdParameter = servisId.HasValue ?
                new ObjectParameter("ServisId", servisId) :
                new ObjectParameter("ServisId", typeof(int));
    
            var kayitTarihiParameter = kayitTarihi.HasValue ?
                new ObjectParameter("KayitTarihi", kayitTarihi) :
                new ObjectParameter("KayitTarihi", typeof(System.DateTime));
    
            var cikisTarihiParameter = cikisTarihi.HasValue ?
                new ObjectParameter("CikisTarihi", cikisTarihi) :
                new ObjectParameter("CikisTarihi", typeof(System.DateTime));
    
            var davranisSorunuParameter = davranisSorunu != null ?
                new ObjectParameter("DavranisSorunu", davranisSorunu) :
                new ObjectParameter("DavranisSorunu", typeof(string));
    
            var yapilanlarParameter = yapilanlar != null ?
                new ObjectParameter("Yapilanlar", yapilanlar) :
                new ObjectParameter("Yapilanlar", typeof(string));
    
            var yasitlariylaIliskisiParameter = yasitlariylaIliskisi != null ?
                new ObjectParameter("YasitlariylaIliskisi", yasitlariylaIliskisi) :
                new ObjectParameter("YasitlariylaIliskisi", typeof(string));
    
            var fobileriParameter = fobileri != null ?
                new ObjectParameter("Fobileri", fobileri) :
                new ObjectParameter("Fobileri", typeof(string));
    
            var sevdigiYiyeceklerParameter = sevdigiYiyecekler != null ?
                new ObjectParameter("SevdigiYiyecekler", sevdigiYiyecekler) :
                new ObjectParameter("SevdigiYiyecekler", typeof(string));
    
            var asilarParameter = asilar != null ?
                new ObjectParameter("Asilar", asilar) :
                new ObjectParameter("Asilar", typeof(string));
    
            var gecirdigiHastaliklarParameter = gecirdigiHastaliklar != null ?
                new ObjectParameter("GecirdigiHastaliklar", gecirdigiHastaliklar) :
                new ObjectParameter("GecirdigiHastaliklar", typeof(string));
    
            var alerjilerParameter = alerjiler != null ?
                new ObjectParameter("Alerjiler", alerjiler) :
                new ObjectParameter("Alerjiler", typeof(string));
    
            var ameliyatlarParameter = ameliyatlar != null ?
                new ObjectParameter("Ameliyatlar", ameliyatlar) :
                new ObjectParameter("Ameliyatlar", typeof(string));
    
            var saglikSorunlariParameter = saglikSorunlari != null ?
                new ObjectParameter("SaglikSorunlari", saglikSorunlari) :
                new ObjectParameter("SaglikSorunlari", typeof(string));
    
            var ilacParameter = ilac != null ?
                new ObjectParameter("ilac", ilac) :
                new ObjectParameter("ilac", typeof(string));
    
            var protezParameter = protez != null ?
                new ObjectParameter("Protez", protez) :
                new ObjectParameter("Protez", typeof(string));
    
            var diyetParameter = diyet != null ?
                new ObjectParameter("Diyet", diyet) :
                new ObjectParameter("Diyet", typeof(string));
    
            var ruhsalDurumParameter = ruhsalDurum != null ?
                new ObjectParameter("RuhsalDurum", ruhsalDurum) :
                new ObjectParameter("RuhsalDurum", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_OgrenciKayitEkle", adiParameter, soyadiParameter, adresParameter, semtParameter, ilceParameter, ilParameter, postaKoduParameter, evTelParameter, kanGrubuParameter, tcNoParameter, uyrukParameter, cinsiyetParameter, kimlikSeriNoParameter, dogumYeriParameter, dogumTarihiParameter, dogumiliParameter, dogumilceParameter, mahalleParameter, koyParameter, ciltParameter, aileParameter, siraNoParameter, verilisYeriParameter, kayitNoParameter, resimParameter, sinifIdParameter, servisIdParameter, kayitTarihiParameter, cikisTarihiParameter, davranisSorunuParameter, yapilanlarParameter, yasitlariylaIliskisiParameter, fobileriParameter, sevdigiYiyeceklerParameter, asilarParameter, gecirdigiHastaliklarParameter, alerjilerParameter, ameliyatlarParameter, saglikSorunlariParameter, ilacParameter, protezParameter, diyetParameter, ruhsalDurumParameter, returnId);
        }
    
        public virtual int sp_PersonelEkle(string tcNos, string adis, string soyadis, string sicilNos, Nullable<System.DateTime> basvuruTarihis, Nullable<System.DateTime> baslamaTarihis, string askerlikDurumus, string tecilBitisYilis, string kanGrubus, string cinsiyets, string adress, string semts, string ilces, string ils, string mails, string evTels, string cepTels, string egitimDurumus, Nullable<System.DateTime> ayrilisTarihis, string departmans, string ktcNos, string kuyruks, string kcinsiyets, string kkimlikSeriNos, string kdogumYeris, Nullable<System.DateTime> kdogumTarihis, string kdogumilis, string kdogumilces, string kmahalles, string kkoys, string kcilts, string kailes, string kSiraNos, string kVerilisYeris, string kKayitNos)
        {
            var tcNosParameter = tcNos != null ?
                new ObjectParameter("TcNos", tcNos) :
                new ObjectParameter("TcNos", typeof(string));
    
            var adisParameter = adis != null ?
                new ObjectParameter("Adis", adis) :
                new ObjectParameter("Adis", typeof(string));
    
            var soyadisParameter = soyadis != null ?
                new ObjectParameter("Soyadis", soyadis) :
                new ObjectParameter("Soyadis", typeof(string));
    
            var sicilNosParameter = sicilNos != null ?
                new ObjectParameter("SicilNos", sicilNos) :
                new ObjectParameter("SicilNos", typeof(string));
    
            var basvuruTarihisParameter = basvuruTarihis.HasValue ?
                new ObjectParameter("BasvuruTarihis", basvuruTarihis) :
                new ObjectParameter("BasvuruTarihis", typeof(System.DateTime));
    
            var baslamaTarihisParameter = baslamaTarihis.HasValue ?
                new ObjectParameter("BaslamaTarihis", baslamaTarihis) :
                new ObjectParameter("BaslamaTarihis", typeof(System.DateTime));
    
            var askerlikDurumusParameter = askerlikDurumus != null ?
                new ObjectParameter("AskerlikDurumus", askerlikDurumus) :
                new ObjectParameter("AskerlikDurumus", typeof(string));
    
            var tecilBitisYilisParameter = tecilBitisYilis != null ?
                new ObjectParameter("TecilBitisYilis", tecilBitisYilis) :
                new ObjectParameter("TecilBitisYilis", typeof(string));
    
            var kanGrubusParameter = kanGrubus != null ?
                new ObjectParameter("KanGrubus", kanGrubus) :
                new ObjectParameter("KanGrubus", typeof(string));
    
            var cinsiyetsParameter = cinsiyets != null ?
                new ObjectParameter("Cinsiyets", cinsiyets) :
                new ObjectParameter("Cinsiyets", typeof(string));
    
            var adressParameter = adress != null ?
                new ObjectParameter("Adress", adress) :
                new ObjectParameter("Adress", typeof(string));
    
            var semtsParameter = semts != null ?
                new ObjectParameter("Semts", semts) :
                new ObjectParameter("Semts", typeof(string));
    
            var ilcesParameter = ilces != null ?
                new ObjectParameter("Ilces", ilces) :
                new ObjectParameter("Ilces", typeof(string));
    
            var ilsParameter = ils != null ?
                new ObjectParameter("ils", ils) :
                new ObjectParameter("ils", typeof(string));
    
            var mailsParameter = mails != null ?
                new ObjectParameter("Mails", mails) :
                new ObjectParameter("Mails", typeof(string));
    
            var evTelsParameter = evTels != null ?
                new ObjectParameter("EvTels", evTels) :
                new ObjectParameter("EvTels", typeof(string));
    
            var cepTelsParameter = cepTels != null ?
                new ObjectParameter("CepTels", cepTels) :
                new ObjectParameter("CepTels", typeof(string));
    
            var egitimDurumusParameter = egitimDurumus != null ?
                new ObjectParameter("EgitimDurumus", egitimDurumus) :
                new ObjectParameter("EgitimDurumus", typeof(string));
    
            var ayrilisTarihisParameter = ayrilisTarihis.HasValue ?
                new ObjectParameter("AyrilisTarihis", ayrilisTarihis) :
                new ObjectParameter("AyrilisTarihis", typeof(System.DateTime));
    
            var departmansParameter = departmans != null ?
                new ObjectParameter("Departmans", departmans) :
                new ObjectParameter("Departmans", typeof(string));
    
            var ktcNosParameter = ktcNos != null ?
                new ObjectParameter("KtcNos", ktcNos) :
                new ObjectParameter("KtcNos", typeof(string));
    
            var kuyruksParameter = kuyruks != null ?
                new ObjectParameter("Kuyruks", kuyruks) :
                new ObjectParameter("Kuyruks", typeof(string));
    
            var kcinsiyetsParameter = kcinsiyets != null ?
                new ObjectParameter("Kcinsiyets", kcinsiyets) :
                new ObjectParameter("Kcinsiyets", typeof(string));
    
            var kkimlikSeriNosParameter = kkimlikSeriNos != null ?
                new ObjectParameter("KkimlikSeriNos", kkimlikSeriNos) :
                new ObjectParameter("KkimlikSeriNos", typeof(string));
    
            var kdogumYerisParameter = kdogumYeris != null ?
                new ObjectParameter("KdogumYeris", kdogumYeris) :
                new ObjectParameter("KdogumYeris", typeof(string));
    
            var kdogumTarihisParameter = kdogumTarihis.HasValue ?
                new ObjectParameter("KdogumTarihis", kdogumTarihis) :
                new ObjectParameter("KdogumTarihis", typeof(System.DateTime));
    
            var kdogumilisParameter = kdogumilis != null ?
                new ObjectParameter("Kdogumilis", kdogumilis) :
                new ObjectParameter("Kdogumilis", typeof(string));
    
            var kdogumilcesParameter = kdogumilces != null ?
                new ObjectParameter("Kdogumilces", kdogumilces) :
                new ObjectParameter("Kdogumilces", typeof(string));
    
            var kmahallesParameter = kmahalles != null ?
                new ObjectParameter("Kmahalles", kmahalles) :
                new ObjectParameter("Kmahalles", typeof(string));
    
            var kkoysParameter = kkoys != null ?
                new ObjectParameter("Kkoys", kkoys) :
                new ObjectParameter("Kkoys", typeof(string));
    
            var kciltsParameter = kcilts != null ?
                new ObjectParameter("Kcilts", kcilts) :
                new ObjectParameter("Kcilts", typeof(string));
    
            var kailesParameter = kailes != null ?
                new ObjectParameter("Kailes", kailes) :
                new ObjectParameter("Kailes", typeof(string));
    
            var kSiraNosParameter = kSiraNos != null ?
                new ObjectParameter("KSiraNos", kSiraNos) :
                new ObjectParameter("KSiraNos", typeof(string));
    
            var kVerilisYerisParameter = kVerilisYeris != null ?
                new ObjectParameter("KVerilisYeris", kVerilisYeris) :
                new ObjectParameter("KVerilisYeris", typeof(string));
    
            var kKayitNosParameter = kKayitNos != null ?
                new ObjectParameter("KKayitNos", kKayitNos) :
                new ObjectParameter("KKayitNos", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_PersonelEkle", tcNosParameter, adisParameter, soyadisParameter, sicilNosParameter, basvuruTarihisParameter, baslamaTarihisParameter, askerlikDurumusParameter, tecilBitisYilisParameter, kanGrubusParameter, cinsiyetsParameter, adressParameter, semtsParameter, ilcesParameter, ilsParameter, mailsParameter, evTelsParameter, cepTelsParameter, egitimDurumusParameter, ayrilisTarihisParameter, departmansParameter, ktcNosParameter, kuyruksParameter, kcinsiyetsParameter, kkimlikSeriNosParameter, kdogumYerisParameter, kdogumTarihisParameter, kdogumilisParameter, kdogumilcesParameter, kmahallesParameter, kkoysParameter, kciltsParameter, kailesParameter, kSiraNosParameter, kVerilisYerisParameter, kKayitNosParameter);
        }
    
        public virtual int sp_SinifEkle(string sinifAdi, Nullable<int> kapaSitesi, Nullable<int> ogretmenId, ObjectParameter returnid)
        {
            var sinifAdiParameter = sinifAdi != null ?
                new ObjectParameter("SinifAdi", sinifAdi) :
                new ObjectParameter("SinifAdi", typeof(string));
    
            var kapaSitesiParameter = kapaSitesi.HasValue ?
                new ObjectParameter("KapaSitesi", kapaSitesi) :
                new ObjectParameter("KapaSitesi", typeof(int));
    
            var ogretmenIdParameter = ogretmenId.HasValue ?
                new ObjectParameter("OgretmenId", ogretmenId) :
                new ObjectParameter("OgretmenId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SinifEkle", sinifAdiParameter, kapaSitesiParameter, ogretmenIdParameter, returnid);
        }
    
        public virtual int sp_UcuncuSahisEkle(string adi, string soyadi, string cepTel, string evTel, string tcNo, string yakinlikDerecesi, string meslek, string email, Nullable<int> ogrenciId)
        {
            var adiParameter = adi != null ?
                new ObjectParameter("Adi", adi) :
                new ObjectParameter("Adi", typeof(string));
    
            var soyadiParameter = soyadi != null ?
                new ObjectParameter("Soyadi", soyadi) :
                new ObjectParameter("Soyadi", typeof(string));
    
            var cepTelParameter = cepTel != null ?
                new ObjectParameter("CepTel", cepTel) :
                new ObjectParameter("CepTel", typeof(string));
    
            var evTelParameter = evTel != null ?
                new ObjectParameter("EvTel", evTel) :
                new ObjectParameter("EvTel", typeof(string));
    
            var tcNoParameter = tcNo != null ?
                new ObjectParameter("TcNo", tcNo) :
                new ObjectParameter("TcNo", typeof(string));
    
            var yakinlikDerecesiParameter = yakinlikDerecesi != null ?
                new ObjectParameter("YakinlikDerecesi", yakinlikDerecesi) :
                new ObjectParameter("YakinlikDerecesi", typeof(string));
    
            var meslekParameter = meslek != null ?
                new ObjectParameter("Meslek", meslek) :
                new ObjectParameter("Meslek", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var ogrenciIdParameter = ogrenciId.HasValue ?
                new ObjectParameter("OgrenciId", ogrenciId) :
                new ObjectParameter("OgrenciId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UcuncuSahisEkle", adiParameter, soyadiParameter, cepTelParameter, evTelParameter, tcNoParameter, yakinlikDerecesiParameter, meslekParameter, emailParameter, ogrenciIdParameter);
        }
    
        public virtual int sp_VeliEkle(string veliAdi, string veliSoyadi, string veliCeptel, string veliEvTel, string veliTcNo, string yakinlikDerecesi, string meslek, string email, Nullable<int> ogrenciId)
        {
            var veliAdiParameter = veliAdi != null ?
                new ObjectParameter("VeliAdi", veliAdi) :
                new ObjectParameter("VeliAdi", typeof(string));
    
            var veliSoyadiParameter = veliSoyadi != null ?
                new ObjectParameter("VeliSoyadi", veliSoyadi) :
                new ObjectParameter("VeliSoyadi", typeof(string));
    
            var veliCeptelParameter = veliCeptel != null ?
                new ObjectParameter("VeliCeptel", veliCeptel) :
                new ObjectParameter("VeliCeptel", typeof(string));
    
            var veliEvTelParameter = veliEvTel != null ?
                new ObjectParameter("VeliEvTel", veliEvTel) :
                new ObjectParameter("VeliEvTel", typeof(string));
    
            var veliTcNoParameter = veliTcNo != null ?
                new ObjectParameter("VeliTcNo", veliTcNo) :
                new ObjectParameter("VeliTcNo", typeof(string));
    
            var yakinlikDerecesiParameter = yakinlikDerecesi != null ?
                new ObjectParameter("YakinlikDerecesi", yakinlikDerecesi) :
                new ObjectParameter("YakinlikDerecesi", typeof(string));
    
            var meslekParameter = meslek != null ?
                new ObjectParameter("Meslek", meslek) :
                new ObjectParameter("Meslek", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var ogrenciIdParameter = ogrenciId.HasValue ?
                new ObjectParameter("OgrenciId", ogrenciId) :
                new ObjectParameter("OgrenciId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_VeliEkle", veliAdiParameter, veliSoyadiParameter, veliCeptelParameter, veliEvTelParameter, veliTcNoParameter, yakinlikDerecesiParameter, meslekParameter, emailParameter, ogrenciIdParameter);
        }
    
        public virtual int sp_YemekYukle(string corba, string anaYemek, string tatli, string tarih)
        {
            var corbaParameter = corba != null ?
                new ObjectParameter("Corba", corba) :
                new ObjectParameter("Corba", typeof(string));
    
            var anaYemekParameter = anaYemek != null ?
                new ObjectParameter("AnaYemek", anaYemek) :
                new ObjectParameter("AnaYemek", typeof(string));
    
            var tatliParameter = tatli != null ?
                new ObjectParameter("Tatli", tatli) :
                new ObjectParameter("Tatli", typeof(string));
    
            var tarihParameter = tarih != null ?
                new ObjectParameter("Tarih", tarih) :
                new ObjectParameter("Tarih", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_YemekYukle", corbaParameter, anaYemekParameter, tatliParameter, tarihParameter);
        }
    }
}
