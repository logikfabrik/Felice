app.controller('dishOfTheDayController', ['$scope', 'lodash', 'dishOfTheDayFactory',
    function ($scope, _, dishOfTheDayFactory) {
        $scope.dish = null;
        $scope.date = new Date();

        function getDish(date) {
            dishOfTheDayFactory.getDishOfTheDay(date).success(function (resp) {
                $scope.dish = resp.Data;
            });
        }

        $scope.hasDish = function () {
            return !_.isEmpty($scope.dish);
        };

        getDish($scope.date);

    }]);