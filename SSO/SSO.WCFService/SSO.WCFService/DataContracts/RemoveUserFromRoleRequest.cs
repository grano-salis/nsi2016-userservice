﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class RemoveUserFromRoleRequest
    {
        [DataMember]
        public string roleName;
        [DataMember]
        public int userId;
    }
}