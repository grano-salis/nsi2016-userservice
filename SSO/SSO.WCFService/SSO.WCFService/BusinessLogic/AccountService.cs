using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;
using System.Threading.Tasks;
using System.ServiceModel.Web;

namespace SSO.WCFService.BusinessLogic
{
    public class AccountService : IAccount
    {
        private SSOContext _db;

        public AccountService(SSOContext _db)
        {
            this._db = _db;
        }

        public ActionResult ChangePassword()
        {
            /*
               SSOContext _db = new SSOContext();
               UserLuka l = new UserLuka();
               l.NAME = "luka lol";

               _db.UserLukas.Add(l);
               _db.SaveChanges();
           */
            var myf = new MyFault { Details = "Not implemented, we are sorry, ho-ho-ho."};
            throw new WebFaultException<MyFault>(myf, System.Net.HttpStatusCode.NotImplemented);
        }

        public ActionResult Login(LoginRequest loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Register(RegisterRequest registerModel)
        {
            throw new NotImplementedException();
        }
    }
}