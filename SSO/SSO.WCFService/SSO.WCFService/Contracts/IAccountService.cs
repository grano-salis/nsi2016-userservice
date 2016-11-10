using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.Contracts
{
    [ServiceContract]
    interface IAccountService
    {
        [OperationContract]
        Boolean Login();//Generate a new valid token for a user, TODO: change input and output parameters

        [OperationContract]
        Boolean Register();//Add new user, TODO: change input and output parameters

        [OperationContract]
        Boolean ChangePassword(); //TODO: change input and output parameters
    }
}
