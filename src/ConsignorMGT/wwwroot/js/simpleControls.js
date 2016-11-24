//simpleControls.js

(function () {

    "use strict";

    angular.module('simpleControls', [])
    .directive('waitCursor', waitCursor)

    function waitCursor() {
        return {
            scope: {
                show: "=displayWhen" // scope name is "show" and consumer directive is displaywhen
            },
            restrict : "E",  // if not it doesn't need to be used only as an element
            templateUrl: "/views/waitCursor.html"

        };
    }
})();