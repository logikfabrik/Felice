app.factory('dishOfTheDayFactory', ['$http', function ($http) {
    var url = '/api/Dish';
    var dataFactory = {};

    dataFactory.getDishOfTheDay = function () {
        return $http.get(url);
    };

    return dataFactory;
}]);