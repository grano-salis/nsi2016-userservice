(function() {
  'use strict';

  angular
    .module('ea')
    .run(runBlock);

  /** @ngInject */
  function runBlock($log, accountService) {
    accountService.auth();
    
  }

})();
