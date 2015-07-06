angular.module('umbraco').controller('openingHoursController', ['$scope', '_', 'sprintf',
    function ($scope, _, sprintf) {

        function getHours() {
            var hours = [];

            for (var i = 0; i < 24; i++) {
                var h = i.toString();

                if (h.length < 2)
                    hours.push('0' + h);
                else
                    hours.push(h);
            }

            return hours;
        }

        function getMinutes() {
            var minutes = [];

            for (var i = 0; i < 12; i++) {
                var m = (i * 5).toString();

                if (m.length < 2)
                    minutes.push('0' + m);
                else
                    minutes.push(m);
            }

            return minutes;
        }

        function getDaysOfWeek() {
            return [
                { name: 'Sunday', value: 0 },
                { name: 'Monday', value: 1 },
                { name: 'Tuesday', value: 2 },
                { name: 'Wednesday', value: 3 },
                { name: 'Thursday', value: 4 },
                { name: 'Friday', value: 5 },
                { name: 'Saturday', value: 6 }
            ];
        }

        function getDayName(day) {
            var daysOfWeek = getDaysOfWeek();

            return _.result(_.findWhere(daysOfWeek, { 'value': day }), 'name');
        }

        function getOpeningHour() {
            return {
                type: 'dayOfWeek',
                dayOfWeek: 0,
                from: {
                    hours: '00',
                    minutes: '00'
                },
                to: {
                    hours: '00',
                    minutes: '00'
                }
            };
        }

        function isValid(openingHour) {
            switch (openingHour.type) {
                case 'date':
                    return !_.isEmpty(openingHour.name) && !_.isEmpty(openingHour.date);
                case 'dayOfWeek':
                    return !_.isEmpty(openingHour.name);
                default:
                    return false;
            }
        };

        $scope.config = {
            hours: getHours(),
            minutes: getMinutes(),
            daysOfWeek: getDaysOfWeek()
        };

        $scope.openingHour = getOpeningHour();

        if (!$scope.model.value)
            $scope.model.value = [];
        else {
            $scope.model.value = [].concat($scope.model.value);
        }

        $scope.format = function (openingHour) {
            switch (openingHour.type) {
                case 'date':
                    return sprintf('%s %s %s:%s-%s:%s', openingHour.name, openingHour.date, openingHour.from.hours, openingHour.from.minutes, openingHour.to.hours, openingHour.to.minutes, openingHour.open);

                case 'dayOfWeek':
                    return sprintf('%s %s %s:%s-%s:%s', openingHour.name, getDayName(openingHour.dayOfWeek), openingHour.from.hours, openingHour.from.minutes, openingHour.to.hours, openingHour.to.minutes);

                default:
                    return null;
            }
        };
        
        $scope.add = function (openingHour) {
            if (!isValid(openingHour))
                return;

            var clone = JSON.parse(JSON.stringify(openingHour));

            $scope.model.value.push(clone);
            $scope.openingHour = getOpeningHour();
        };

        $scope.remove = function (openingHour) {
            var index = _.indexOf($scope.model.value, openingHour);

            if (index == -1)
                return;

            $scope.model.value.splice(index, 1);
        };
    }]);