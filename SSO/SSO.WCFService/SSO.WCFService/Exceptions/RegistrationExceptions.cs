using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SSO.WCFService.Exceptions
{
    public class UsernameExistsException : SSOBaseException
    {

        public UsernameExistsException() : base("username exists", HttpStatusCode.BadRequest)
        {
        }

        public UsernameExistsException(Exception innerException) : base("username exists", innerException, HttpStatusCode.BadRequest)
        {
        }
    }

    public class EmailExistsException : SSOBaseException
    {

        public EmailExistsException() : base("email exists", HttpStatusCode.BadRequest)
        {
        }

        public EmailExistsException(Exception innerException) : base("email exists", innerException, HttpStatusCode.BadRequest)
        {
        }
    }

    public class WeakPasswordException : SSOBaseException
    {
        static private string _errorMessage = "password weak";
        public WeakPasswordException() : base(_errorMessage, HttpStatusCode.BadRequest)
        {
        }

        public WeakPasswordException(Exception innerException) : base(_errorMessage, innerException, HttpStatusCode.BadRequest)
        {
        }
    }
}