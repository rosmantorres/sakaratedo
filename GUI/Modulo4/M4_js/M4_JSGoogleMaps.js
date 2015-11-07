    function initialize() {
        var latlng = new google.maps.LatLng(51.508742, -0.120850);
        var mapProp = {
            center: latlng,
            zoom: 5,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var contentString = '<div id="content">' +
                                '<div id="siteNotice">' +
                                    '</div>' +
      '<h1 id="firstHeading" class="firstHeading">Título</h1>' +
      '<div id="bodyContent">' +
      '<p>  Cuerpo </p>' +
      '<p>' +
      '</p>' +
      '</div>' +
      '</div>';
        var infowindow = new google.maps.InfoWindow({
            content: contentString,
            maxWidth: 150
        });
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        var point = new google.maps.LatLng(51.508742, -0.120850);
        var marker = new google.maps.Marker({
            position: point,
            map: map,
            title: 'Ubicación',
        })
        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });
    }
google.maps.event.addDomListener(window, 'load', initialize);

