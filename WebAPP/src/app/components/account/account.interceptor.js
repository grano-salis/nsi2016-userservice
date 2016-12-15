(function(){
  "use strict"
  angular
    .module('ea.account')
    .factory('authInterceptor', interceptor);

  /** @ngInject */
  function interceptor(localStorageService) {
    return {
      request: function (config) {
        config.headers = config.headers || {};
        var authData = localStorageService.get('authorizationData');
        if (authData && authData.token) {
            config.headers['x-access-token'] = authData.token;
        }
        return config;
      }
    };
  }

})();
