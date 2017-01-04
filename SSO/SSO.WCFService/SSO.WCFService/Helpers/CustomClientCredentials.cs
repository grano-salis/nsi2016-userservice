using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;

namespace SSO.WCFService.Helpers
{
    public class CustomClientCredentials : ClientCredentials
    {
        public CustomClientCredentials()
        {

        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return base.CreateSecurityTokenManager();
        }
    }
}