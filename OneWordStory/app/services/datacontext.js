(function () {
  'use strict';

  var serviceId = 'datacontext';
  angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

  function datacontext(common, $http) {
    var $q = common.$q;

    var service = {
      createUser: createUser,
      loginUser: loginUser
    };

    return service;

    function createUser(user) {
      $http.post("api/create-user/", user)
        .then(function (response) {
          if (!response.data) {
            window.location == '/home';
          } else {
            localStorage.setItem('userId', response.data.UserId.toString())
            localStorage.setItem('full-name', response.data.FirstName.toString() + ' ' + response.data.LastName.toString());
            localStorage.setItem('user-token', response.data.Token.toString());
            return $q.when(response.date);
          }
        }, function myError(response) {
          return $q.when(null);
        });
    }

    function loginUser(user) {
      $http.post("api/login-user/", user)
        .then(function (response) {
          if (!response.data) {
            window.location == '/home';
          } else {
            localStorage.setItem('userId', response.data.UserId.toString())
            localStorage.setItem('full-name', response.data.FirstName.toString() + ' ' + response.data.LastName.toString());
            localStorage.setItem('user-token', response.data.Token.toString());
            return $q.when(response.date);
          }
        }, function myError(response) {
          return $q.when(null);
        });
    }
  }
})();
