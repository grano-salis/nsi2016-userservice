(function() {
  'use strict';

  angular
    .module('ea.account')
    .config(routerConfig);

  /** @ngInject */
  function routerConfig($stateProvider, $httpProvider) {
    $stateProvider
      .state('login', {
        url: '/login',
        templateUrl: 'app/components/account/login/login.tmpl.html',
        controller: 'LoginCtrl'
      })
      /*.state('register', {
        url: '/register',
        templateUrl: 'app/components/account/register/register.tmpl.html',
        controller: 'RegisterCtrl'
      })*/
      .state('profile',{
        url:'/me',
        templateUrl: 'app/components/account/profile/profile.tmpl.html',
        controller: 'ProfileCtrl'
      });

      $httpProvider.interceptors.push('authInterceptor');
      $httpProvider.defaults.headers.post['Content-Type'] = 'application/json';

  }

})();
