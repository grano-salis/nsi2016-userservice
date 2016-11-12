using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{
    public class Account : IAccount
    {
        public bool ChangePassword()
        {
            throw new NotImplementedException();
        }

        public bool Login(DataContracts.LoginRequest loginModel)
        {
            throw new NotImplementedException();
        }

        public bool Register(DataContracts.RegisterRequest registerModel)
        {
            throw new NotImplementedException();
        }
    }
}