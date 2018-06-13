(function () {
  'use strict';

  var serviceId = 'auth';
  angular.module('app').factory(serviceId, ['common', '$location', '$http', auth]);

  function auth(common, $location, $http) {
    var $q = common.$q;

    var service = {
      getUser: getUser,
    };

    return service;

    function getUser() {
      if (localStorage.getItem('user-token') === null) {
        $location.path('/login');
        return $q.when(null);
      }

      var token = localStorage.getItem('user-token');

      if (token) {
        return $http.get("api/get-user-by-token/" + token)
          .then(function (response) {
            if (!response.data) {
              window.location == '/login';
            } else {
              localStorage.setItem('userId', response.data.UserId.toString())
              localStorage.setItem('full-name', response.data.FirstName.toString() + ' ' + response.data.LastName.toString());
            }
          }, function myError(response) {
            return $q.when(null);
          });
      } else {
        return $q.when(null);
      }

      return $q.when(null);
    }


    
  }
})();
