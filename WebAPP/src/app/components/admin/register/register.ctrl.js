(function() {
  'use strict';

  angular
    .module('ea.admin')
    .controller('RegisterCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $timeout, $state, $translate, toastr, adminService) {
    $scope.errors = [];
    //$scope.errors = ['Username already exists', 'Email already exists'];

    $scope.newUser = {
      Username:"",
      FirstName:"",
      LastName:"",
      Email:"",
      Password:"",
      ConfirmPassword:""
    }

    $scope.succefullRegistration = function(){
      toastr.success('Korisnik je uspješno kreiran.');
      angular.copy({
        Username:"",
        FirstName:"",
        LastName:"",
        Email:"",
        Password:"",
        ConfirmPassword:""
      }, $scope.newUser);
      
      $scope.rForm.$setPristine();
      $scope.rForm.$setUntouched();
      
    }

    $scope.errors = [];
    $scope.register = function(){

      angular.copy([], $scope.errors);

      if($scope.rForm.$invalid){

        toastr.error($translate.instant('REG.CHECK_FIELDS'), $translate.instant('REG.INVALID_FORM'));
        $scope.rForm.Username.$setTouched();
        $scope.rForm.FirstName.$setTouched();
        $scope.rForm.LastName.$setTouched();
        $scope.rForm.Email.$setTouched();
        $scope.rForm.Password.$setTouched();
        $scope.rForm.confirmPassword.$setTouched();

        return;
      }


      adminService.createUser($scope.newUser)
        .then(function(){
          // tek poslije ovog je mijenjano. ova success poruka, i hendlanje errora
          $scope.succefullRegistration();

        })
        .catch(function(response){
           
          switch(response.data.Message){
              case "username exists":
                $scope.errors.push('Korisničko ime već postoji.')
                break;
              case "email exists":
                $scope.errors.push('Email već postoji.')
                break;
              case "password weak":
                $scope.errors.push('Lozinka je preslaba. Minimalna dužina je 8. Mora imati najmanje jedno malo i jedno veliko slovo.');
                break;
              default:
                console.error('registracija - nesto cudno:', response);
          }
          
          toastr.error($translate.instant('REG.REG_ERR'));

      }); // end of .catch
    }; // end of scope.register
  }

})();
