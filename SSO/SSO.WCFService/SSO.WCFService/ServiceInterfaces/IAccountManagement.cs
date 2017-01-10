using SSO.WCFService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.ServiceInterfaces
{
    [ServiceContract]
    public interface IAccountManagement
    {
        //these operations are authorized and only user with ADMIN role can execute them
        //TODO change inputs - make DATA contracts instead
        [OperationContract]
        [FaultContract(typeof(MyFault))]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ActionResult AddUserToRole(AddUserToRoleRequest req); //add new role to a user, TODO: change input and output parameters 

        [OperationContract]
        [FaultContract(typeof(MyFault))]
        ActionResult RemoveUserFromRole(RemoveUserFromRoleRequest req); //remove role from a user, TODO: change input and output parameters

        [OperationContract]
        [FaultContract(typeof(MyFault))]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ActionResult BanUser(BanUserRequest req); //TODO: change input and output parameters

        [OperationContract]
        [FaultContract(typeof(MyFault))]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        getUsersResponse getUsers(string username);

        [OperationContract]
        [FaultContract(typeof(MyFault))]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<string> getRoles();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(MyFault))]
        ActionResult ChangePassword(ChangePasswordRequest pwModel); //TODO: change input and output parameters

    }
}
