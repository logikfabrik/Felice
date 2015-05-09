app.factory('dishOfTheDayFactory', ['$http', function ($http) {
    var url = '/api/Dish';
    var dataFactory = {};

    dataFactory.getDishOfTheDay = function (date) {
        return $http.get(url, {
            params: {
                date: date
            }
        });
    };

    return dataFactory;
}]);