app.factory('dishOfTheDayFactory', ['$http', function ($http) {
    var url = '/api/Dish/GetDishOfTheDay';
    var dataFactory = {};

    dataFactory.getDishOfTheDay = function () {
        return $http.get(url);
    };

    return dataFactory;
}]);