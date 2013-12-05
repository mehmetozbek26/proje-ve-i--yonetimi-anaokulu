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
        public bool DemirbasGunceller(string userid, string userpass, string departman,Demirbaslar demirbas)
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
                            item = demirbas;
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
        public List<Demirbaslar> TumDemirbaslar(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using(AnaOkuluDBEntities db=new AnaOkuluDBEntities())
                    {
                        var item=db.Demirbaslar.ToList<Demirbaslar>();
                        return item;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                Demirbaslar dem = new Demirbaslar();
                dem.Adi = err.Message;
                var item = new List<Demirbaslar>();
                item.Add(dem);
                return item;
            }
        }
        public bool DemirbasEkle(string userid, string userpass, string departman, Demirbaslar demirbas)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {                       
                        db.Demirbaslar.Add(demirbas);
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
        public List<Ogrenciler> TumOgrenciler()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = (from item in db.Ogrenciler select item).ToList<Ogrenciler>();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region    PERSONEL
        public List<Personeller> TumPersoneller()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = (from item in db.Personeller select item).ToList<Personeller>();
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
        public List<Siniflar> TumSiniflar(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Siniflar select item).ToList<Siniflar>();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
            catch (Exception err)
            {
                var s = new Siniflar();
                s.sinifAdi = err.Message;
                var list = new List<Siniflar>();
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

        public IList<DemirbasMekanlari> TumDemirbasMekanlari()
        {
            try
            {

                using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                {
                    var list = (from item in db.DemirbasMekanlari
                                select new DemirbasMekanlari
                                {
                                    MekanId = item.MekanId,
                                    Adet=item.Adet,
                                    BulunduguYer=item.BulunduguYer,
                                    DemirbasId=item.DemirbasId,
                                    Sorumlusu=item.Sorumlusu,
                                    TeslimTarihi=item.TeslimTarihi
                                }).ToList<DemirbasMekanlari>();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
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
