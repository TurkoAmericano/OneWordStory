(function () {
  'use strict';
  var controllerId = 'login';
  angular.module('app').controller(controllerId, ['common', login]);

  function login(common) {
    
    var vm = this;
    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }


  }
})();
