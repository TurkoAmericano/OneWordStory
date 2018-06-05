(function () {
    'use strict';
    var controllerId = 'home';
  angular.module('app').controller(controllerId, ['common', 'auth', home]);

  function home(common, auth) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
            
        var vm = this;
        vm.news = {
            title: 'One Word Story',
            description: 'Great stories, one word at a time'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.title = 'Home';

        activate();

        function activate() {
          var promises = [auth.getUser()];
          common.activateController(promises, controllerId);

          

        }

        
    }
})();
