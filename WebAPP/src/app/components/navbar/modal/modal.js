(function() {
  'use strict';

  angular
    .module('ea')
    .directive('homeModal', directive);

  /** @ngInject */
  function directive() {
    var directive = {
      restrict: 'E',
      templateUrl: 'app/components/navbar/modal/modal.tmpl.html',
      controller: ctrl,
      transclude: {
        title:"?homeModalTitle",
        body:"homeModalBody"
      },
      scope:{
        show:"="
      }
    };

    return directive;

    /** @ngInject */
    function ctrl($scope) {

      $scope.close = function(){
        $scope.show = false;
      }
    }
  }

})();
