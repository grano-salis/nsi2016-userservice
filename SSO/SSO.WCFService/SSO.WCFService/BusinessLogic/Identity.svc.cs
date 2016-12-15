﻿using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SSO.WCFService.DataContracts;
using System.ServiceModel.Web;
using SSO.WCFService.Exceptions;
using System.Net;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Identity" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Identity.svc or Identity.svc.cs at the Solution Explorer and start debugging.
    public class Identity : IIdentity
    {

        private IdentityServiceImplementation _mngr { get; set; }
        private SSOContext _db { get; set; }
        private WebOperationContext _ctx { get; set; }

        public Identity()
        {
            _db = new SSOContext();
            _ctx = WebOperationContext.Current;
            _mngr = new IdentityServiceImplementation(_db);
        }

        public AuthResponse Auth(int? userId)
        {
            try
            {
                return _mngr.Auth(HttpContext.Current, userId);
            }
            catch (SSOBaseException e)
            {
                var myf = new MyFault { Details = e.Message };
                throw new WebFaultException<MyFault>(myf, e.StatusCode);
            }
            catch (Exception)
            {
                var myf = new MyFault { Details = "There has been an error while change password action." };
                throw new WebFaultException<MyFault>(myf, HttpStatusCode.InternalServerError);
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}