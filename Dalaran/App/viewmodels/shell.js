define(['plugins/router', 'durandal/app', 'jquery'],
    function (router, app, $) {
        var self;
        var Shell = function(){
            self = this;
            this.router = router;
            this.activate = function () {
                router.map([
                    { route: '', title: 'Home', moduleId: 'viewmodels/home' },
                    { route: 'login', moduleId: 'viewmodels/login' }
                   
                    
                ]);
                return router.activate();
            };
        };

        return Shell;
    });