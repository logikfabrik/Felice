app.controller('findUsOnTheMapController', ['$scope', '_', 'googleMaps',
    function ($scope, _, googleMaps) {
        function loadMap() {
            var mapProp = {
                center: new googleMaps.LatLng(51.508742, -0.120850),
                zoom: 5,
                mapTypeId: googleMaps.MapTypeId.ROADMAP
            };

            new googleMaps.Map(document.getElementById('googleMap'), mapProp);
        }

        googleMaps.event.addDomListener(window, 'load', loadMap);

    }]);