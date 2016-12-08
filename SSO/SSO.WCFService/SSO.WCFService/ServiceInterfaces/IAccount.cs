using SSO.WCFService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.ServiceInterfaces
{
    [ServiceContract]
    interface IAccount
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        String Login(LoginRequest loginModel);//Generate a new valid token for a user, TODO: change input and output parameters

        [OperationContract]
        Task<Boolean> Register(RegisterRequest registerModel);//Add new user, TODO: change input and output parameters

        [OperationContract]
        Boolean ChangePassword(); //TODO: change input and output parameters
    }

}
