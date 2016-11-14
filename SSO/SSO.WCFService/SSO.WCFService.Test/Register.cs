using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSO.WCFService.DataContracts;

namespace SSO.WCFService.Test
{
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void Register()
        {
            Account.AccountClient svc = new Account.AccountClient();
            //BusinessLogic.Account svc = new BusinessLogic.Account();
            DataContracts.RegisterRequest reg = new DataContracts.RegisterRequest();
            reg.FirstName = "Luka";
            reg.LastName = "Pejović";
            reg.Username = "Luka454";
            reg.Email = "pejovicluka454@gmail.com";
            reg.Password = "lukaJeZakon";

            Assert.IsTrue(svc.Register(reg));
            
            svc.Close();
        }
    }
}
