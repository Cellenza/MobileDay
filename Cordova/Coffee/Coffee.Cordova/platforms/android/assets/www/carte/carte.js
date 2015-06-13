'use strict';

angular.module('coffiz.carte', ['ngRoute', 'coffiz.service'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/carte', {
    templateUrl: 'carte/carte.html',
    controller: 'carteCtr'
  });
}])

.controller('carteCtr', ['coffeeShopSvc', function(svc) {
  
  svc.getCoffeeShops().then(function (r) {
    
    $('body').trigger('mapReady', {coffees : r.data.records.map(svc.simplified) });
    
  });
}]);