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
  
    public class AnaOkuluWebService : IAnaOkuluWebService
    {
        #region DEĞİŞKENLER
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VeriTabani"].ToString());
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
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
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
        public bool YemekEkle(string userid, string userpass, string departman, string corba, string anayemek, string tatli, DateTime tarih)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        db.Yemekler.Add(new Yemekler
                        {
                            AnaYemek=anayemek,
                            Corba=corba,
                            Tarih=tarih,
                            Tatli=tatli
                        });
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
        public int DemirbasEkle(string userid, string userpass, string departman, DemirbaslarDB demirbas)
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
                        return temp.DEMIRBASID;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                return 0;
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
        public IList<ServislerDB> TumServisler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
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
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
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
        public bool UcuncuSahisEkle(string userid, string userpass, string departman, UcuncuSahisDB uc)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        db.UcuncuSahislar.Add(new UcuncuSahislar
                        {
                            Adi=uc.Adi,
                            Ceptel=uc.Ceptel,
                            Email=uc.Email, 
                            EvTel=uc.EvTel,
                            Meslek=uc.Meslek,
                            OgrenciId=uc.OgrenciId,
                            Soyadi=uc.Soyadi,
                            TcNo=uc.TcNo,
                            YakinlikDerecesi=uc.YakinlikDerecesi
                        });
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
        public List<VelilerDB> TumVeliler(string userid, string userpass, string departman)
        {
            try
            {
                 if (GirisKontrol(userid, userpass, departman))
                {
                        using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                        {
                            var list = (from item in db.Veliler
                                        select new VelilerDB
                                        {
                                            Adi=item.Adi,
                                            Ceptel=item.Ceptel,
                                            Email=item.Email,
                                            EvTel=item.EvTel,
                                            Id=item.Id,
                                            Meslek=item.Meslek,
                                            OgrenciId=item.OgrenciId,
                                            Soyadi=item.Soyadi,
                                            TcNo=item.TcNo,
                                            YakinlikDerecesi=item.YakinlikDerecesi
                                        }).ToList<VelilerDB>();
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
        public bool VeliEkle(string userid, string userpass, string departman, VelilerDB veli)
        {
            try
            {
               if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        //db.sp_VeliEkle(veli.Adi,veli.Soyadi,veli.Ceptel,veli.EvTel,veli.TcNo,veli.YakinlikDerecesi,veli.Meslek,veli.Email,veli.OgrenciId);
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
                                        TC = item.TcNo,
                                        KAYITID=item1.KayitId
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
                      


                        
                        var list = (from item in db.Ogrenciler
                                    select new OgrencilerDB
                                    {
                                        Adi = item.Adi,
                                        Adres = item.Adres,
                                        Aile = item.Aile,
                                        Alerjiler = item.Alerjiler,
                                        Ameliyatlar = item.Ameliyatlar,
                                        Asilar = item.Asilar,
                                        Cilt = item.Cilt,
                                        Cinsiyet = item.Cinsiyet,
                                        DavranisSorunu = item.DavranisSorunu,
                                        Diyet = item.Diyet,
                                        Dogumilce = item.Dogumilce,
                                        Dogumili = item.Dogumili,
                                        DogumTarihi = item.DogumTarihi,
                                        DogumYeri = item.DogumYeri,
                                        EvTel = item.EvTel,
                                        Fobileri = item.Fobileri,
                                        GecirdigiHastaliklar=item.GecirdigiHastaliklar,
                                        il=item.il,
                                        ilac=item.ilac,
                                        ilce=item.ilce,
                                        KanGrubu=item.KanGrubu,
                                        KayitNo=item.KayitNo,
                                        KayitTarihi=item.KayitTarihi,
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
        public OgrencilerDB OgrenciGetirID(string userid, string userpass, string departman, int id)
        {
            try
            {
                //if (GirisKontrol(userid, userpass, departman))
                //{
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {

                        var item = db.Ogrenciler.FirstOrDefault(f => f.OgrenciId == id);
                        if (item != null)
                        {
                            OgrencilerDB temp = new OgrencilerDB
                            {
                                 Adi = item.Adi,
                                        Adres = item.Adres,
                                        Aile = item.Aile,
                                        Alerjiler = item.Alerjiler,
                                        Ameliyatlar = item.Ameliyatlar,
                                        Asilar = item.Asilar,
                                        Cilt = item.Cilt,
                                        Cinsiyet = item.Cinsiyet,
                                        DavranisSorunu = item.DavranisSorunu,
                                        Diyet = item.Diyet,
                                        Dogumilce = item.Dogumilce,
                                        Dogumili = item.Dogumili,
                                        DogumTarihi = item.DogumTarihi,
                                        DogumYeri = item.DogumYeri,
                                        EvTel = item.EvTel,
                                        Fobileri = item.Fobileri,
                                        GecirdigiHastaliklar=item.GecirdigiHastaliklar,
                                        il=item.il,
                                        ilac=item.ilac,
                                        ilce=item.ilce,
                                        KanGrubu=item.KanGrubu,
                                        KayitNo=item.KayitNo,
                                        KayitTarihi = item.KayitTarihi,
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
                            };
                           return temp;
                        }
                        else
                            throw new Exception("Boyle Kayıt Yok");
                    }
                //}
                //else
                //    throw new Exception("Kullanici Dogrulanmıyor");
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
             try
            {

                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = db.Ogrenciler.Where(w => w.SinifId == sinifid).Select(s => new OgrencilerDB
                        {
                            Adi = s.Adi,
                            Adres = s.Adres,
                            Aile = s.Aile,
                            Alerjiler = s.Alerjiler,
                            Ameliyatlar = s.Ameliyatlar,
                            Asilar = s.Asilar,
                            Cilt = s.Cilt,
                            Cinsiyet = s.Cinsiyet,
                            DavranisSorunu = s.DavranisSorunu,
                            Diyet = s.Diyet,
                            Dogumilce = s.Dogumilce,
                            Dogumili = s.Dogumili,
                            DogumTarihi = s.DogumTarihi,
                            DogumYeri = s.DogumYeri,
                            EvTel = s.EvTel,
                            Fobileri = s.Fobileri,
                            GecirdigiHastaliklar = s.GecirdigiHastaliklar,
                            il = s.il,
                            ilac = s.ilac,
                            ilce = s.ilce,
                            KanGrubu = s.KanGrubu,
                            KayitNo = s.KayitNo,
                            KayitTarihi = s.KayitTarihi,
                            KimlikSeriNo = s.KimlikSeriNo,
                            Koy = s.Koy,
                            Mahalle = s.Mahalle,
                            OgrenciId = s.OgrenciId,
                            PostaKodu = s.PostaKodu,
                            Protez = s.Protez,
                            Resim = s.Resim,
                            RuhsalDurum = s.RuhsalDurum,
                            SaglikSorunlari = s.SaglikSorunlari,
                            Semt = s.Semt,
                            ServisId = s.ServisId,
                            SevdigiYiyecekler = s.SevdigiYiyecekler,
                            SinifId = s.SinifId,
                            SiraNo = s.SiraNo,
                            Soyadi = s.Soyadi,
                            TcNo = s.TcNo,
                            Uyruk = s.Uyruk,
                            VerilisYeri = s.VerilisYeri,
                            Yapilanlar = s.Yapilanlar,
                            YasitlariylaIliskisi = s.YasitlariylaIliskisi
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
        public int OgrenciEkle(string userid, string userpass, string departman, OgrencilerDB ogrenci)
        {
           try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    int ogrid;
                    using (SqlCommand cmd = new SqlCommand("sp_OgrenciKayitEkle", conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Adi", ogrenci.Adi);
                        cmd.Parameters.Add("@Soyadi", ogrenci.Soyadi);
                        cmd.Parameters.Add("@Adres", ogrenci.Adres);
                        cmd.Parameters.Add("@Semt", ogrenci.Semt);
                        cmd.Parameters.Add("@ilce", ogrenci.ilce);
                        cmd.Parameters.Add("@il", ogrenci.il);
                        cmd.Parameters.Add("@PostaKodu", ogrenci.PostaKodu);
                        cmd.Parameters.Add("@EvTel", ogrenci.EvTel);
                        cmd.Parameters.Add("@KanGrubu", ogrenci.KanGrubu);
                        cmd.Parameters.Add("@TcNo", ogrenci.TcNo);
                        cmd.Parameters.Add("@Uyruk", ogrenci.Uyruk);
                        cmd.Parameters.Add("@Cinsiyet", ogrenci.Cinsiyet);
                        cmd.Parameters.Add("@KimlikSeriNo", ogrenci.KimlikSeriNo);
                        cmd.Parameters.Add("@DogumYeri", ogrenci.DogumYeri);
                        cmd.Parameters.Add("@DogumTarihi", ogrenci.DogumTarihi);
                        cmd.Parameters.Add("@Dogumili", ogrenci.Dogumili);
                        cmd.Parameters.Add("@Dogumilce", ogrenci.Dogumilce);
                        cmd.Parameters.Add("@Mahalle", ogrenci.Mahalle);
                        cmd.Parameters.Add("@Koy", ogrenci.Koy);
                        cmd.Parameters.Add("@Cilt", ogrenci.Cilt);
                        cmd.Parameters.Add("@Aile", ogrenci.Aile);
                        cmd.Parameters.Add("@SiraNo", ogrenci.SiraNo);
                        cmd.Parameters.Add("@VerilisYeri", ogrenci.VerilisYeri);
                        cmd.Parameters.Add("@KayitNo",ogrenci.KayitNo);
                        if (ogrenci.Resim!=null && ogrenci.Resim.Length>0)
                            cmd.Parameters.Add("@Resim", SqlDbType.Image, ogrenci.Resim.Length).Value = ogrenci.Resim;
                        else
                            cmd.Parameters.Add("@Resim", SqlDbType.Image, 0).Value = DBNull.Value;
                        cmd.Parameters.Add("@SinifId", ogrenci.SinifId);
                        cmd.Parameters.Add("@ServisId", ogrenci.ServisId);
                        cmd.Parameters.Add("@KayitTarihi", ogrenci.KayitTarihi);
                        cmd.Parameters.Add("@DavranisSorunu", ogrenci.DavranisSorunu);
                        cmd.Parameters.Add("@Yapilanlar", ogrenci.Yapilanlar);
                        cmd.Parameters.Add("@YasitlariylaIliskisi", ogrenci.YasitlariylaIliskisi);
                        cmd.Parameters.Add("@Fobileri", ogrenci.Fobileri);
                        cmd.Parameters.Add("@SevdigiYiyecekler", ogrenci.SevdigiYiyecekler);
                        cmd.Parameters.Add("@Asilar", ogrenci.Asilar);
                        cmd.Parameters.Add("@GecirdigiHastaliklar", ogrenci.GecirdigiHastaliklar);
                        cmd.Parameters.Add("@Alerjiler", ogrenci.Alerjiler);
                        cmd.Parameters.Add("@Ameliyatlar", ogrenci.Ameliyatlar);
                        cmd.Parameters.Add("@SaglikSorunlari", ogrenci.SaglikSorunlari);
                        cmd.Parameters.Add("@ilac", ogrenci.ilac);
                        cmd.Parameters.Add("@Protez", ogrenci.Protez);
                        cmd.Parameters.Add("@Diyet", ogrenci.Diyet);
                        cmd.Parameters.Add("@RuhsalDurum", ogrenci.RuhsalDurum);
                        SqlParameter retval = cmd.Parameters.Add("@ReturnId", SqlDbType.Int);
                        retval.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        ogrid = (int)cmd.Parameters["@ReturnId"].Value;                         
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                            return ogrid;     
                    }
                    
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
           catch (Exception err)
           {
               return 0;
           }
           finally
           {
               if (conn.State == ConnectionState.Open)
                   conn.Close();
           }
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
                        Durumu=item.Durumu
                    }).ToList();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        public bool PersonelKayit(string userid, string userpass, string departman, PersonellerDB per)
        {
            try
            {
                 if (GirisKontrol(userid, userpass, departman))
                {
                        using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                        {
                            var item=new Personeller
                            {                               
                                Adi=per.Adi,
                                Adres=per.Adres,
                                AskerlikDurumu=per.AskerlikDurumu,                   
                                BaslamaTarihi=per.BaslamaTarihi,
                                BasvuruTarihi=per.BasvuruTarihi,
                                CepTel=per.CepTel,
                                Cinsiyet=per.Cinsiyet,
                                Departman=per.Departman,
                                EgitimDurumu=per.EgitimDurumu,
                                EvTel=per.EvTel,
                                il=per.il,
                                Ilce=per.Ilce,
                                Kaile=per.Kaile,
                                KanGrubu=per.KanGrubu,
                                Kcilt=per.Kcilt,
                                Kdogumilce=per.Kdogumilce,
                                Kdogumili=per.Kdogumili,
                                KdogumTarihi=per.KdogumTarihi,
                                KdogumYeri=per.KdogumYeri,
                                KKayitNo=per.KKayitNo,
                                KkimlikSeriNo=per.KkimlikSeriNo,
                                Kkoy=per.Kkoy,
                                Kmahalle=per.Kmahalle,
                                KSiraNo=per.KSiraNo,
                                Kuyruk=per.Kuyruk,
                                KVerilisYeri=per.KVerilisYeri,
                                Mail=per.Mail,
                                PersonelId=per.PersonelId,
                                Semt=per.Semt,
                                SicilNo=per.SicilNo,
                                Soyadi=per.Soyadi,
                                TcNo=per.TcNo,
                                TecilBitisYili=per.TecilBitisYili
                            };
                            db.Personeller.Add(item);
                            db.SaveChanges();
                            if (item.Departman == "OGRETMEN")
                            {
                                db.Ogretmenler.Add(new Ogretmenler
                                {
                                    Adi = item.Adi,
                                    PersonelID = item.PersonelId,
                                    Soyadi = item.Soyadi
                                });
                                db.SaveChanges();
                            }
                            
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
        public bool PersonelSil(string userid, string userpass, string departman, int id)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Personeller.FirstOrDefault(f => f.PersonelId == id);
                        if (item != null)
                        {
                            db.Personeller.Remove(item);
                            db.SaveChanges();
                            return true;
                        }
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
        public bool PersonelGuncelle(string userid, string userpass, string departman, PersonellerDB per)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Personeller.FirstOrDefault(f => f.PersonelId == per.PersonelId);
                        if (item != null)
                        {
                            item.Adi = per.Adi;
                            item.Adres = per.Adres;
                            item.AskerlikDurumu = per.AskerlikDurumu;
                            item.BaslamaTarihi = per.BaslamaTarihi;
                            item.BasvuruTarihi = per.BasvuruTarihi;
                            item.CepTel = per.CepTel;
                            item.Cinsiyet = per.Cinsiyet;
                            item.Departman = per.Departman;
                            item.EgitimDurumu = per.EgitimDurumu;
                            item.EvTel = per.EvTel;
                            item.il = per.il;
                            item.Ilce = per.Ilce;
                            item.Kaile = per.Kaile;
                            item.KanGrubu = per.KanGrubu;
                            item.Kcilt = per.Kcilt;
                            item.Kdogumilce = per.Kdogumilce;
                            item.Kdogumili = per.Kdogumili;
                            item.KdogumTarihi = per.KdogumTarihi;
                            item.KdogumYeri = per.KdogumYeri;
                            item.KKayitNo = per.KKayitNo;
                            item.KkimlikSeriNo = per.KkimlikSeriNo;
                            item.Kkoy = per.Kkoy;
                            item.Kmahalle = per.Kmahalle;
                            item.KSiraNo = per.KSiraNo;
                            item.Kuyruk = per.Kuyruk;
                            item.KVerilisYeri = per.KVerilisYeri;
                            item.Mail = per.Mail;
                            item.PersonelId = per.PersonelId;
                            item.Semt = per.Semt;
                            item.SicilNo = per.SicilNo;
                            item.Soyadi = per.Soyadi;
                            item.TcNo = per.TcNo;
                            item.TecilBitisYili = per.TecilBitisYili;
                            db.SaveChanges();

                            if (item.Departman == "OGRETMEN")
                            {
                                var item2 = db.Ogretmenler.FirstOrDefault(f => f.PersonelID == per.PersonelId);
                                if (item2 != null)
                                {
                                    item2.Soyadi = per.Soyadi;
                                    item2.Adi = per.Adi;
                                    db.SaveChanges();
                                }
                                else
                                {
                                    db.Ogretmenler.Add(new Ogretmenler
                                    {
                                        Adi = per.Adi,
                                        PersonelID = per.PersonelId,
                                        Soyadi = per.Soyadi
                                    });
                                    db.SaveChanges();
                                }
                            }
                            return true;
                        }
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
        public IEnumerable<YoklamaDB> TumYoklamaById(string userid, string userpass, string departman, int sinifid)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Yoklama
                                    join item1 in db.Ogrenciler on item.OgrenciId equals item1.OgrenciId
                                    join item2 in db.Veliler on item1.OgrenciId equals item2.OgrenciId
                                    where item.SinifId==sinifid
                                    select new YoklamaDB
                                    {
                                        ACIKLAMA=item.Aciklama,
                                        DEVAMSIZLIK=item.DevamsizlikTuru,
                                        ID=item.ID,
                                        OGRENCIADI=item1.Adi,
                                        OgrenciId=item.OgrenciId,
                                        OGRENCISOYADI=item1.Soyadi,
                                        SinifId=item.SinifId,
                                        TARIH=item.Tarih,
                                        VELIADI=item2.Adi,
                                        VELIEMAIL=item2.Email,
                                        VeliId=item2.Id,
                                        VELISOYADI=item2.Soyadi
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













       
    }
}
