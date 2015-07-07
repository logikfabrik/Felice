angular.module('umbraco')
    .controller('openingHoursController', ['$scope', '_', 'sprintf', 'openingHoursFactory', 'localizationService',
        function ($scope, _, sprintf, openingHoursFactory, localizationService) {
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

            function getDayName(day) {
                return _.result(_.findWhere($scope.config.daysOfWeek, { 'value': day }), 'name');
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
            }

            $scope.config = {
                hours: getHours(),
                minutes: getMinutes(),
                daysOfWeek: null,
                localization: {
                    name: null,
                    date: null,
                    dayOfWeek: null,
                    from: null,
                    to: null,
                    add: null
                }
            };
            
            openingHoursFactory.getDayNames().success(function (resp) {
                $scope.config.daysOfWeek = resp.Data;
            });

            localizationService.localize('felice_name').then(function (value) {
                $scope.config.localization.name = value;
            });

            localizationService.localize('felice_date').then(function (value) {
                $scope.config.localization.date = value;
            });

            localizationService.localize('felice_dayOfWeek').then(function (value) {
                $scope.config.localization.dayOfWeek = value;
            });

            localizationService.localize('felice_from').then(function (value) {
                $scope.config.localization.from = value;
            });

            localizationService.localize('felice_to').then(function (value) {
                $scope.config.localization.to = value;
            });

            localizationService.localize('felice_add').then(function (value) {
                $scope.config.localization.add = value;
            });

            $scope.openingHour = getOpeningHour();

            if (!$scope.model.value)
                $scope.model.value = [];
            else
                $scope.model.value = [].concat($scope.model.value);

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