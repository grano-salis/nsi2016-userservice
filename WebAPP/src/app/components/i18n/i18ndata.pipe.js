(function() {
  'use strict';

  angular
    .module('ea')
    .filter('i18ndata',pipe);

  /** @ngInject */
  function pipe($translate) {
    return function(input){
      return input[$translate.use()];
    }
  }
})();
