requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'jquery': '../Scripts/jquery-1.10.2',
        'knockout': '../Scripts/knockout-2.3.0',
        'bookblock': '../Scripts/website/bookblock',
        'bs': '../Scripts/website/bs',
        'bxslider': '../Scripts/website/bxslider',
        'easing': '../Scripts/website/easing',
        'input-clear': '../Scripts/website/input-clear',
        'jquery.zoom': '../Scripts/website/jquery.zoom',
        'lib': '../Scripts/website/lib',
        'modernizr': '../Scripts/website/modernizr',
        'range-slider': '../Scripts/website/range-slider',
        'social': '../Scripts/website/social',
        'ui': '../Scripts/website/ui'
    }
});



define(['durandal/system', 'durandal/app', 'durandal/viewLocator'],  function (system, app, viewLocator) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Dalaran';

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell');
    });
});