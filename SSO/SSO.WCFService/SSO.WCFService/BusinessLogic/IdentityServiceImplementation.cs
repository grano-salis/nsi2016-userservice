using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;
using System.Data.Entity;

namespace SSO.WCFService.BusinessLogic
{
    public class IdentityServiceImplementation
    {
        private SSOContext _db;
        public IdentityServiceImplementation(SSOContext db)
        {
            _db = db;
        }
        public AuthResponse Auth(string token)
        {
            var claim = _db.Claims
                .SingleOrDefault(c => c.Valid.Equals("1") && c.Token.Equals(token));
            if (claim == null)
            {
                // or return false
                throw new Exceptions.WrongOrExpiredToken();
            }

            // Check expiration
            var timeSpan = DateTime.Now.Subtract(claim.Created);
            if(timeSpan.TotalSeconds > 60 * 60 * 24) // 24h
            {
                claim.Valid = "0";
                _db.SaveChanges();
                throw new Exceptions.WrongOrExpiredToken();
            }


            var user = _db.Users.Where(u => u.ID == claim.UserID).ToList()
                                    .Select(u => new {
                                        UserId = u.ID,
                                        Username = u.Username,
                                        Info = _db.UserInfoes.FirstOrDefault(i => i.UserID == u.ID),
                                        Roles = _db.ManageRoles.Include(mr => mr.Role)
                                                    .Where(mr => mr.UserID == u.ID)
                                                    .Select(mr => mr.Role.Name)
                                    }).FirstOrDefault();
            /*_db.ManageRoles.Include(mr => mr.Role)
                                                    .Where(mr => mr.UserID == u.ID)
                                                    .Select(mr => mr.Role.Name)*/
            if(user == null)
            {
                throw new Exception("This shouldn happen.");
            }

            AuthResponse response = new AuthResponse()
            {
                UserId = user.UserId,
                Username = user.Username,
                FirstName = user.Info.FirstName,
                LastName = user.Info.LastName,
                Email = user.Info.Email,
                Roles = user.Roles.ToList()
            };

            return response;
        }

        public void Logout(string token)
        {
            var claim = _db.Claims
                .SingleOrDefault(c => c.Valid.Equals("1") && c.Token.Equals(token));
            if (claim != null)
            {
                claim.Valid = "0";
                _db.SaveChanges();
            }
        }
    }
}