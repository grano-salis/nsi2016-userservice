using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class RegisterRequest
    {
        [DataMember]
        public string Username { get; set; } //TODO: should this be automatically generated or.. ?

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
}