'use strict';

angular

  .module('coffiz', ['ngRoute','coffiz.liste','coffiz.carte','coffiz.apropos'])

  .config(['$routeProvider', function($routeProvider, coffeeShopSvc) {

    $routeProvider.otherwise({redirectTo: '/apropos'});

  }]);