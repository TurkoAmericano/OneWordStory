(function () {
  'use strict';
  var controllerId = 'signup';
  angular.module('app').controller(controllerId, ['common', 'datacontext', signup]);

  function signup(common, datacontext) {

    var vm = this;

    vm.newUser = newUser;
    vm.user = {};
    vm.errors = [];

    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }

    function newUser() {
      if (validate()) {
      datacontext.createUser(vm.user).then(function () {
        });
      }
    }


    function validate() {
      vm.errors = [];
      if (!vm.user.FirstName) {
        vm.errors.push("First name is required");
      }

      if (!vm.user.LastName) {
        vm.errors.push("Last name is required");
      }

      if (!vm.user.Email) {
        vm.errors.push("Email is required");
      }

      var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      if (!re.test(String(vm.user.Email).toLowerCase())) {
        vm.errors.push("Email is invalid");
      }

      if (!vm.user.Password) {
        vm.errors.push("Password is required");
      }

      if (vm.user.Password !== vm.user.ConfirmPassword) {
        vm.errors.push("Passwords do not match");
      }

      return vm.errors.length < 1;

    }



  }
})();
