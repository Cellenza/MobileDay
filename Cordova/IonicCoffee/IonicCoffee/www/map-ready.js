var lastopened = null;

var addCoffee = function(map, coffee, selected) {

  if(!coffee.position) return false;

  var detail = '<div>' + 
    '<h2>' + coffee.nom +
    '</h2>' +
    '<div>' + coffee.adresse + ', ' + coffee.arrondissement+
    '</div>'
  '</div>'

  var info = new google.maps.InfoWindow({
    content: detail
  });
  
  var marker = new google.maps.Marker({
      position: new google.maps.LatLng(coffee.position[0], coffee.position[1]),
      map: map,
      icon: 'media/coffee.png',
      title: coffee.nom
  });

  var selectMarker = function () {
    if(lastopened !== null) {
      lastopened.close();
    }
    info.open(map,marker);
    map.panTo(marker.getPosition());
    lastopened = info;
  }

  google.maps.event.addListener(marker, 'click', function() {
    selectMarker();
  });

  if(selected) {
    selectMarker();
    return true;
  }

  return false;
};

var addMe = function(map, me) {

  if(!me || !me.coords) return;

  var detail = '<div>' + 
    '<h1>Je crois que c\'est moi !!!!</h1>' 
  '</div>'

  var info = new google.maps.InfoWindow({
    content: detail
  });
  
  var marker = new google.maps.Marker({
      position: new google.maps.LatLng(me.coords.latitude, me.coords.longitude),
      map: map,
      icon: 'media/me.png',
      title: 'Ma position'
  });

  google.maps.event.addListener(marker, 'click', function() {
    if(lastopened !== null) {
      lastopened.close();
    }
    info.open(map,marker);
    map.panTo(marker.getPosition());
    lastopened = info;
  });

  return marker;
};

 function mapReady (data) {
  
  navigator.geolocation.getCurrentPosition(function (me) {

    var itemselected = false;

    for (var i = 0; i < data.coffees.length; i++) {
      
      itemselected = itemselected || addCoffee(window.Map, data.coffees[i], data.coffees[i].id === data.selected );

    };   

    var mymarker = addMe(window.Map, me);

    if(itemselected == false) {
      window.Map.panTo(mymarker.getPosition());
    }

  });
}