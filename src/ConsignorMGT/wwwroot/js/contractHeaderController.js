//contractHeaderController.js

(function () {

    "use strict"
    angular.module('app-contracts')
    .controller('contractHeaderController', contractHeaderController)

    function contractHeaderController($http) {

        var viewModel = this;

        viewModel.contracts = [];

        viewModel.newContract = {};

        viewModel.errorMessage = "";

        viewModel.isBusy = true;


        $http.get("http://localhost:51146/api/contractsheader")
            .then(function (response) {
                angular.copy(response.data, viewModel.contracts)
            }, function (error) {

                viewModel.errorMessage = "Failed to load data : " + error;
            })
             .finally(function () {
                 viewModel.isBusy = false;
             });

        viewModel.addContract = function () {

            viewModel.isBusy = true;
            viewModel.errorMessage = "";

            $http.post("http://localhost:51146/api/contractsheader", viewModel.newContract)
            .then(function (response) {
                
                viewModel.contracts.push(response.data);
                viewModel.newContract = {};

            }, function (error) {

                viewModel.errorMessage = "Failed to save new contract : " + error;
            })
             .finally(function () {
                 viewModel.isBusy = false;
             });

            
            //viewModel.contracts.push({
            //    consignorCode: viewModel.newContract.consignorCode,
            //    eventNumber  : viewModel.newContract.eventNumber, 
            //        type     : viewModel.newContract.type,
            //    dateSigned   : new Date()
            //});
            
        };

    }

})()