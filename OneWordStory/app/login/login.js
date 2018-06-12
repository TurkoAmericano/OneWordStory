(function () {
  'use strict';
  var controllerId = 'login';
  angular.module('app').controller(controllerId, ['common', '$location', 'datacontext', login]);

  function login(common, $location, datacontext) {
    
    var vm = this;

    vm.login = login;
    vm.user = {};

    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }

    function login() {

      if (validate()) {
        datacontext.loginUser(vm.user).then(function () {
          $location.path('/home');
        });
      }

    }

    function validate() {
      vm.errors = [];
      if (!vm.user.Email) {
        vm.errors.push("Email is required");
      }

      var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      if (!re.test(String(vm.user.Email).toLowerCase()) && vm.user.Email) {
        vm.errors.push("Email is invalid");
      }

      if (!vm.user.Password) {
        vm.errors.push("Password is required");
      }

      return vm.errors.length < 1;

    }

  }
})();
