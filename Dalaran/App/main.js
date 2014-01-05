requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'jquery': '../Scripts/jquery-1.10.2',
        'knockout': '../Scripts/knockout-2.3.0',
        'modernizr': '../Scripts/modernizr-2.6.2',
        'iosslider': '../Scripts/website/jquery.iosslider.min',
        'magnificpopup': '../Scripts/website/jquery.magnific-popup',
        'webplugins': '../Scripts/website/plugins',
        'respond': '../Scripts/website/respond.min',
        'theme': '../Scripts/website/theme'
    },
    shim: {
        'webplugins': {
            'deps': ['jquery'],
            'exports': 'Webplugins'
        },
        'theme': {
            'deps': ['jquery', 'magnificpopup', 'webplugins'],
            'exports': 'Theme'
        }
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