app.factory('openingHoursOfTheDayFactory', ['$http', function ($http) {
    var url = '/api/OpeningHours';
    var dataFactory = {};

    dataFactory.getOpeningHoursOfTheDay = function (date) {
        return $http.get(url, {
            params: {
                date: date
            }
        });
    };

    return dataFactory;
}]);