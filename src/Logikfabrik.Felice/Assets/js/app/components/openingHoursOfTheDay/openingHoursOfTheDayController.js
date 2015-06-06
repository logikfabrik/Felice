app.controller('openingHoursOfTheDayController', ['$scope', 'lodash', 'openingHoursOfTheDayFactory',
    function ($scope, _, openingHoursOfTheDayFactory) {
        $scope.openingHours = null;

        function getOpeningHours() {
            openingHoursOfTheDayFactory.getOpeningHoursOfTheDay().success(function (resp) {
                $scope.openingHours = resp.Data;
            });
        }

        $scope.hasOpeningHours = function () {
            return !_.isEmpty($scope.openingHours);
        };

        getOpeningHours();

    }]);