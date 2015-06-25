'use strict';

angular.module('coffiz.apropos', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/apropos', {
    templateUrl: 'apropos/apropos.html',
    controller: 'aproposCtr'
  });
}])

.controller('aproposCtr', [function() {

}]);