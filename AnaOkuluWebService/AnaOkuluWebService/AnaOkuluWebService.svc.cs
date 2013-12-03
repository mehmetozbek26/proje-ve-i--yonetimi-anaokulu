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

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString());
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
        public List<Yemekler> TumYemekler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Yemeklers select item).ToList<Yemekler>();
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
        public List<string> VeliEmailler(string userid, string userpass, string departman)
        {
             try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using(AnaOkuluDBEntities db=new AnaOkuluDBEntities())
                    {
                        var list=(from item in db.Velilers select item.Email).ToList<string>();
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
                        var item = db.Yemeklers.FirstOrDefault(f => f.YemekId == id);
                        if (item != null)
                        {
                            db.Yemeklers.Remove(item);
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
        public List<Siniflar> TumSiniflar(string userid, string userpass, string departman)
        {
             try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Siniflars select item).ToList<Siniflar>();
                        return list;
                    }
                }
                else
                    throw new Exception("Kullanici Dogrulanmıyor");
            }
             catch (Exception err)
             {
                 var s =new Siniflar();
                 s.sinifAdi = err.Message;
                 var list = new List<Siniflar>();
                 list.Add(s);
                 return list;
             }
        }
        public List<OgretmelerDB> TumOgretmenler(string userid, string userpass, string departman)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var list = (from item in db.Personellers
                                    join item1 in db.Ogretmenlers on item.PersonelId equals item1.PersonelID
                                    select new OgretmelerDB
                                    {
                                        AD=item1.Adi,
                                        SOYAD=item1.Soyadi,
                                        ID=item1.PersonelID,
                                        TC=item.TcNo
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
        public bool SinifSil(string userid, string userpass, string departman, int sinifid)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    using (AnaOkuluDBEntities db = new AnaOkuluDBEntities())
                    {
                        var item = db.Siniflars.FirstOrDefault(f => f.sinifId == sinifid);
                        if (item != null)
                        {
                            db.Siniflars.Remove(item);
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


        public bool DemirbasGunceller(string userid, string userpass, string departman,int demirbasid, string DemirbasAdi, string DemirbasTuru, string DemirbasCinsi, string DemirbasAdeti, string DemirbasBirimi, string AlindigiYer, string AlisTarihi, string GirisTutari, string AlisFaturaNo, string KdvOrani, string KdvTutari, string SatisYeri, string SatisTarihi, string SatisTutari, string SatisFaturaNo, string SatisKdvTutari, string SatisNedeni)
        {
            try
            {
                if (GirisKontrol(userid, userpass, departman))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(" update Demirbaslar set Adi='" + DemirbasAdi + "',Turu='" + DemirbasTuru + "',Cinsi='" + DemirbasCinsi + "',Adet='" + DemirbasAdeti + "',Birim='" + DemirbasBirimi + "',AlindigiYer='" + AlindigiYer + "',AlisTarihi='" + AlisTarihi + "',GirisTutari='" + GirisTutari + "',AlisFaturaNo='" + AlisFaturaNo + "',KdvOrani='" + KdvOrani + "',KdvTutari='" + KdvTutari + "',SatisYeri='" + SatisYeri + "',SatisTarihi='" + SatisTarihi + "',SatisTutari='" + SatisTutari + "',SatisFaturaNo='" + SatisFaturaNo + "',SatisKdvTutari='" + SatisKdvTutari + "',SatisNedeni='" + SatisNedeni + "' where DEMIRBASID='"+demirbasid+"'", conn))
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
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
    }
}
