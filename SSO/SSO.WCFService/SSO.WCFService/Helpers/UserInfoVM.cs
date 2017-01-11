using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.Helpers
{
    [DataContract]
    public class UserInfoVM
    {
        [DataMember]
        public int UserId;
        [DataMember]
        public string Username;
        [DataMember]
        public string Email;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;
        [DataMember]
        public List<string> Roles;
    }
}