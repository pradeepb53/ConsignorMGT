//app-contracts.js

(function ()
{
    "use strict"

    angular.module('app-contracts', ['simpleControls', 'ngRoute'])
    .config(function ($routeProvider) {

        $routeProvider.when("/", {

            controller   : "contractHeaderController",
            controllerAs : "vm",
            templateUrl: "/views/headerView.html"

        });

        $routeProvider.when("/detail/:consignorCode/:eventNumber", {

            controller: "contractDetailController",
            controllerAs: "vm",
            templateUrl: "/views/detailView.html"

        });

        $routeProvider.otherwise({ redirectTo: "/" });
        //$locationProvider.html5Mode(true);
    });

})()