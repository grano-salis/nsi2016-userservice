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
                  loginModel: loginModel
              }
          }).then(function (response) {
               
               service.auth().then(function(response){
                   deferred.resolve();
               })
               .catch(function(resp){
                   deferred.reject();
               })
            
          }).catch(function (response) {
              
          });

          return deferred.promise;
      };

      this.auth = function(){
          return $http.get(serverName + '/BusinessLogic/Account.svc/json/auth')
          .then(function(response){
              var data = response.data.d;
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
          setCurrentUser({user:null});
      };
      
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

          return !!c_user && !!c_user.token;
      };
      this.isAdmin = function(){
        var user = this.getCurrentUser().user;
        
        return !(!user || !(user.role == 'admin'));
      }
      var setCurrentUser = function (loginModel) {
          //currentUser.token = loginModel.token;
          currentUser.user = loginModel.user;
      };

  }
})();
