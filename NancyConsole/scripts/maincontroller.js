/// <reference path="jquery-2.1.1.js" />
/// <reference path="angular.js" />
/// <reference path="apiroutes.js" />
var mainmodule = angular.module('mainmodule', []);

mainmodule.controller('mainController', ['$scope', function ($scope) {
    $scope.data = {};

    $scope.ladeMitarbeiter = function () {
        $scope.data.kunden = undefined;
        $.getJSON(abrHelper.URLS.ApiGetMitarbeiter)
            .done(function (result) {
                $scope.$apply(function () {
                    $scope.data.mitarbeiter = result;
                });
            }).fail(function (error) {
                alert("Konnte Mitarbeiter nicht lesen:\n" + angular.fromJson(error));
            });
    }; 

    $scope.ladeKunden = function () {
        $scope.data.mitarbeiter = undefined;
        $.getJSON(abrHelper.URLS.ApiGetKunden)
            .done(function (result) {
                $scope.$apply(function () {
                    $scope.data.kunden = result;
                });
            }).fail(function (error) {
                alert("Konnte Kunden nicht lesen:\n" + angular.fromJson(error));
            });
    };
    
}]);