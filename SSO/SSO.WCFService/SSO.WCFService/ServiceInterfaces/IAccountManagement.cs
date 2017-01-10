using SSO.WCFService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SSO.WCFService.ServiceInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountManagement" in both code and config file together.
    [ServiceContract]
    public interface IAccountManagement
    {
        [OperationContract]
        ActionResult AddRole(RoleModelRequest rModel); //add new role to a user, TODO: change input and output parameters 

        [OperationContract]
        ActionResult RemoveRole(RoleModelRequest rModel); //remove role from a user, TODO: change input and output parameters

        [OperationContract]
        ActionResult BanUser(string userId); //TODO: change input and output parameters

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ActionResult ChangePassword(ChangePasswordRequest pwModel);
    }
}
