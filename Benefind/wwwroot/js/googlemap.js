// This example requires the Places library. Include the libraries=places
// parameter when you first load the API. For example:


function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -37.82, lng: 144.92  },
        zoom: 13
    });

    var locations = [
        [-36.0769552, 146.9236079],
        [-37.2854916, 142.936474],
        [-37.563325, 143.8587894],
        [-36.7635313, 144.2782535],
        [-38.074, 144.359],
        [-37.738321, 145.002204],
        [-36.1263583, 144.7478992],
        [-37.6543494, 145.0236128],
        [-36.7135089, 142.2004277],
        [-38.1957452, 146.5363795],
        [-38.3827013, 142.4857092],
        [-37.2825952, 142.9307482],
        [-37.6535191, 144.4221067],
        [-37.5631869, 143.8558799],
        [-38.047735, 144.170585],
        [-37.4397074, 143.3801959],
        [-36.7614149, 144.2780776],
        [-37.6759309, 144.9200222],
        [-38.2316148, 143.1462534],
        [-37.8763142, 145.0992289],
        [-37.9276151, 145.1174516],
        [-37.7444682, 144.9646082],
        [-38.3411076, 143.5866017],
        [-37.3408974, 144.1442823],
        [-38.1353835, 145.8487441],
        [-36.1256301, 144.7486946],
        [-37.036447, 141.297586],
        [-37.8046756, 144.9771704],
        [-38.145125, 145.12227],
        [-38.1447229, 144.3491698],
        [-37.8784044, 145.1626021],
        [-37.7029651, 145.1044589],
        [-37.7438982, 142.022588],
        [-37.9500576, 145.0804372],
        [-36.7174508, 142.1993631],
        [-37.244086, 144.4468743],
        [42.6738489, -71.14563489999999],
        [-36.334389, 141.654663],
        [-38.3810122, 142.2292907],
        [-38.38285, 142.2380711],
        [-37.7431432, 145.0027525],
        [-38.354306, 144.912078],
        [-37.783111, 144.8321327],
        [-37.682755, 145.0165695],
        [-38.1956143, 146.5386185],
        [-37.832982, 145.208542],
        [-36.3550413, 146.323453],
        [-36.250983, 142.3838792],
        [-38.3824268, 142.4885336],
        [-37.782113, 145.6121121],
        [-37.2825952, 142.9307482],
        [-37.6535191, 144.4221067],
        [-37.5631869, 143.8558799],
        [-38.047735, 144.170585],
        [-37.8423243, 145.2664807],
        [-37.4397074, 143.3801959],
        [-36.5498459, 145.9832477],
        [-36.7614149, 144.2780776],
        [-37.817942, 145.117609],
        [-36.7315402, 146.9688293],
        [-37.6759309, 144.9200222],
        [-38.2316148, 143.1462534],
        [-37.051243, 144.220742],
        [-37.7634738, 145.3092516],
        [-38.3137811, 146.4211687],
        [-37.7444682, 144.9646082],
        [-38.3404861, 143.5826608],
        [-36.199312, 147.902714],
        [-37.3408974, 144.1442823],
        [-37.7889636, 145.125473],
        [-36.1256301, 144.7486946],
        [-37.0360827, 141.2974518],
        [-37.8046756, 144.9771704],
        [-38.145125, 145.12227],
        [-38.1513366, 144.363725],
        [-37.8992463, 145.1424982],
        [-37.7029651, 145.1044589],
        [-37.7438982, 142.022588],
        [-37.8211576, 145.0219983],
        [-37.6555974, 145.5244438],
        [-37.9500576, 145.0804372],
        [-36.7174508, 142.1993631],
        [-37.244086, 144.4468743],
        [-38.4753295, 145.9554613],
        [-37.0523788, 146.0913203],
        [-37.0491211, 143.7405678],
        [-38.1802778, 146.2606384],
        [-38.2353949, 146.3998085],
        [-38.0235007, 145.3137975],
        [-36.334389, 141.654663],
        [-38.38285, 142.2380711],
        [-38.34522150000001, 141.6013885],
        [-37.7431432, 145.0027525],
        [-38.2688928, 144.6631427],
        [-37.8169753, 145.2250145],
        [-38.354306, 144.912078],
        [-37.8998097, 145.2296967],
        [-37.8306139, 144.959214],
        [-37.6517556, 145.0859519],
        [-37.0557155, 142.781878],
        [-37.682755, 145.0165695],
        [-38.3245964, 144.3183912],
        [-36.3527891, 146.3268187],
        [-36.2508256, 142.3841099],
        [-38.1624699, 145.9333328],
        [-38.3824268, 142.4885336],
        [-36.1141144, 146.8635033],
        [-38.6057203, 145.5924069],
        [-36.312674, 146.838858]

    var card = document.getElementById('pac-card');
    var input = document.getElementById('pac-input');
    var types = document.getElementById('type-selector');
    var strictBounds = document.getElementById('strict-bounds-selector');

    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

    var autocomplete = new google.maps.places.Autocomplete(input);

    // Bind the map's bounds (viewport) property to the autocomplete object,
    // so that the autocomplete requests use the current map bounds for the
    // bounds option in the request.
    autocomplete.bindTo('bounds', map);

    // Set the data fields to return when the user selects a place.
    autocomplete.setFields(
        ['address_components', 'geometry', 'icon', 'name']);

    var infowindow = new google.maps.InfoWindow();
    var infowindowContent = document.getElementById('infowindow-content');
    infowindow.setContent(infowindowContent);
    var marker = new google.maps.Marker({
        map: map,
        anchorPoint: new google.maps.Point(0, -29)
    });

    autocomplete.addListener('place_changed', function () {
        infowindow.close();
        marker.setVisible(false);
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            // User entered the name of a Place that was not suggested and
            // pressed the Enter key, or the Place Details request failed.
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  // Why 17? Because it looks good.
        }
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);

        var address = '';
        if (place.address_components) {
            address = [
                (place.address_components[0] && place.address_components[0].short_name || ''),
                (place.address_components[1] && place.address_components[1].short_name || ''),
                (place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
        }

        infowindowContent.children['place-icon'].src = place.icon;
        infowindowContent.children['place-name'].textContent = place.name;
        infowindowContent.children['place-address'].textContent = address;
        infowindow.open(map, marker);
    });

    // Sets a listener on a radio button to change the filter type on Places
    // Autocomplete.
    function setupClickListener(id, types) {
        var radioButton = document.getElementById(id);
        radioButton.addEventListener('click', function () {
            autocomplete.setTypes(types);
        });
    }

    setupClickListener('changetype-all', []);
    setupClickListener('changetype-address', ['address']);
    setupClickListener('changetype-establishment', ['establishment']);
    setupClickListener('changetype-geocode', ['geocode']);

    document.getElementById('use-strict-bounds')
        .addEventListener('click', function () {
            console.log('Checkbox clicked! New state=' + this.checked);
            autocomplete.setOptions({ strictBounds: this.checked });
        });
}

<script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCq3dAnNzFMQHd8rPZuKGUCR2UYpbRjvZ8&callback=initMap">
</script>
