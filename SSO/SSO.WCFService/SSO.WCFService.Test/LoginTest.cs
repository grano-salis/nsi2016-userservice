using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SSO.WCFService.Test
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Login()
        {
            Account.AccountClient svc = new Account.AccountClient();
            //BusinessLogic.Account svc = new BusinessLogic.Account();
            DataContracts.LoginRequest reg = new DataContracts.LoginRequest();
            reg.Username = "Luka4542";
            reg.Password = "lukaJeZakon";

            Assert.IsNotNull(svc.Login(reg));

            svc.Close();
        }
    }
}
