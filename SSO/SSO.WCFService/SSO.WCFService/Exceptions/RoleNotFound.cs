using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SSO.WCFService.Exceptions
{
    public class RoleNotFound: SSOBaseException
    {

        public RoleNotFound(int roleId) : base("Role with specified id does not exist.", HttpStatusCode.NotFound)
        {
        }

        public RoleNotFound(string roleName) : base("Role with specified name does not exist.", HttpStatusCode.NotFound)
        {
        }

        public RoleNotFound(string roleName, Exception innerException) : base("Role with specified name does not exist.", innerException, HttpStatusCode.NotFound)
        {
        }

        public RoleNotFound(int roleId, Exception innerException) : base("Role with specified id does not exist.", innerException, HttpStatusCode.NotFound)
        {
        }
    }
}