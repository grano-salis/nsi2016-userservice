(function() {
  'use strict';

  angular
    .module('ea.account')
    .controller('ChangePasswordCtrl', ctrl);

  /** @ngInject */
  function ctrl($state, accountService, toastr, $scope) {
    
    $scope.model = {
        ID: 0,
        OldPassword: "",
        NewPassword: "",
        RPassword: ""
    }
    
    $scope.changePass = function(){
        if($scope.model.RPassword !==  $scope.model.NewPassword){
            toastr.error("Lozinke su razlicite.");
            return;
        }
        $scope.model.ID = accountService.getCurrentUser().user.id
        accountService.changePassword($scope.model).then(function(resp){
            toastr.success("Uspješno promijenjena lozinka");
            $state.go('profile');
        })
        .catch(function(resp){
            if(resp.data && resp.data.Message == "Wrong login credentials."){
                toastr.error("Pogrešna trenuta lozinka.");
            } else {
                toastr.error("Greška pri promjeni lozinke.");
            }           
        });
    }
  }

})();