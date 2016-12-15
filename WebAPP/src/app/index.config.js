(function() {
  'use strict';

  angular
    .module('ea')
    .config(config);

  /** @ngInject */
  function config($logProvider, toastrConfig, $anchorScrollProvider, $locationProvider) {
    // Enable log
    $logProvider.debugEnabled(true);

    // Set options third-party lib
    toastrConfig.allowHtml = true;
    toastrConfig.timeOut = 3000;
    toastrConfig.positionClass = 'toast-top-right';
    toastrConfig.preventDuplicates = true;
    toastrConfig.progressBar = true;

    $locationProvider.html5Mode(true);
    //$anchorScrollProvider.disableAutoScrolling();
  }

})();
