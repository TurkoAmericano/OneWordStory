(function () {
  'use strict';
  var controllerId = 'createStory';
  angular.module('app').controller(controllerId, ['common', createStory]);

  function createStory(common) {

    var vm = this;

    vm.login = login;
    vm.user = {};

    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }
  }
})();
