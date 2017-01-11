(function() {
  'use strict';

  angular
    .module('ea.admin')
    .controller('AdminManageUsersCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, adminService, toastr, $timeout) {
      $scope.showSpin = false;
      $scope.showSelectedUser = false;
      $scope.selectedUser = {}
      
      $scope.search = {
          string: ""
      }
      
      $scope.foundUsers = [];
      $scope.roles = []; 
      
      // Dohvatanje ruta
      (function fetchRoles(){
        adminService.getRoles().then(function(resp){
            angular.copy(resp.data, $scope.roles);
        }).catch(function(resp){
            $timeout(function(){
                fetchRoles();
            },3000);    
        });
      })();
      
      
      $scope.searchUsers = function(){
          $scope.showSelectedUser = false;
          // TODO search
          if($scope.search.string == ""){
              angular.copy([], $scope.foundUsers);
              return;
          }
          adminService.findUsers($scope.search.string).then(function(resp){
              angular.copy(resp.data.users, $scope.foundUsers);
          });
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
        if($scope.hasRole(role) < 0){
            adminService.addRoleToUser({
                roleName:role,
                userId:$scope.selectedUser.UserId
            }).then(function(resp){
                $scope.selectedUser.Roles.push(role);    
            });
        }
            
      }
      
      $scope.removeRole = function(role){
          
          // TODO call API
          var index = $scope.hasRole(role);
          if(index >= 0){
              adminService.removeRoleFromUser({
                    roleName:role,
                    userId:$scope.selectedUser.UserId
                }).then(function(resp){
                    $scope.selectedUser.Roles.splice(index, 1); 
                });
          }
            
      }
  }

})();
