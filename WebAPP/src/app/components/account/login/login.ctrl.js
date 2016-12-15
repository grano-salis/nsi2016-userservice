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

          if(response.data.username){
            if(response.data.username == "wrong"){
              $scope.errors.push($translate.instant('REG.USER_PASS_W'));
            }
            if(response.data.username == "required"){
              $scope.errors.push("Username is required.");
            }
          }
          if(response.data.password){
            if(response.data.username == "required"){
              $scope.errors.push("Username is required.");
            }
          }
          if(response.data.email){
            if(response.data.email == "not confirmed"){
              $scope.errors.push($translate.instant('REG.EMAIL_NOT_CONF'));
            }
          }
          if(response.data.banned){
            $scope.errors.push($translate.instant('REG.BAN'));
          }
          if($scope.errors.length > 0)
            toastr.error($scope.errors.join(' '), $translate.instant('REG.LOG_FAIL'));
          else
            toastr.error($translate.instant('REG.LOG_FAIL'));

      });

    };
  }

})();
