using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    public class RoleModelRequest
    {
        [DataMember(IsRequired = true)]
        public Int32 roleId { get; set; }

        [DataMember(IsRequired = true)]
        public string userId { get; set; }
    }
}