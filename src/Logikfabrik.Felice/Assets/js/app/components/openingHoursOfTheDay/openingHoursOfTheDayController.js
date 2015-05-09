app.controller('openingHoursOfTheDayController', ['$scope', '_', 'openingHoursOfTheDayFactory',
    function ($scope, _, openingHoursOfTheDayFactory) {
        $scope.openingHours = null;
        $scope.date = new Date();

        function getOpeningHours(date) {
            openingHoursOfTheDayFactory.getOpeningHoursOfTheDay(date).success(function (resp) {
                $scope.openingHours = resp.Data;
            });
        }

        $scope.hasOpeningHours = function () {
            return !_.isEmpty($scope.openingHours);
        };

        getOpeningHours($scope.date);

    }]);