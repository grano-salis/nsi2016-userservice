(function() {
  'use strict';

  angular
    .module('ea')
    .directive('eaNavbar', directive);

  /** @ngInject */
  function directive() {
    var directive = {
      restrict: 'E',
      templateUrl: 'app/components/navbar/navbar.html',
      scope: {
      },
      controller: ctrl
    };

    return directive;
  }


  /** @ngInject */
  function ctrl($scope, $window, $document, accountService, $translate) {

    var navbar;

    activate();

    function scrollEvent(){
      calcShowingFixedNabvar($window.scrollY);
    }

    $scope.isLoggedIn = function(){
      return accountService.isLoggedIn();
    }

    $scope.getCurrentUser = function(){
      return accountService.getCurrentUser().user;
    }

    $scope.getLanguage = function(){
      return $translate.use();
    }

    $scope.setLanguage = function(lang){
      return $translate.use(lang);
    }

    function activate() {
      $scope.showNavbarFixed = false;
      // Dohvatamo 'veliki' navbar. Treba nam pri racunanju treba li prikazati navbar-fixed
      navbar = angular.element($document[0].getElementById('a-navbar'));

      $scope.$watch(function(){
        return $window.scrollY;
      }, scrollEvent);
      var applyCSFN = function(){
        $scope.$apply(function(){
          calcShowingFixedNabvar($window.scrollY);
        });
      };
      var $win = angular.element($window);

      $win.on('scroll', applyCSFN);
      $win.on('resize', applyCSFN);
      calcShowingFixedNabvar();

      $scope.$on('$destroy', function(){ // Memory leak sprecavamo, jer inace ostane bindano
        $win.unbind('scroll', applyCSFN);
        $win.unbind('resize', applyCSFN);
      });

    }

    function calcShowingFixedNabvar(newWindowOffset){
      var debounce = 50;
      var navbarEnd = navbar.prop('offsetTop') + navbar.prop('offsetHeight');
      return $scope.showNavbarFixed = newWindowOffset >= navbarEnd - debounce;
    }

  }


})();
