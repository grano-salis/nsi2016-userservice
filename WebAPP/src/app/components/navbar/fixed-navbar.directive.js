(function() {
  'use strict';

  angular
    .module('ea')
    .directive('fixedNavbar', directive);


  /** @ngInject */
  function directive() {
    var directive = {
      replace: true,
      restrict: 'E',
      templateUrl: 'app/components/navbar/fixed-navbar.html',
      scope: false,
      controller: NavbarController
    };

    return directive;
  }

  /** @ngInject */
  function NavbarController($scope, $state) {
    $scope.goHome = function(){
        $state.go('home');
    }
  }


})();
