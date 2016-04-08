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
                templateUrl: '/ngApp/main.html',
                controller: WhatAToolFinal.Controllers.MainController,
                controllerAs: 'controller'
            })
            .state('toolDetail', {
                url: '/tool/details/:id',
                templateUrl: '/ngApp/toolDetail.html',
                controller: WhatAToolFinal.Controllers.ToolDetailController,
                controllerAs: 'controller'
            })
            .state('profileDetail', {
                url: '/profile/details/:id',
                templateUrl: '/ngApp/profile.html',
                controller: WhatAToolFinal.Controllers.ProfileDetailController,
                controllerAs: 'controller'
            })
            .state('adminList', {
                url: '/admin/list',
                templateUrl: '/ngApp/adminList.html',
                controller: WhatAToolFinal.Controllers.AdminListController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: WhatAToolFinal.Controllers.SecretController,
                controllerAs: 'controller'
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

    

}
