using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;
using System.Data.Entity;
using SSO.WCFService.Helpers;

namespace SSO.WCFService.BusinessLogic
{
    public class IdentityServiceImplementation
    {
        private SSOContext _db;
        //something
        private AuthProvider _authProvider;
        public IdentityServiceImplementation(SSOContext db)
        {
            _db = db;
            _authProvider = new AuthProvider(_db);
        }

        protected internal bool IsSessionValid(string sid)
        {
            List<int> r = _db.Claims.Where(c => c.Token.Equals(sid))
                .Where(c => c.Valid == "1")
                .Select(c => c.ID)
                .ToList();
            return r.Count > 0;
        }

        protected internal bool IsCurrentSessionValid()
        {
            HttpCookie sid = HttpContext.Current.Request.Cookies.Get("sid");
            if (sid == null)
            {
                return false;
            }
            return IsSessionValid(sid.Value);
        }

        protected internal bool IsAdmin()
        {
            if (IsCurrentSessionValid())
            {
                HttpCookie sid = HttpContext.Current.Request.Cookies.Get("sid");
                AuthResponse currentUser = Auth(sid.Value);
                return currentUser.Roles.Contains("ADMIN");
            }
            return false;
        }

        public AuthResponse Auth(string token)
        {
            var user = _authProvider.AuthenticateByToken(token);
            if (user == null)
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