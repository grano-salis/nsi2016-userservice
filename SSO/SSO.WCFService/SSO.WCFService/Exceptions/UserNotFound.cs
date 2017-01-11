using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SSO.WCFService.Exceptions
{
    public class UserNotFound : SSOBaseException
    {
            public UserNotFound(int userId) : base("User with specified id does not exist.", HttpStatusCode.NotFound)
            {
            }

            public UserNotFound(string userName) : base("User with specified username does not exist.", HttpStatusCode.NotFound)
            {
            }

            public UserNotFound(string userName, Exception innerException) : base("User with specified username does not exist.", innerException, HttpStatusCode.NotFound)
            {
            }

            public UserNotFound(int userId, Exception innerException) : base("User with specified id does not exist.", innerException, HttpStatusCode.NotFound)
            {
            }
        }
    }
