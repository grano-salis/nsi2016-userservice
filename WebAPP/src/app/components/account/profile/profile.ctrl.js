(function() {
  'use strict';

  angular
    .module('ea.account')
    .controller('ProfileCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $state, accountService, toastr) {

    $scope.user = accountService.getCurrentUser().user;

    activate();

    $scope.logout = function(){
      accountService.logout()
        .then(function(){
            toastr.success("Logout succeful.");
            $state.go('login');
        })
        .catch(function(resp){
            console.error(resp);
            
            toastr.error("Logout unsucceful.");
        });
    }


    function activate(){  }
  }

})();
