app.controller('findUsOnTheMapController', ['$scope', 'lodash', 'leaflet',
    function ($scope, _, L) {
        $scope.init = function (lat, lng, address) {
            L.Icon.Default.imagePath = '/Assets/packages/leaflet-0.7.3/images';

            var map = L.map('map', { zoomControl: false });

            map.setMaxBounds(L.latLngBounds(L.latLng(-90, -180), L.latLng(90, 180)));
            map.setView([lat, lng], 13);

            L.esri.basemapLayer('Topographic').addTo(map);
            
            var marker = L.marker([lat, lng]);

            marker.addTo(map);
            marker.bindPopup(address).openPopup();
        };
    }]);