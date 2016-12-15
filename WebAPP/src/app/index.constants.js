/* global moment:false*/
(function() {
  'use strict';

  angular
    .module('ea')
    .constant('moment', moment)
		.constant('serverName', "http://localhost:48202");

})();
