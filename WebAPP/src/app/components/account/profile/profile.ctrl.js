(function() {
  'use strict';

  angular
    .module('ea.account')
    .controller('ProfileCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $state, accountService, orderService) {

    $scope.user = accountService.getCurrentUser().user;
    $scope.orders = [];

    activate();

    $scope.logout = function(){
      accountService.logout();
      $state.go('login');
    }

    $scope.getStatus = function(order){
      return orderService.getStatus(order.status);
    }

    $scope.getTotal = function(order){
      if(order.total){
        return order.total;
      }
      var total = 0.0;
      angular.forEach(order.items, function(item){
        total += item.product_price;
      });
      return total;
    }

    function activate(){
      orderService.getByUser($scope.user.id)
        .then(function(resp){
          angular.copy(resp.data, $scope.orders);
        })
    }
  }

})();
