(function() {
  'use strict';

  angular
    .module('ea.admin')
    .controller('AdminManageUsersCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope) {
      $scope.showSpin = false;
      $scope.showSelectedUser = false;
      $scope.selectedUser = {}
      
      var dummy = {
          Id:134,
          Username: "luka454",
          Email:"lpejovic1@etf.unsa.ba",
          FirstName: "Luka",
          LastName: "Pejović",
          Roles:['ADMIN']
      }
      
      $scope.roles = ['ADMIN', 'CV_ADMIN']; // TODO dohvatiti role
      
      $scope.foundUsers = [];
      $scope.foundUsers.push(dummy);
      $scope.foundUsers.push(dummy);
      $scope.foundUsers.push(dummy);
      
      $scope.searchUsers = function(){
          $scope.showSelectedUser = false;
          // TODO search
      }
      
      $scope.selectUser = function(user){
          angular.copy(user, $scope.selectedUser);
          $scope.showSelectedUser = true;
      }
      
      $scope.hasRole = function(role){
        
        for(var i in $scope.selectedUser.Roles){
            if($scope.selectedUser.Roles[i] == role)
                return i;
        }
        
        return -1;
      }
      
      $scope.addRole = function(role){
        //if(!$scope.showSelectedUsers) 
        //    return;
            
        // TODO call API
        if($scope.hasRole(role) < 0)
            $scope.selectedUser.Roles.push(role);
      }
      
      $scope.removeRole = function(role){
          
          // TODO call API
          var index = $scope.hasRole(role);
          if(index >= 0){
              $scope.selectedUser.Roles.splice(index, 1);
          }
            
      }
  }

})();
