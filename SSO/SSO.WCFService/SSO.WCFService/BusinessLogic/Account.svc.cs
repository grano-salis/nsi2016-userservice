using SSO.WCFService.DataContracts;
using SSO.WCFService.Exceptions;
using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Account : IAccount
    {
        private AccountServiceImplementation _mngr { get; set; }
        private IdentityServiceImplementation _identityMngr { get; set; }
        private SSOContext _db { get; set; }
        private WebOperationContext _ctx { get; set; }

        public Account()
        {
            _db = new SSOContext();
            _ctx = WebOperationContext.Current;
            _mngr = new AccountServiceImplementation(_db);
            _identityMngr = new IdentityServiceImplementation(_db);
        }

        public ActionResult ChangePassword()
        {
            try
            {
                // TODO get auth user
                User user = null;
                return _mngr.ChangePassword(user);
            }
            catch (SSOBaseException e)
            {
                _ctx.OutgoingResponse.StatusCode = e.StatusCode;
                return new ActionResult { Message = e.Message };
            }
            catch (Exception)
            {
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new ActionResult { Message = "There has been an error while change password action." };
            }
        }

        public ActionResult Login(LoginRequest loginModel)
        {
            try
            {
               return _mngr.Login(loginModel, _ctx);
            }
            catch (SSOBaseException e)
            {
                _ctx.OutgoingResponse.StatusCode = e.StatusCode;
                return new ActionResult { Message = e.Message };
            }
            catch (Exception)
            {
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new ActionResult { Message = "There has been an error while login action." };
            }
        }

        public ActionResult Register(DataContracts.RegisterRequest registerModel)
        {
            try
            {
                return _mngr.Register(registerModel);
            }
            catch (SSOBaseException e)
            {
                _ctx.OutgoingResponse.StatusCode = e.StatusCode;
                return new ActionResult
                {
                    Message = e.Message
                };
            }

            catch (Exception)
            {
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new ActionResult { Message = "There has been an error while register action." };
            }
        }

        public AuthResponse Auth()
        {
            string token = _ctx.IncomingRequest.Headers[HttpRequestHeader.Cookie];
            var bl = 44;
            try
            {
                return _identityMngr.Auth(token);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception)
            {
                var myf = new MyFault { Details = "There has been an error in authorization process." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }

        }
    }
}