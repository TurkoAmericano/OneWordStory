(function () {
  'use strict';

  // Define the common module 
  // Contains services:
  //  - common
  //  - logger
  //  - spinner
  var commonModule = angular.module('auth', []);

  
  commonModule.factory('auth',
    [auth]);

  function auth() {

    
    var service = {
      // common angular dependencies
      getUser: getUser
    };

    return service;

    function getToken() {
      var token = localStorage.getItem('user-token');

      if (token) {

      }

    }

    

      // create the filtering function we will call from here
    
    
  }
})();
