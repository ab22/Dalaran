define(['plugins/http', 'knockout', 'jquery', 'viewmodels/shell'],
    function (http, ko, $, shell) {

        compositionComplete = function () {
            shell.loggedIn(true);
        };

        return {
            compositionComplete: compositionComplete
        };

    }
);