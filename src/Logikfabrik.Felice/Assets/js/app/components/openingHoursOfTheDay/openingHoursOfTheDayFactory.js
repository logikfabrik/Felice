app.factory('openingHoursOfTheDayFactory', ['$http', function ($http) {
    var url = '/api/OpeningHours';
    var dataFactory = {};

    dataFactory.getOpeningHoursOfTheDay = function () {
        return $http.get(url);
    };

    return dataFactory;
}]);