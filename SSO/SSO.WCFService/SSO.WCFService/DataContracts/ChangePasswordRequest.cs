using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class ChangePasswordRequest
    {
        [DataMember]
        public string newPassword;
        [DataMember]
        public int userId;
    }
}