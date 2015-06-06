app.controller('dishOfTheDayController', ['$scope', 'lodash', 'dishOfTheDayFactory',
    function ($scope, _, dishOfTheDayFactory) {
        $scope.dish = null;

        function getDish() {
            dishOfTheDayFactory.getDishOfTheDay().success(function (resp) {
                $scope.dish = resp.Data;
            });
        }

        $scope.hasDish = function () {
            return !_.isEmpty($scope.dish);
        };

        getDish();

    }]);