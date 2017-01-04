using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;

namespace SSO.WCFService.Helpers
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private CustomRoleProvider _roleProvider;
        
        public CustomPrincipal(IIdentity client)
        {
            _identity = client;
        }

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return _roleProvider.IsUserInRole(_identity.Name, role);
        }
    }
}