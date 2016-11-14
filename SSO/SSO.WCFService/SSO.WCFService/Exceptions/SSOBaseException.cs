using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.Exceptions
{
    public class SSOBaseException : Exception
    {
        public SSOBaseException()
        {
        }

        public SSOBaseException(string message) : base(message)
        {
        }

        public SSOBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
