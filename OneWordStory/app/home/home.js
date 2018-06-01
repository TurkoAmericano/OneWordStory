(function () {
    'use strict';
    var controllerId = 'home';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'auth', home]);

  function home(common, datacontext, auth) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

    alert('token: ' + auth.getUser());

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
            var promises = [];
            common.activateController(promises, controllerId);
        }

        
    }
})();
