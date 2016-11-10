using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SSO.WCFService.Contracts
{
    [ServiceContract]
    interface IAccountService
    {
        [OperationContract]
        Boolean Login(LoginModel loginModel);//Generate a new valid token for a user, TODO: change input and output parameters

        [OperationContract]
        Boolean Register(RegisterModel registerModel);//Add new user, TODO: change input and output parameters

        [OperationContract]
        Boolean ChangePassword(); //TODO: change input and output parameters
    }

    [DataContract]
    public class RegisterModel
    {
        [DataMember]
        public string Username { get; set; } //TODO: should this be automatically generated or.. ?

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

    }

    [DataContract]
    public class LoginModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
}
