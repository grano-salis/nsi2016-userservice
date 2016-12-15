(function() {
  'use strict';

  angular
    .module('ea.account')
    .controller('RegisterCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $timeout, $translate, toastr, accountService) {
    $scope.errors = [];
    //$scope.errors = ['Username already exists', 'Email already exists'];

    $scope.newUser = {
      username:"",
      email:"",
      password:"",
      confirmPassword:""
    }

    $scope.succefullRegistration = function(){
      toastr.success($translate.instant('REG.MAIL_SENT'),$translate.instant('REG.REG_SUCCESSFUL'));
    }

    $scope.errors = [];
    $scope.register = function(){

      angular.copy([], $scope.errors);

      if($scope.rForm.$invalid){

        toastr.error($translate.instant('REG.CHECK_FIELDS'), $translate.instant('REG.INVALID_FORM'));
        $scope.rForm.username.$setTouched();
        $scope.rForm.email.$setTouched();
        $scope.rForm.password.$setTouched();
        $scope.rForm.confirmPassword.$setTouched();

        return;
      }


      accountService.register($scope.newUser)
        .then(function(){
          // tek poslije ovog je mijenjano. ova success poruka, i hendlanje errora
          $scope.succefullRegistration();

        })
        .catch(function(response){

          if(response.data.username){
            switch (response.data.username) {
              case "exists":
                $scope.errors.push($translate.instant('REG.USERNAME_EXISTS'));
                break;
              case "minlength":
                $scope.errors.push($translate.instant('REG.USERNAME_SHORT'));
                break;
            }

          }
          if(response.data.email){
            switch (response.data.email) {
              case "exists":
                $scope.errors.push($translate.instant('REG.EMAIL_EXISTS'));
                break;

              case "not valid":
                $scope.errors.push($translate.instant('REG.EMAIL_NOT_WALID'));
                break;
            }
          }

          if(response.data.password){
            switch (response.data.password) {
              case "required":
                $scope.errors.push($translate.instant('REG.PASS_REQ'));
                break;

              case "weak":
                $scope.errors.push($translate.instant('REG.PASS_WEAK'));
                break;
            }
          }

          if(response.data.body){ // ajv validation errors

            angular.forEach(response.data.body, function(value){
              switch (value.dataPath){
                case ".password":
                  if(value.keyword == "type"){
                    $scope.errors.push("Password must be string.");
                  }
                  if(value.keyword == "checkPassword"){
                    $scope.errors.push($translate.instant('REG.PASS_WEAK'));
                  }
                  break;
                case ".username":
                  if(value.keyword == "type"){
                    $scope.errors.push("Username must be string.");
                  }
                  if(value.keyword == "minLength"){
                    $scope.errors.push($translate.instant('REG.USERNAME_SHORT'));
                  }
                  if(value.keyword == "maxLength"){
                    $scope.errors.push($translate.instant('REG.USERNAME_LONG'));
                  }
                  break;
                case ".email":
                  if(value.keyword == "type"){
                    $scope.errors.push("Email must be string.");
                  }
                  if(value.keyword == "format"){
                    $scope.errors.push($translate.instant('REG.EMAIL_NOT_WALID'));
                  }
                  break;
              } // end of switch
            }); // end of .forEach
          }
          toastr.error($translate.instant('REG.REG_ERR'));

      }); // end of .catch
    }; // end of scope.register
  }

})();
