(function(){
"use strict";

angular
  .module('ea')
  .service('homeService', service);

/** @ngInject */
function service($http, serverName){

      this.sendContactUs = function(contactUsModel){
        return $http({
          url:serverName + '/api/home/contact-us',
          method:'POST',
          data:contactUsModel
        })
      }

      // Subscribe on Newsletter
      this.subscribeOnNewsletter = function(subscribeModel){
        return $http({
          url:serverName + '/api/home/subscribe',
          method:'POST',
          data:subscribeModel
        })
      }
  }
})();
