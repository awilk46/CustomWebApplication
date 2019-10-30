var app = angular.module('myApp', ['uiGmapgoogle-maps', 'nemLogging'])
    .config(function (uiGmapGoogleMapApiProvider) {
        uiGmapGoogleMapApiProvider.configure({
            key: 'AIzaSyCE6dCSi81vXcNS54lBLkgOFSsLVAExm7U',
            v: '3.37',
            libraries: 'weather,geometry,visualization'
        });
    }).controller('mapController', function ($scope, $http) {

        $scope.map = {
            center: { latitude: 50.051987, longitude: 21.409497 },
            zoom: 15
        }

        $scope.markers = [];
        $scope.locations = [];

        $http.get('/Home/LocationsToJson').then(function (data) {

            $scope.locations = data.data;

        }, function () {
            alert('error tutaj');
        });

        $scope.ShowLocation = function (locationID) {

            $http.get('/Home/GetMarkerInfo', {
                params: { locationID: locationID }
            }).then(function (data) {

                $scope.markers = [];
                $scope.markers.push({

                    id: data.data.LocationID,
                    coords: { latitude: data.data.Latitude, longitude: data.data.Long },
                    name: data.data.Name,
                    address: data.data.Address
                });

                $scope.map.center.latitude = data.data.Latitude;
                $scope.map.center.longitude = data.data.Long;


            }, function () {
                alert('error');
            });
        }

        $scope.windowOptions = {
            show: true
        };

    });