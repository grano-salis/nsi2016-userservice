using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SSO.WCFService.DataContracts;
using SSO.WCFService.Helpers;
using SSO.WCFService.Exceptions;
using System.Net;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountManagement.svc or AccountManagement.svc.cs at the Solution Explorer and start debugging.
    public class AccountManagement : IAccountManagement
    {
        private AccountManagementImpl _mngr { get; set; }
        private SSOContext _db { get; set; }
        private WebOperationContext _ctx { get; set; }

        private AuthProvider _authProvider { get; set; }

        public AccountManagement()
        {
            _db = new SSOContext();
            _ctx = WebOperationContext.Current;
            _mngr = new AccountManagementImpl(_db);
            _authProvider = new AuthProvider(_db);
        }


        public ActionResult AddUserToRole(AddUserToRoleRequest req)
        {
            try
            {
                string roleName = req.roleName;
                int userId = req.userId;

                var cookie = HttpContext.Current.Request.Cookies["sid"];
                if (cookie == null)
                {
                    throw new WrongOrExpiredToken();
                }

                string token = HttpContext.Current.Request.Cookies["sid"].Value;

                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new WrongOrExpiredToken();
                }

                UserInfoExtended info = _authProvider.AuthenticateByToken(token);
                if (!info.Roles.Contains("ADMIN"))
                    throw new UnauthorizedAccessException("User has to be admin to perform this action.");


                _mngr.AddUserToRole(roleName, userId);
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                return new ActionResult
                {
                    Message = "User is added to specified role."
                };
            }
            catch (UnauthorizedAccessException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.Unauthorized);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception e)
            {
                var myf = new MyFault { Details = "There has been an error while performing AddUserToRole action." };
                 throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult ChangePassword(ChangePasswordRequest pwModel)
        {
            try
            {

                var cookie = HttpContext.Current.Request.Cookies["sid"];
                if (cookie == null)
                {
                    throw new WrongOrExpiredToken();
                }

                string token = HttpContext.Current.Request.Cookies["sid"].Value;

                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new WrongOrExpiredToken();
                }

                UserInfoExtended info = _authProvider.AuthenticateByToken(token);
                if (!info.Roles.Contains("ADMIN"))
                    throw new UnauthorizedAccessException("User has to be admin to perform this action.");

                 _mngr.ChangePassword(pwModel);

                return new ActionResult
                {
                    Message = "Password changed."
                };
            }
            catch (UnauthorizedAccessException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.Unauthorized);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception)
            {
                var myf = new MyFault { Details = "There has been an error while changePassword action." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }


        public ActionResult RemoveUserFromRole(RemoveUserFromRoleRequest req)
        {
            try
            {
                string roleName = req.roleName;
                int userId = req.userId;

                var cookie = HttpContext.Current.Request.Cookies["sid"];
                if (cookie == null)
                {
                    throw new WrongOrExpiredToken();
                }

                string token = HttpContext.Current.Request.Cookies["sid"].Value;

                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new WrongOrExpiredToken();
                }

                UserInfoExtended info = _authProvider.AuthenticateByToken(token);
                if (!info.Roles.Contains("ADMIN"))
                    throw new UnauthorizedAccessException("User has to be admin to perform this action.");


                _mngr.RemoveUserFromRole(roleName, userId);
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                return new ActionResult
                {
                    Message = "User is removed from specified role."
                };
            }
            catch (UnauthorizedAccessException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.Unauthorized);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception e)
            {
                var myf = new MyFault { Details = "There has been an error while RemoveUserFromRole action." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult BanUser(BanUserRequest req)
        {
            int userId = req.userId;
            bool ban = req.ban;
            throw new NotImplementedException();
        }

        public getUsersResponse getUsers(string username)
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies["sid"];
                if (cookie == null)
                {
                    throw new WrongOrExpiredToken();
                }

                string token = HttpContext.Current.Request.Cookies["sid"].Value;

                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new WrongOrExpiredToken();
                }

                UserInfoExtended info = _authProvider.AuthenticateByToken(token);
                if (!info.Roles.Contains("ADMIN"))
                    throw new UnauthorizedAccessException("User has to be admin to perform this action.");

                return _mngr.getUsers(username);
            }
            catch (UnauthorizedAccessException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.Unauthorized);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception)
            {
                var myf = new MyFault { Details = "There has been an error while getUsers action." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }

        public List<string> getRoles()
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies["sid"];
                if (cookie == null)
                {
                    throw new WrongOrExpiredToken();
                }

                string token = HttpContext.Current.Request.Cookies["sid"].Value;

                if (String.IsNullOrWhiteSpace(token))
                {
                    throw new WrongOrExpiredToken();
                }

                UserInfoExtended info = _authProvider.AuthenticateByToken(token);
                if (!info.Roles.Contains("ADMIN"))
                    throw new UnauthorizedAccessException("User has to be admin to perform this action.");

                return _mngr.getRoles();
            }
            catch (UnauthorizedAccessException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.Unauthorized);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception)
            {
                var myf = new MyFault { Details = "There has been an error while getRoles action." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }

    }
}

