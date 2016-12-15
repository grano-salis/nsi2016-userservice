(function() {
  'use strict';

  angular
    .module('ea')
    .controller('HomeCtrl', ctrl);

  /** @ngInject */
  function ctrl($scope, $translate, $timeout, toastr, $location, $document,
                $window, homeService, accountService, $state, $stateParams, smoothScroll, NgMap) {

   
    $scope.isLoggedIn = isLoggedIn;
    $scope.getCurrentUser = getCurrentUser;
    var smoothScrollOptions = { // look https://github.com/d-oliveros/ngSmoothScroll for more
      duration:500,
      easing:'easeInQuad',
      offset:49 // 1 less then navbar debounce
    }

    activate();


    function activate() {
      var $win = angular.element($window);

      //$win.on('hashchange', onHashChange);
      $scope.$on('$destroy', function(){ // Memory leak sprecavamo, jer inace ostane bindano
        $win.unbind('hashchange', onHashChange);
      });
    }

    function onHashChange(){
        var newHash = $location.hash();

        if(newHash == "totop") { // navbar is on top, scroll to it and remove hash
          var elem = $document[0].getElementById('a-navbar');
          if(!elem){ // if there is no element return
            return;
          }
          smoothScroll(elem, smoothScrollOptions);

          $location.hash(null);
        } else {
          // we add prefix 'a-' on element to workaround autoscrolling problem on hash change
          var elem = $document[0].getElementById('a-' + newHash);
          if(!elem){ // if there is no element return
            return;
          }
          smoothScroll(elem, smoothScrollOptions);
        }
    }


    function isLoggedIn(){
      return accountService.isLoggedIn();
    }

    function getCurrentUser(){
      return accountService.getCurrentUser().user;
    }


  }

})();
