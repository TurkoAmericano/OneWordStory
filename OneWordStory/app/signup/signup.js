(function () {
  'use strict';
  var controllerId = 'signup';
  angular.module('app').controller(controllerId, ['common', 'datacontext', signup]);

  function signup(common, datacontext) {

    var vm = this;

    vm.newUser = newUser;
    vm.user = {};

    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }

    function newUser() {
      datacontext.createUser(vm.user);
    }


  }
})();
