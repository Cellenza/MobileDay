'use strict';

angular.module('coffiz.carte', ['coffiz.service'])

//.config(['$routeProvider', function($routeProvider) {
//  $routeProvider.when('/carte', {
//    templateUrl: 'carte/carte.html',
//    controller: 'carteCtr'
//  });
//  $routeProvider.when('/carte/:selected', {
//    templateUrl: 'carte/carte.html',
//    controller: 'carteCtr'
//  });
//}])

.controller('carteCtr', ['$stateParams', 'coffeeShopSvc', function ($stateParams, svc) {

        var mapCanvas = document.getElementById('map-canvas');
        var mapOptions = {
            center: new google.maps.LatLng(48.850316, 2.330101),
            zoom: 14,
            disableDefaultUI: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        window.Map = new google.maps.Map(mapCanvas, mapOptions);

    svc.getCoffeeShops().then(function (r) {
        var selected = null;
        if ($stateParams.selected) {
            selected = $stateParams.selected;
        }

        mapReady({ coffees: r.data.records.map(svc.simplified), selected: selected });

    });
}]);