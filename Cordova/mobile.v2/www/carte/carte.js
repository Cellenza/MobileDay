'use strict';

angular.module('coffiz.carte', ['ngRoute', 'coffiz.service'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/carte', {
    templateUrl: 'carte/carte.html',
    controller: 'carteCtr'
  });
  $routeProvider.when('/carte/:selected/go', {
    templateUrl: 'carte/carte.html',
    controller: 'carteCtr'
  });
}])

.controller('carteCtr', ['$routeParams', 'coffeeShopSvc', function($routeParams, svc) {
  
  var selected = $routeParams.selected;
  navigator.geolocation.getCurrentPosition(function (me) {

    if(selected) {

      svc.getCoffeeShop (selected).then(function(coffee) {

        svc.getCoffeeShops(coffee.data.records[0].fields.geoloc).then(function (r) {
          
          $('body').trigger('mapReady', {
            coffees : r.data.records.map(svc.simplified), 
            selected : selected ,
            me : me
          });
        });
      });
      return;
    }

    svc.getCoffeeShops([me.coords.latitude, me.coords.longitude]).then(function (r) {
      
      $('body').trigger('mapReady', {
        coffees : r.data.records.map(svc.simplified), 
        selected : selected ,
        me : me
      });
    });

  });

}]);