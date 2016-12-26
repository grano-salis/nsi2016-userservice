using SSO.WCFService.DataContracts;
using SSO.WCFService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SSO.WCFService.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountManagement.svc or AccountManagement.svc.cs at the Solution Explorer and start debugging.
    public class AccountManagement : IAccountManagement
    {
        private AccountManagementServiceImplementation _mngr { get; set; }
        private IdentityServiceImplementation _identityMngr { get; set; }
        private SSOContext _db { get; set; }
        private WebOperationContext _ctx { get; set; }

        public AccountManagement()
        {
            _db = new SSOContext();
            _ctx = WebOperationContext.Current;
            _mngr = new AccountManagementServiceImplementation(_db);
            _identityMngr = new IdentityServiceImplementation(_db);
        }

        public ActionResult AddRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }

        public ActionResult RemoveRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }

        public ActionResult BanUser(string userId)
        {
            throw new NotImplementedException();
        }

        public ActionResult ChangePassword(ChangePasswordRequest pwModel)
        {
            try
            {
                if (!_identityMngr.IsAdmin())
                {
                    throw new SSOBaseException("Permission denied.", HttpStatusCode.Unauthorized);
                }
                return _mngr.ChangePassword(pwModel);
            }
            catch (SSOBaseException e)
            {
                _ctx.OutgoingResponse.StatusCode = e.StatusCode;
                return new ActionResult { Message = e.Message };
            }
            catch (Exception)
            {
                _ctx.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return new ActionResult { Message = "An error has occured while executing the change password action." };
            }
        }
    }
}
