﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSO.WCFService.Test.Account {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Account.IAccount")]
    public interface IAccount {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/Login", ReplyAction="http://tempuri.org/IAccount/LoginResponse")]
        bool Login(SSO.WCFService.DataContracts.LoginRequest loginModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/Login", ReplyAction="http://tempuri.org/IAccount/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(SSO.WCFService.DataContracts.LoginRequest loginModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/Register", ReplyAction="http://tempuri.org/IAccount/RegisterResponse")]
        bool Register(SSO.WCFService.DataContracts.RegisterRequest registerModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/Register", ReplyAction="http://tempuri.org/IAccount/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(SSO.WCFService.DataContracts.RegisterRequest registerModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/ChangePassword", ReplyAction="http://tempuri.org/IAccount/ChangePasswordResponse")]
        bool ChangePassword();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccount/ChangePassword", ReplyAction="http://tempuri.org/IAccount/ChangePasswordResponse")]
        System.Threading.Tasks.Task<bool> ChangePasswordAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountChannel : SSO.WCFService.Test.Account.IAccount, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountClient : System.ServiceModel.ClientBase<SSO.WCFService.Test.Account.IAccount>, SSO.WCFService.Test.Account.IAccount {
        
        public AccountClient() {
        }
        
        public AccountClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(SSO.WCFService.DataContracts.LoginRequest loginModel) {
            return base.Channel.Login(loginModel);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(SSO.WCFService.DataContracts.LoginRequest loginModel) {
            return base.Channel.LoginAsync(loginModel);
        }
        
        public bool Register(SSO.WCFService.DataContracts.RegisterRequest registerModel) {
            return base.Channel.Register(registerModel);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(SSO.WCFService.DataContracts.RegisterRequest registerModel) {
            return base.Channel.RegisterAsync(registerModel);
        }
        
        public bool ChangePassword() {
            return base.Channel.ChangePassword();
        }
        
        public System.Threading.Tasks.Task<bool> ChangePasswordAsync() {
            return base.Channel.ChangePasswordAsync();
        }
    }
}
