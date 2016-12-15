(function() {
  'use strict';

  angular
    .module('ea')
    .config(routerConfig);

  /** @ngInject */
  function routerConfig($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
        url: '/?email-confirm',
        params: {
          scrollTo: null
        },
        templateUrl: 'app/components/home/home.html',
        controller: 'HomeCtrl',
        onEnter: scrollTo
      })
      .state('about',{
          url: '/about',
          params: {
            scrollTo: null
          },
          templateUrl: 'app/components/home/about.html',
          controller: 'HomeCtrl',
          onEnter: scrollTo
      }
      )
      .state('contact',{
          url: '/contact',
          params: {
            scrollTo: null
          },
          templateUrl: 'app/components/home/contact.html',
          controller: 'HomeCtrl',
          onEnter: scrollTo
      }
      );

    $urlRouterProvider.otherwise('/');
  }

 /** @ngInject **/
  var scrollTo = function ($location, $stateParams, $timeout) {

    if($stateParams.scrollTo != null) {
      $timeout(function() {
        $location.hash($stateParams.scrollTo);
      }, 100);
    }
  };

})();
