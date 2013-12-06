using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AnaOkuluWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AnaOkuluWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AnaOkuluWebService.svc or AnaOkuluWebService.svc.cs at the Solution Explorer and start debugging.
    public class AnaOkuluWebService : IAnaOkuluWebService
    {
        #region DEĞİŞKENLER
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString());
        #endregion

        #region KULLANICILAR

        public bool GirisKontrol(string userid, string userpass, string departman)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("use AnaOkuluDB select dbo.GirisKontrol(@userid,@userpass,@comdepart)", conn);
                cmd.Parameters.Add("@userid", SqlDbType.NVarChar, 50).Value = userid;
                cmd.Parameters.Add("@userpass", SqlDbType.NVarChar, 50).Value = userpass;
                cmd.Parameters.Add("@comdepart", SqlDbType.NVarChar, 50).Value = departman;
                bool temp = Convert.ToBoolean(cmd.ExecuteScalar());
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return temp;
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public bool ParolaDegistir(string oldpassword, string createpassword, string userid, string departman)
        {
            try
            {
                if (GirisKontrol(userid, oldpassword, departman))
                {

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using (SqlCommand cmd = new SqlCommand("ParolaDegistir", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@confirmpassword", oldpassword);
                        cmd.Parameters.AddWithValue("@createpassword", createpassword);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.Add(new SqlParameter("@returnbit", SqlDbType.Bit));
                        cmd.Parameters["@returnbit"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        bool temp = Convert.ToBoolean(cmd.Parameters["@returnbit"].Value);
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        return temp;
                    }
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                return false;
            }


        }
        public List<pwd> TumKullanicilar(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using(AnaOkuluDBEntities db=new AnaOkuluDBEntities())
                    {
                        return db.pwd.ToList();
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                pwd temp = new pwd();
                temp.firstname = err.Message;
                var temp2 = new List<pwd>();
                temp2.Add(temp);
                return temp2;
            }
        }
        public bool KullaniciEkle(string userid, string userpass, string departman, pwd pwd)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        db.pwd.Add(pwd);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public bool KontrolAdVeSoyad(string userid, string userpass, string departman, string ad, string soyad)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.pwd.FirstOrDefault(f => f.firstname == ad && f.lastname == soyad);
                        if (item == null)
                            return true;
                        else
                            return false;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }

        #endregion

        #region YEMEKLER
        public List<Yemekler> TumYemekler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Yemekler select item).ToList<Yemekler>();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                Yemekler yem = new Yemekler();
                yem.AnaYemek = err.Message;
                var list = new List<Yemekler>();
                list.Add(yem);
                return list;
            }
        }
        public bool YemekEkle(string userid, string userpass, string departman, string corba, string anayemek, string tatli, string tarih)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        db.sp_YemekYukle(corba, anayemek, tatli, tarih);
                        return true;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {


                return false;
            }
        }
        public bool YemekSil(string userid, string userpass, string departman, int id)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Yemekler.FirstOrDefault(f => f.YemekId == id);
                        if (item != null)
                        {
                            db.Yemekler.Remove(item);
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("Veri Bulunamadi");
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        #endregion

        #region DEMİRBAS
        public bool DemirbasGunceller(string userid, string userpass, string departman,DemirbaslarDB demirbas)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using(AnaOkuluDBEntities db=new AnaOkuluDBEntities())
                    {
                        var item = db.Demirbaslar.FirstOrDefault(f => f.DEMIRBASID == demirbas.DEMIRBASID);
                        if (item != null)
                        {
                            item.Adet = demirbas.Adet;
                            item.Adi = demirbas.Adi;
                            item.AlindigiYer = demirbas.AlindigiYer;
                            item.AlisFaturaNo = demirbas.AlisFaturaNo;
                            item.AlisTarihi = demirbas.AlisTarihi;
                            item.Birim = demirbas.Birim;
                            item.Cinsi = demirbas.Cinsi;
                            item.DEMIRBASID = demirbas.DEMIRBASID;
                            item.GirisTutari = demirbas.GirisTutari;
                            item.KdvOrani = demirbas.KdvOrani;
                            item.KdvTutari = demirbas.KdvTutari;
                            item.SatisFaturaNo = demirbas.SatisFaturaNo;
                            item.SatisKdvTutari = demirbas.SatisKdvTutari;
                            item.SatisNedeni = demirbas.SatisNedeni;
                            item.SatisTarihi = demirbas.SatisTarihi;
                            item.SatisTutari = demirbas.SatisTutari;
                            item.SatisYeri = demirbas.SatisYeri;
                            item.Turu = demirbas.Turu;
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("Kayit Bulunamadı.");
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public IList<DemirbaslarDB> TumDemirbaslar(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using(AnaOkuluDBEntities db=new AnaOkuluDBEntities())
                    {
                        var item = (from i in db.Demirbaslar
                                    select new DemirbaslarDB
                                    {
                                        Adet = i.Adet.Value,
                                        Adi = i.Adi,
                                        AlindigiYer = i.AlindigiYer,
                                        AlisFaturaNo = i.AlisFaturaNo,
                                        AlisTarihi = i.AlisTarihi.Value,
                                        Birim = i.Birim,
                                        Cinsi = i.Cinsi,
                                        DEMIRBASID = i.DEMIRBASID,
                                        GirisTutari = i.GirisTutari.Value,
                                        KdvOrani = i.KdvOrani.Value,
                                        KdvTutari = i.KdvTutari.Value,
                                        SatisFaturaNo = i.SatisFaturaNo,
                                        SatisKdvTutari = i.SatisKdvTutari.Value ,
                                        SatisNedeni = i.SatisNedeni,
                                        SatisTarihi = i.SatisTarihi.Value ,
                                        SatisTutari = i.SatisTutari.Value,
                                        SatisYeri = i.SatisYeri,
                                        Turu=i.Turu
                                    }).ToList();
                        return item;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                DemirbaslarDB dem = new DemirbaslarDB();
                dem.Adi = err.Message;
                var item = new List<DemirbaslarDB>();
                item.Add(dem);
                return item;
            }
        }
        public bool DemirbasEkle(string userid, string userpass, string departman, DemirbaslarDB demirbas)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        Demirbaslar temp = new Demirbaslar
                        {
                            Adet = demirbas.Adet,
                            Adi=demirbas.Adi,
                            AlindigiYer=demirbas.AlindigiYer,
                            AlisFaturaNo=demirbas.AlisFaturaNo,
                            AlisTarihi=demirbas.AlisTarihi,
                            Birim=demirbas.Birim,
                            Cinsi=demirbas.Cinsi,
                            DEMIRBASID=demirbas.DEMIRBASID,
                            GirisTutari=demirbas.GirisTutari,
                            KdvOrani=demirbas.KdvOrani,
                            KdvTutari=demirbas.KdvTutari,
                            SatisFaturaNo=demirbas.SatisFaturaNo,
                            SatisKdvTutari=demirbas.SatisKdvTutari,
                            SatisNedeni=demirbas.SatisNedeni,
                            SatisTarihi=demirbas.SatisTarihi,
                            SatisTutari=demirbas.SatisTutari,
                            SatisYeri=demirbas.SatisYeri,
                            Turu=demirbas.Turu
                        };
                        db.Demirbaslar.Add(temp);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public bool DemirbasSil(string userid, string userpass, string departman, int demirbasid)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Demirbaslar.FirstOrDefault(f => f.DEMIRBASID == demirbasid);
                        if (item != null)
                        {
                            db.Demirbaslar.Remove(item);
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("Veri Bulunamadi");
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        #endregion

        #region SERVİSLER
        public IList<ServislerDB> TumServisler()
        {
            try
            {
                
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = (from temp in db.Servisler
                                    select new ServislerDB
                                    {
                                        AD = temp.ServisAdi,
                                        ID = temp.ServisID
                                    }).ToList();
                        return item;
                    }               
            }
            catch (Exception err)
            {          
                return null;
            }
        }
        #endregion

        #region UCUNCU SAHIS

        public List<UcuncuSahislar> TumUcuncuSahis()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = (from item in db.UcuncuSahislar select item).ToList<UcuncuSahislar>();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region VELİLER
        public List<string> VeliEmailler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Veliler select item.Email).ToList<string>();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {

                var list = new List<String>();
                list.Add(err.Message);
                return list;
            }
        }
        public List<Veliler> TumVeliler()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = (from item in db.Veliler select item).ToList<Veliler>();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region OGRETMENLER
        public List<OgretmelerDB> TumOgretmenler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Personeller
                                    join item1 in db.Ogretmenler on item.PersonelId equals item1.PersonelID
                                    select new OgretmelerDB
                                    {
                                        AD = item1.Adi,
                                        SOYAD = item1.Soyadi,
                                        ID = item1.PersonelID,
                                        TC = item.TcNo
                                    }).ToList<OgretmelerDB>();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                var s = new OgretmelerDB();
                s.AD = err.Message;
                var list = new List<OgretmelerDB>();
                list.Add(s);
                return list;
            }
        }
        #endregion

        #region OGRENCİLER
        public IList<OgrencilerDB> TumOgrenciler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        ;
                        DateTime? dt = Convert.ToDateTime(null ?? null);

                        
                        var list = (from item in db.Ogrenciler
                                    select new OgrencilerDB
                                    {
                                        Adi = item.Adi,
                                        Adres = item.Adres,
                                        Aile = item.Aile,
                                        Alerjiler = item.Alerjiler,
                                        Ameliyatlar = item.Ameliyatlar,
                                        Asilar = item.Asilar,
                                        CikisTarihi = Convert.ToDateTime(item.CikisTarihi.Value.ToShortDateString() ?? null),
                                        Cilt = item.Cilt,
                                        Cinsiyet = item.Cinsiyet,
                                        DavranisSorunu = item.DavranisSorunu,
                                        Diyet = item.Diyet,
                                        Dogumilce = item.Dogumilce,
                                        Dogumili = item.Dogumili,
                                        DogumTarihi = item.DogumTarihi.Value,
                                        DogumYeri = item.DogumYeri,
                                        EvTel = item.EvTel,
                                        Fobileri = item.Fobileri,
                                        GecirdigiHastaliklar=item.GecirdigiHastaliklar,
                                        il=item.il,
                                        ilac=item.ilac,
                                        ilce=item.ilce,
                                        KanGrubu=item.KanGrubu,
                                        KayitNo=item.KayitNo,
                                        KayitTarihi=item.KayitTarihi.Value,
                                        KimlikSeriNo=item.KimlikSeriNo,
                                        Koy=item.Koy,
                                        Mahalle=item.Mahalle,
                                        OgrenciId=item.OgrenciId,
                                        PostaKodu=item.PostaKodu,
                                        Protez=item.Protez,
                                        Resim=item.Resim,
                                        RuhsalDurum=item.RuhsalDurum,
                                        SaglikSorunlari=item.SaglikSorunlari,
                                        Semt=item.Semt,
                                        ServisId=item.ServisId,
                                        SevdigiYiyecekler=item.SevdigiYiyecekler,
                                        SinifId=item.SinifId,
                                        SiraNo=item.SiraNo,
                                        Soyadi=item.Soyadi,
                                        TcNo=item.TcNo,
                                        Uyruk=item.Uyruk,
                                        VerilisYeri=item.VerilisYeri,
                                        Yapilanlar=item.Yapilanlar,
                                        YasitlariylaIliskisi=item.YasitlariylaIliskisi
                                    }).ToList();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {

                var list = new List<String>();
                list.Add(err.Message);
                return null;
            }
        }

        public IList<OgrencilerDB> OgrecilerSinifaGore(string userid, string userpass, string departman, int sinifid)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region    PERSONEL
        public List<PersonellerDB> TumPersoneller()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = db.Personeller.Select(item => new PersonellerDB
                    {
                        Adi = item.Adi,
                        Adres = item.Adres,
                        AskerlikDurumu = item.AskerlikDurumu,
                        AyrilisTarihi = item.AyrilisTarihi,
                        BaslamaTarihi = item.BaslamaTarihi,
                        BasvuruTarihi = item.BasvuruTarihi,
                        CepTel = item.CepTel,
                        Cinsiyet = item.Cinsiyet,
                        Departman = item.Departman,
                        EgitimDurumu = item.EgitimDurumu,
                        EvTel = item.EvTel,
                        il = item.il,
                        Ilce = item.Ilce,
                        Kaile = item.Kaile,
                        KanGrubu = item.KanGrubu,
                        Kcilt = item.Kcilt,
                        Kdogumilce = item.Kdogumilce,
                        Kdogumili = item.Kdogumili,
                        KdogumTarihi = item.KdogumTarihi,
                        KdogumYeri = item.KdogumYeri,
                        KKayitNo = item.KKayitNo,
                        KkimlikSeriNo = item.KkimlikSeriNo,
                        Kkoy = item.Kkoy,
                        Kmahalle = item.Kmahalle,
                        KSiraNo = item.KSiraNo,
                        Kuyruk = item.Kuyruk,
                        KVerilisYeri = item.KVerilisYeri,
                        Mail = item.Mail,
                        PersonelId = item.PersonelId,
                        Semt = item.Semt,
                        SicilNo = item.SicilNo,
                        Soyadi = item.Soyadi,
                        TcNo = item.TcNo,
                        TecilBitisYili = item.TecilBitisYili,
       




                    }).ToList();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region SINIF
        public List<SiniflarDB> TumSiniflar(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Siniflar
                                    select new SiniflarDB
                                    {
                                        ögretmenId=item.ögretmenId,
                                        sinifAdi=item.sinifAdi,
                                        sinifId=item.sinifId,
                                        sinifkapasite=item.sinifkapasite 
                                    }).ToList();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                var s = new SiniflarDB();
                s.sinifAdi = err.Message;
                var list = new List<SiniflarDB>();
                list.Add(s);
                return list;
            }
        }
        public bool SinifSil(string userid, string userpass, string departman, int sinifid)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Siniflar.FirstOrDefault(f => f.sinifId == sinifid);
                        if (item != null)
                        {
                            db.Siniflar.Remove(item);
                            db.ChangeTracker.DetectChanges();
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("Veri Bulunamadi");
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public bool SinifEkle(string userid, string userpass, string departman, string sinifadi, int sinifkapasitesi, int ogretmenid)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {


                        db.sp_SinifEkle(sinifadi, sinifkapasitesi, ogretmenid);
                        return true;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        #endregion

        #region YOKLAMA
        public IEnumerable<Yoklama> TumYoklama()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = db.Yoklama.AsEnumerable<Yoklama>();                                      
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region DEMİRBAS MEKANLARI

        public IList<DemirbasMekanlariDB> TumDemirbasMekanlari(string userid, string userpass, string departman)
        {
            try
            {
                 if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.DemirbasMekanlari
                                    select new DemirbasMekanlariDB
                                    {
                                        Adet = item.Adet,
                                        BulunduguYer = item.BulunduguYer,
                                        DemirbasId = item.DemirbasId,
                                        MekanId = item.MekanId,
                                        Sorumlusu = item.Sorumlusu,
                                        TeslimTarihi = item.TeslimTarihi
                                    }).ToList();
                        return list;
                    }
                }
                 else
                     throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {

                return null;
            }
        }
        public bool DemirbasMekanlariSil(string userid, string userpass, string departman, int id)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.DemirbasMekanlari.FirstOrDefault(f => f.MekanId == id);
                        if (item != null)
                        {
                            db.DemirbasMekanlari.Remove(item);
                            db.SaveChanges();
                            return true;
                        }
                        else
                            throw new Exception("Veri Bulunamadi");
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DemirbasMekanlariEkle(string userid, string userpass, string departman, DemirbasMekanlariDB demirbasmekanlari)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        DemirbasMekanlari temp = new DemirbasMekanlari
                        {
                            Adet=demirbasmekanlari.Adet,
                            BulunduguYer=demirbasmekanlari.BulunduguYer,
                            DemirbasId=demirbasmekanlari.DemirbasId,
                            MekanId=demirbasmekanlari.MekanId,
                            Sorumlusu=demirbasmekanlari.Sorumlusu,
                            TeslimTarihi=Convert.ToDateTime(demirbasmekanlari.TeslimTarihi.Value.ToShortDateString() ?? null)
                        };
                        db.DemirbasMekanlari.Add(temp);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return false;
            }
        }
        #endregion















        public Yoklama Yoklama(int ogrenciid)
        {
            using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
            {
                return db.Yoklama.First(f=>f.OgrenciId==ogrenciid);
            }
        }








        
    }
}
