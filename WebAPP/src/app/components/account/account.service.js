(function(){
"use strict";

angular
  .module('ea.account')
  .service('accountService', accountService);

/** @ngInject */
function accountService($http, serverName, $q){

      var currentUser = { user: null };

      var service = this;
      
      this.login = function (loginModel) {

          var deferred = $q.defer();

          $http({
              url: serverName + '/BusinessLogic/Account.svc/json/login',
              method: "POST",
              data: {
                  loginModel: {
                      "Username": loginModel.username,
                      "Password": loginModel.password
                  }
              },
              withCredentials:true
          }).then(function (response) {
               
               service.auth().then(function(response){
                   deferred.resolve();
               })
               .catch(function(resp){
                   deferred.reject('auth');
               })
            
          }).catch(function (response) {
             if(response == 'auth')
                return deferred.reject(response);
                
             if(response.status == 400)
                return deferred.reject('wrong credentials');
             
             deferred.reject('login') 
          });

          return deferred.promise;
      };

      this.auth = function(){
          return $http.get(serverName + '/BusinessLogic/Account.svc/json/auth',{withCredentials:true})
          .then(function(response){
              var data = response.data;
              var user = {
                  username: data.Username,
                  name: data.FirstName + " " + data.LastName,
                  roles: data.Roles,
                  id: data.UserId,
                  email: data.Email
              }
              setCurrentUser({user: user});  
              
              console.log(response.data);
          })
          .catch(function(response){
              
              console.error(response.data)
          });
      }

      this.logout = function () {
          // TODO call api
          return $http({
              url: serverName + '/BusinessLogic/Account.svc/json/logout',
              method:"POST",
              withCredentials:true
          })
          .then(function(response){
              setCurrentUser({user: null});  
          });
      };
      
      this.changePassword = function(model){
          return $http({
              url: serverName + '/BusinessLogic/Account.svc/json/changepassword',
              method:"POST",
              withCredentials:true,
              data:model
          });
      }
      /*
      this.register = function (registerModel) {
          var deferred = $q.defer();

          $http({
              url: serverName + '/api/user/register',
              method: "POST",
              data: registerModel
          }).then(function (response) {
               deferred.resolve(response);
          },
          function (response) {
              localStorageService.set('authorizationData', { token: null, user: null });
              deferred.reject(response);
          });

          return deferred.promise;
      };*/
      
      this.getCurrentUser = function () {
         
          return currentUser;
      };
      this.isLoggedIn = function(){
          var c_user = this.getCurrentUser();

          return !!c_user && !!c_user.user;
      };
      this.isAdmin = function(){
        var user = this.getCurrentUser().user;
        if(!user)
            return false;
            
        for(var i in user.roles){
            if(user.roles[i] == 'ADMIN')
                return true;
        }
        
        return false;
      }
      var setCurrentUser = function (loginModel) {
          //currentUser.token = loginModel.token;
          currentUser.user = loginModel.user;
      };

  }
})();
