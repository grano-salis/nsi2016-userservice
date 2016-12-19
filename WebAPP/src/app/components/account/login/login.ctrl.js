(function() {
  'use strict';

  angular
    .module('ea.account')
    .controller('LoginCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $translate, $timeout, toastr, accountService, $state) {
    $scope.loginModel = {
      username: "",
      password: ""
    }

    $scope.errors = [];

    $scope.succefullLogin = function(){

      toastr.success($translate.instant('REG.LOGIN_SUC'));
      $timeout(function(){
        $state.go('home');
      },2000);
    }
    $scope.login = function(){

      angular.copy([], $scope.errors);

      if($scope.lForm.$invalid){

        toastr.error($translate.instant('REG.CHECK_FIELDS'), $translate.instant('REG.INVALID_FORM'));
        $scope.lForm.username.$setTouched();
        $scope.lForm.password.$setTouched();
        return;
      }

      $scope.showLoginSpin = true;
      accountService.login($scope.loginModel)
        .then(function(){

          $scope.succefullLogin();
        })
        .catch(function(response){
            if(response=='login'){
                toastr.error('Failed to login.');
            }
            else if(response == 'auth'){
                toastr.error('Please refresh page. Failed to fetch user data.');
            }
            else if(response == 'wrong credentials'){
                toastr.error("Wrong username or password.");
            }
      });

    };
  }

})();
