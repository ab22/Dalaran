define(['plugins/router', 'durandal/app', 'jquery'],
    function (router, app, $){
    return {
        router: router,
        activate: function () {
            router.map([
                { route: '', title: 'Home', moduleId: 'viewmodels/home'},
                { route: 'flickr', moduleId: 'viewmodels/flickr' },
                { route: 'welcome', moduleId: 'viewmodels/welcome'}
            ]);


            return router.activate();
        }
    };
    });