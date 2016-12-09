using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;

namespace SSO.WCFService.BusinessLogic
{
    public class IdentityServiceImplementation
    {
        private SSOContext _db;
        public IdentityServiceImplementation(SSOContext db)
        {
            _db = db;
        }
        public AuthResponse Auth(HttpContext ctx, int? userId)
        {

            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}