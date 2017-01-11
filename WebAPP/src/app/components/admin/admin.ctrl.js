(function() {
  'use strict';

  angular
    .module('ea.admin')
    .controller('AdminCtrl', ctrl);

  /** @ngInject */
  function ctrl($state, accountService) {
    if(!accountService.isAdmin()){
        $state.go('home');
    }
  }

})();

(function() {
  'use strict';

  angular
    .module('ea.admin')
    .service('adminService', service);

  /** @ngInject */
  function service(serverName, $http) {
    
    this.createUser = function(model){
        return $http({
            url: serverName + "/BusinessLogic/Account.svc/json/register",
            method: "POST",
            withCredentials:true,
            data:model
        });
    };
    
    this.getRoles = function(){
        return $http({
            url: serverName + "/BusinessLogic/AccountManagement.svc/json/getRoles",
            method: "GET",
            withCredentials:true
        });
    };
    
    this.findUsers = function(username){
        return $http({
            url: serverName + "/BusinessLogic/AccountManagement.svc/json/getUsers?username=" + username,
            method: "GET",
            withCredentials:true
        });
    };
    
    this.addRoleToUser = function(model){
        return $http({
            url: serverName + "/BusinessLogic/AccountManagement.svc/json/AddUserToRole",
            method: "POST",
            withCredentials:true,
            data:model
        });
    };
    
    this.removeRoleFromUser = function(model){
        return $http({
            url: serverName + "/BusinessLogic/AccountManagement.svc/json/removeUserFromRole",
            method: "POST",
            withCredentials:true,
            data:model
        });
    };
  }

})();

