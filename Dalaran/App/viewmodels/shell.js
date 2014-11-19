define(['plugins/router', 'durandal/app', 'jquery', 'knockout'],
    function (router, app, $, ko) {
        this.loggedIn = ko.observable(false);

        activate = function () {
            router.map([
                { route: '', title: 'Home', moduleId: 'viewmodels/home' },
                { route: 'login/login', moduleId: 'viewmodels/login/login' }
            ]);
            return router.activate();
        };

        return {
            router: router,
            activate: activate,
            loggedIn: loggedIn
        };
    });