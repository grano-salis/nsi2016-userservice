/* global moment:false*/
(function() {
  'use strict';

  angular
    .module('ea')
    .constant('moment', moment)
         //.constant('serverName', "http://do.mac.ba:8888");
		.constant('serverName', "http://localhost:48202");

})();
