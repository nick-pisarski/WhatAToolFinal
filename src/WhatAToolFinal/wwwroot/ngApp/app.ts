namespace WhatAToolFinal {

    angular.module('WhatAToolFinal', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('main', {
                url: '/',
                templateUrl: '/ngApp/views/main.html',
                controller: WhatAToolFinal.Controllers.MainController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true
                }
            })
            .state('toolDetail', {
                url: '/tool/details/:id',
                templateUrl: '/ngApp/views/toolDetail.html',
                controller: WhatAToolFinal.Controllers.ToolDetailController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true
                }
            })
            .state('profileDetail', {
                url: '/profile/details/:id',
                templateUrl: '/ngApp/views/profile.html',
                controller: WhatAToolFinal.Controllers.ProfileDetailController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true
                }
            })
            .state('adminList', {
                url: '/admin/list',
                templateUrl: '/ngApp/views/adminList.html',
                controller: WhatAToolFinal.Controllers.AdminListController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true
                }
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: WhatAToolFinal.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: WhatAToolFinal.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: WhatAToolFinal.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('WhatAToolFinal').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('WhatAToolFinal').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    angular.module('WhatAToolFinal').run((
        $rootScope: ng.IRootScopeService,
        $state: ng.ui.IStateService,
        accountService: WhatAToolFinal.Services.AccountService
    ) => {
        $rootScope.$on('$stateChangeStart', (e, to) => {
            // protect non-public views
            if (to.data && to.data.requiresAuthentication) {
                if (!accountService.isLoggedIn()) {
                    e.preventDefault();
                    $state.go('login');
                }
            }
        });
    });

}
