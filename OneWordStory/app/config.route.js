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
          requireLogin: '',
          title: 'home',
          settings: {
            nav: 0,
            content: '<i class="fa fa-home"></i> Home'
          }
        }
      }, {
        url: '/login',
        config: {
          title: 'login',
          templateUrl: 'app/login/login.html',
          requireLogin: 'NOT_LOGIN',
          settings: {
            nav: 1,
            content: '<i class="fa fa-login"></i> Login'
          }
        }
      }, {
        url: '',
        config: {
          title: '',
          templateUrl: '',
          requireLogin: 'LOGIN',
          settings: {
            nav: 2,
            content: '<i class="fa fa-login"></i> Welcome ' + localStorage.getItem('full-name')
          }
        }
      }, {
        url: '/make-new-story',
        config: {
          title: 'Make a New Story',
          templateUrl: 'app/create-story/create-story.html',
          requireLogin: 'LOGIN',
          settings: {
            nav: 3,
            content: '<i class="fa fa-new"></i> Make a New Story'
          }
        }
      }, {
        url: '/signup',
        config: {
          title: 'signup',
          templateUrl: 'app/signup/signup.html',
          requireLogin: false,
          settings: {
            nav: 0
          }
        }
      }
    ];
  }
})();
