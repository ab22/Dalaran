define(['plugins/router', 'durandal/app', 'jquery'],
    function (router, app, $) {
        var self;
        var Shell = function(){
            self = this;
            this.MenuItems = ko.observableArray([
                { Name: 'Home' },
                { Name: 'About us' },
                { Name: 'Contact us' },
                { Name: 'Account' }
            ]);
            this.router = router;
            this.activate = function () {
                router.map([
                    { route: '', title: 'Home', moduleId: 'viewmodels/home' },
                    { route: 'flickr', moduleId: 'viewmodels/flickr' },
                    { route: 'welcome', moduleId: 'viewmodels/welcome' }
                ]);
                return router.activate();
            };
        };

        return Shell;
    });