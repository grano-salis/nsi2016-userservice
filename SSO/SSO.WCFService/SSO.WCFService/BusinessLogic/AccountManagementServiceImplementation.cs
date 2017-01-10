using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;
using System.Data.Entity;
using SSO.WCFService.Helpers;
using SSO.WCFService.Exceptions;

namespace SSO.WCFService.BusinessLogic
{
    public class AccountManagementServiceImplementation
    {
        private SSOContext _db;
        public AccountManagementServiceImplementation(SSOContext db)
        {
            _db = db;
        }

        public ActionResult ChangePassword(ChangePasswordRequest pwModel)
        {
            var selectedUser = _db.Users.SingleOrDefault(u => u.ID == pwModel.ID);
            if (selectedUser == null)
            {
                throw new SSOBaseException("User resource doesn't exist.", System.Net.HttpStatusCode.NoContent);
            }

            string freshSalt = CryptoHelper.generateSalt();
            selectedUser.Salt = freshSalt;
            selectedUser.Password = CryptoHelper.generateHash(freshSalt, pwModel.NewPassword);

            _db.SaveChanges();
            return new ActionResult { Message = "Password successfully changed." };
        }

    }
}