(function() {
  'use strict';

  angular
    .module('ea')
    .directive('eaFooter', directive);


  /** @ngInject */
  function directive() {
    var directive = {
      replace: true,
      restrict: 'E',
      templateUrl: 'app/components/navbar/footer.tmpl.html',
      scope: {
      },
      controller: ctrl
    };

    return directive;
  }

  /** @ngInject */
  function ctrl() {

  }


})();
