using SSO.WCFService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class getUsersResponse
    {
        [DataMember]
        public List<UserInfoVM> users;
    }
}