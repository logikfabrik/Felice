app.controller('findUsOnTheMapController', ['$scope', 'lodash', 'leaflet',
    function ($scope, _, L) {
        $scope.init = function (lat, lng) {
            var map = L.map('map', { zoomControl: false });

            map.setMaxBounds(L.latLngBounds(L.latLng(-90, -180), L.latLng(90, 180)));
            map.setView([lat, lng], 13);

            L.esri.basemapLayer('Topographic').addTo(map);
            L.marker([lat, lng]).addTo(map);
        };

    }]);