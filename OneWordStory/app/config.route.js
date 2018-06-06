(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/home/home.html',
                    title: 'home',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-home"></i> Home'
                    }
                }
            }, {
                url: '/admin',
                config: {
                    title: 'admin',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
          }, {
            url: '/login',
            config: {
              title: 'login',
              templateUrl: 'app/login/login.html',
              settings: {
                nav: 2,
                content: '<i class="fa fa-login"></i> Login'
              }
            }
          }, {
            url: '/signup',
            config: {
              title: 'signup',
              templateUrl: 'app/signup/signup.html',
              settings: {
                nav: 0
              }
            }
          }
        ];
    }
})();
