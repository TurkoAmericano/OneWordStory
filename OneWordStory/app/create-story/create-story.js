(function () {
  'use strict';
  var controllerId = 'createStory';
  angular.module('app').controller(controllerId, ['common', 'datacontext', createStory]);

  function createStory(common, datacontext) {

    var vm = this;

    vm.user = {};
    vm.emails = [''];
    vm.addNewEmail = addNewEmail;
    vm.createStory = createStory;


    activate();

    function activate() {
      var promises = [];
      common.activateController(promises, controllerId);
    }

    function addNewEmail() {

      if (vm.emails[vm.emails.length - 1] !== '' ) {
        vm.emails.push('');
      }
    }

    function createStory() {
      if (validate()) {
        vm.CreateStory.Emails = vm.emails;
        datacontext.createStory(vm.CreateStory).then(function () {
          
        });
      }
    }

    function validate() {
      return true;
    }

    function clearDuplicates() {
      var counts = [];
      for (var i = 0; i <= vm.emails.length; i++) {
        if (counts[vm.emails[i]] === undefined) {
          counts[vm.emails[i]] = 1;
        } else {
          vm.emails.splice(i, 1);
        }
      }
    }


  }
})();
