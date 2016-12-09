using SSO.WCFService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSO.WCFService.ServiceInterfaces
{
    [ServiceContract]
    interface IIdentity
    {
        [OperationContract]
        void Logout();//Set claim property Valid to false, TODO: change input and output parameters

        [OperationContract] //used with parameter only when used by admin to get info about user with userId 
        [FaultContract(typeof(MyFault))]
        AuthResponse Auth(int? userId); //Get user claims if user has provided a valid token, TODO: change input and output parameters
    }
}
