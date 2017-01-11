(function() {
  'use strict';

  angular
    .module('ea.admin')
    .config(routerConfig);

  /** @ngInject */
  function routerConfig($stateProvider) {
    $stateProvider
      .state('admin', {
        url: '/admin',
        templateUrl: 'app/components/admin/admin.tmpl.html',
        controller: 'AdminCtrl'
      })
      .state('admin.panel', {
        url: '/dashboard',
        templateUrl: 'app/components/admin/panel/admin_panel.tmpl.html',
        controller: 'AdminPanelCtrl'
      })
      .state('admin.register', {
        url: '/register',
        templateUrl:     'app/components/admin/register/register.tmpl.html',
        controller: 'RegisterCtrl'
      })
      .state('admin.manage-users', {
        url: '/manage-users',
        templateUrl: 'app/components/admin/manage_users/manage_users.tmpl.html',
        controller: 'AdminManageUsersCtrl'
      });
  }

})();
