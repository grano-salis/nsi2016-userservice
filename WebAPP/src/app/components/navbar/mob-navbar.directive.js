(function() {
  'use strict';

  angular
    .module('ea')
    .directive('mobNavbar', directive);

  /** @ngInject */
  function directive() {
    var directive = {
      restrict: 'E',
      templateUrl: 'app/components/navbar/mob-navbar.html',
      scope: false,
      controller: NavbarController
    };

    return directive;

    /** @ngInject */
    function NavbarController($scope, $state) {

    }
  }

})();
