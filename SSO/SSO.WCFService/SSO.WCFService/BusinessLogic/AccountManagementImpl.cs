using SSO.WCFService.DataContracts;
using SSO.WCFService.Exceptions;
using SSO.WCFService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{
    public class AccountManagementImpl
    {
        private SSOContext _db;

        public AccountManagementImpl(SSOContext _db)
        {
            this._db = _db;
        }

        public bool AddRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }

        public bool BanUser(string userId)
        {
            throw new NotImplementedException();
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

        public bool RemoveRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}