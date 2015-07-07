angular.module('umbraco.resources')
    .factory('openingHoursFactory', ['$http', function ($http) {
        var url = '/api/OpeningHours/GetDayNames';
        var dataFactory = {};

        dataFactory.getDayNames = function () {
            return $http.get(url);
        };

        return dataFactory;
    }]);