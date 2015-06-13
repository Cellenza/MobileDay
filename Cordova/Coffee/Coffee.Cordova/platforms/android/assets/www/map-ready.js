var lastopened = null;

var addNewMarker = function(map, coffee) {

  if(!coffee.position) return;

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

  google.maps.event.addListener(marker, 'click', function() {
    if(lastopened !== null) {
      lastopened.close();
    }
    info.open(map,marker);
    map.panTo(marker.getPosition());
    lastopened = info;
  });
};

$('body').on('mapReady', function (_, data) {
  
  for (var i = 0; i < data.coffees.length; i++) {
    
    addNewMarker(window.Map, data.coffees[i]);

  };

});