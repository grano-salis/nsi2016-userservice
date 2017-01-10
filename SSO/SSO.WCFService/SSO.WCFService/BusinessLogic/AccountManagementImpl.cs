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
        private CustomRoleProvider _roleProvider { get; set; }

        public AccountManagementImpl(SSOContext _db)
        {
            this._db = _db;
            _roleProvider = new CustomRoleProvider(_db);
        }

        public void AddUserToRole(int roleId, int userId)
        {
            _roleProvider.AddUsersToRoles(new int[1] { userId }, new int[1] { roleId });
        }

        public bool BanUser(string userId, bool ban)
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

        public void RemoveUserFromRole(int roleId, int userId)
        {
            _roleProvider.RemoveUsersFromRoles(new int[1] { userId }, new int[1] { roleId });
        }

        public getUsersResponse getUsers(string username)
        {
            List<UserInfoExtended> userInfos = _db.Users.Where(u => u.Username.Contains(username)).ToList().Select(u => new UserInfoExtended
            {
                UserId = u.ID,
                Username = u.Username,
                Info = u.UserInfo.FirstOrDefault(),
                Roles = _db.ManageRoles.Include("Role")
                                                    .Where(mr => mr.UserID == u.ID)
                                                    .Select(mr => mr.Role.Name).ToList()
            }).ToList();
            return new getUsersResponse {
                users = userInfos
            };
        }

        internal List<string> getRoles()
        {
            return _roleProvider.GetAllRoles().ToList();
        }
    }
}