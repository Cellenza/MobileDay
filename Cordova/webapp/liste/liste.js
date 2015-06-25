'use strict';

angular.module('coffiz.liste', ['ngRoute', 'coffiz.service'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/liste', {
    templateUrl: 'liste/liste.html',
    controller: 'listeCtr'
  });
}])

.controller('listeCtr', ['$scope', 'coffeeShopSvc', function($scope, svc) {
  
  $scope.cafes = [];

  svc.getCoffeeShops().then(function (r) {
    
    $scope.cafes = r.data.records.map(svc.simplified);
    
  });
}]);