(function () {
  'use strict';
  var controllerId = 'login';
  angular.module('app').controller(controllerId, [login]);

  function login() {
    
    var vm = this;
    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }


  }
})();
