using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.ServiceInterfaces
{
    [ServiceContract]
    interface IIdentity
    {
        [OperationContract]
        Boolean Logout();//Set claim property Valid to false, TODO: change input and output parameters

        [OperationContract]
        Boolean Auth(); //Get user claims if user has provided a valid token, TODO: change input and output parameters
    }
}
