using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class AuthResponse
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public List<String> RoleIds { get; set; }
        [DataMember]
        public String UserId { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Email { get; set; }
    }
}