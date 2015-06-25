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
        adresse : (cafedata.fields.adresse.length <= 43 ? cafedata.fields.adresse : cafedata.fields.adresse.substr(0, 40) + '...'),
        arrondissement : lisible(cafedata.fields.arrondissement),
      };
    };

    public_.getCoffeeShop = function (id) {
      return $http.get('http://opendata.paris.fr/api/records/1.0/search/?dataset=liste-des-cafes-a-un-euro&q=recordid+%3D+'+id);
    }

    public_.getCoffeeShops = function (position) {
      if (position) {
        //return $http.get('http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&geofilter.distance='
          //+ position[0] + '%2C' + position[1] +'%2C10000');
      };
      return $http.get('http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&rows=50&facet=arrondissement&facet=nom_du_cafe&facet=geoloc&facet=adresse');
    }

    return public_;

  }])

  .controller('carteCtr', [function() {

  }]);