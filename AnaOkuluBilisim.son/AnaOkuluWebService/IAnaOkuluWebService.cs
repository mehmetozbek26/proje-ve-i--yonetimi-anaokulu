using System;
using System.Collections.Generic;
using System.Data;
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

        //[OperationContract]
        //List<Yemekler> TumYemekler(string userid, string userpass, string departman);
    }

}
