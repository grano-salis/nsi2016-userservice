(function() {
  'use strict';

  angular
    .module('ea.admin')
    .controller('AdminCtrl', ctrl);

  /** @ngInject */
  function ctrl() {
   
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
    }
  }

})();

