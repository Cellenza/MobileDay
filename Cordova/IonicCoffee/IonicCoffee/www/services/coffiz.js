'use strict';

angular

  .module('coffiz.service', [])

  .factory('coffeeShopSvc', ['$http', function($http) {
    
    var public_ = {};

    var lisible = function (arrondissement) {
      var n =  Number(arrondissement) - 75000;
      return n === 1 ? (n + ' er') : (n + ' \xE8me');
    };

    public_.simplified = function(cafedata) {
      return {
        id : cafedata.recordid,
        position : cafedata.fields.geoloc,
        nom : cafedata.fields.nom_du_cafe,
        adresse : cafedata.fields.adresse,
        arrondissement : lisible(cafedata.fields.arrondissement),
      };
    };

    public_.getCoffeeShops = function () {
      return $http.get('http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&rows=50&facet=arrondissement&facet=nom_du_cafe&facet=adresse');
    }

    return public_;

  }])

  .controller('carteCtr', [function() {

  }]);