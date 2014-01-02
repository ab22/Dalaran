define(['plugins/router', 'durandal/app', 'jquery', 'social'],
    function (router, app, $, social){
    return {
        router: router,
        activate: function () {
            router.map([
                { route: '', title: 'Home', moduleId: 'viewmodels/home'},
                { route: 'flickr', moduleId: 'viewmodels/flickr' },
                { route: 'welcome', moduleId: 'viewmodels/welcome'}
            ]);


            $('.social_active').hoverdir({});

            return router.activate();
        }
    };
    });