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
        private SSOContext _db { get; set; }
        private WebOperationContext _ctx { get; set; }

        public Account()
        {
            _db = new SSOContext();
            _ctx = WebOperationContext.Current;
            _mngr = new AccountServiceImplementation(_db);

        }

        public ActionResult ChangePassword()
        {
            try
            {
                return _mngr.ChangePassword();
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
               return _mngr.Login(loginModel, HttpContext.Current);
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

       
    }
}