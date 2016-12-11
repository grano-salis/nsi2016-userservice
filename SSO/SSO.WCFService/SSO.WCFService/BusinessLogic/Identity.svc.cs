using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SSO.WCFService.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Identity" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Identity.svc or Identity.svc.cs at the Solution Explorer and start debugging.
    public class Identity : IIdentity
    {
        public bool Auth(string token)
        {
            SSOContext _db = new SSOContext();
            var claim = _db.Claims.SingleOrDefault(c => c.Valid.Equals("1") && c.Token.Equals(token));
            if(claim == null)
            {
                // or return false
                throw new Exceptions.WrongCredentialsException();
            }

            return true;

            throw new NotImplementedException();
        }

        public bool Logout(string token)
        {
            throw new NotImplementedException();
        }
    }
}
