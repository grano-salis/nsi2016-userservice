using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SSO.WCFService.Helpers
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        string id = Guid.NewGuid().ToString();

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public ClaimSet Issuer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            /*
            // get the authenticated client identity
            var _db = new SSOContext();
            var token = HttpContext.Current.Request.Cookies["sid"];

            //Auth code
            var claim = _db.Claims
                .SingleOrDefault(c => c.Valid.Equals("1") && c.Token.Equals(token));
            if (claim == null)
            {
                // or return false
                throw new Exceptions.WrongOrExpiredToken();
            }

            // Check expiration
            var timeSpan = DateTime.Now.Subtract(claim.Created);
            if (timeSpan.TotalSeconds > 60 * 60 * 24) // 24h
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
                                        Roles = _db.ManageRoles.Include("Role")
                                                    .Where(mr => mr.UserID == u.ID)
                                                    .Select(mr => mr.Role.Name)
                                    }).FirstOrDefault();
            
            if (user == null)
            {
                throw new Exception("This shouldn't happen.");
            }

            IIdentity client = new CustomIdentity { Name = user.Username,  Id = user.UserId };

            // set the custom principal
            evaluationContext.Properties["Principal"] = new CustomPrincipal(client);
            */
            return true;
        }
    }
}