//contractDetailController.js

(function () {
   "use strict";
    angular.module('app-contracts')
    .controller('contractDetailController', contractDetailController)

function contractDetailController($http, $routeParams) {

    var viewModel = this;
    viewModel.fullContract = [];
    viewModel.addContractDetails = [];
    viewModel.newContractDetails = {};
    viewModel.errorMessage = "";
    viewModel.isBusy = true;
    viewModel.ownerCode= $routeParams.consignorCode;
    viewModel.eventNumber = $routeParams.eventNumber;

    $http.get("http://localhost:51146/api/contractsheader/" + viewModel.ownerCode + "/" + viewModel.eventNumber + "/contractsdetail")
           .then(function (response) {
               angular.copy(response.data, viewModel.fullContract)

           }, function (error) {

               viewModel.errorMessage = "Failed to load data : " + error;
           })
            .finally(function () {
                viewModel.isBusy = false;
            });

    viewModel.addContractDetails = function () {
        viewModel.isBusy = true;
        viewModel.errorMessage = "";

        $http.post("http://localhost:51146/api/contractsheader/" + viewModel.ownerCode + "/" + viewModel.eventNumber + "/contractsdetail", viewModel.newContractDetails)
        .then(function (response) {
            viewModel.fullContract.push(response.data)

        }, function (error) {
            viewModel.errorMessage = "Failed to save contract details : " + error;
        })
            .finally(function () {
            viewModel.isBusy = false;
        });

        
        //viewModel.addContractDetails.push({

        //    manufacture: viewModel.newContractDetails.manufacture,
        //    model: viewModel.newContractDetails.model,
        //    RandRBudget: viewModel.newContractDetails.RandRBudget,
        //    surChargeRate: viewModel.newContractDetails.surChargeRate,
        //    dateCreated : new Date()

        //});
    }

}

})()