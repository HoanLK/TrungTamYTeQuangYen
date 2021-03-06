﻿front.controller("homeController", ['$scope', '$http', '$window', '$location', '$filter', '$sce', function ($scope, $http, $window, $location, $filter, $sce) {
    //VAR
    $scope.tinTucs = [];
    $scope.hoatDongTTs = [];
    $scope.hoatDongDoanThanhNien = [];
    $scope.giaoDucSucKhoes = [];
    $scope.tinTucNganhYs = [];
    $scope.thuCamOns = [];
    $scope.gocCuois = [];
    $scope.danhChoNguoiBenhs = [];
    $scope.cacQuyTrinhs = [];

    Init();

    function Init() {
        GetTinTucs();
        GetHoatDongTTs();
        GetHoatDongDoanThanhNien();
        GetGiaoDucSucKhoes();
        GetTinTucNganhYs();
        GetThuCamOns();
        GetGocCuois();
        GetDanhChoNguoiBenhs();
        GetCacQuyTrinhs();
    }

    //New
    function GetTinTucs() {
        $http.get('/API/PostAPI?att=tinTucHome&&value=1')
            .then(
            function success(response) {
                $scope.tinTucs = angular.copy(response.data);
                angular.forEach($scope.tinTucs, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetHoatDongTTs() {
        $http.get('/API/PostAPI?att=postHome&&value=15')
            .then(
            function success(response) {
                $scope.hoatDongTTs = angular.copy(response.data);
                angular.forEach($scope.hoatDongTTs, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetHoatDongDoanThanhNien() {
        $http.get('/API/PostAPI?att=postHome&&value=16')
            .then(
            function success(response) {
                $scope.hoatDongDoanThanhNien = angular.copy(response.data);
                angular.forEach($scope.hoatDongDoanThanhNien, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetGiaoDucSucKhoes() {
        $http.get('/API/PostAPI?att=postHome&&value=17')
            .then(
            function success(response) {
                $scope.giaoDucSucKhoes = angular.copy(response.data);
                angular.forEach($scope.giaoDucSucKhoes, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetTinTucNganhYs() {
        $http.get('/API/PostAPI?att=postHome&&value=18')
            .then(
            function success(response) {
                $scope.tinTucNganhYs = angular.copy(response.data);
                angular.forEach($scope.tinTucNganhYs, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetThuCamOns() {
        $http.get('/API/PostAPI?att=postHome&&value=54')
            .then(
            function success(response) {
                $scope.thuCamOns = angular.copy(response.data);
                angular.forEach($scope.thuCamOns, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetGocCuois() {
        $http.get('/API/PostAPI?att=postHome&&value=55')
            .then(
            function success(response) {
                $scope.gocCuois = angular.copy(response.data);
                angular.forEach($scope.gocCuois, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetDanhChoNguoiBenhs() {
        $http.get('/API/PostAPI?att=postHome&&value=56')
            .then(
            function success(response) {
                $scope.danhChoNguoiBenhs = angular.copy(response.data);
                angular.forEach($scope.danhChoNguoiBenhs, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    function GetCacQuyTrinhs() {
        $http.get('/API/PostAPI?att=postHome&&value=57')
            .then(
            function success(response) {
                $scope.cacQuyTrinhs = angular.copy(response.data);
                angular.forEach($scope.cacQuyTrinhs, function (value, index) {
                    if (value.description != null) {
                        value.description = (value.description.length > 120) ? CutString(value.description, 122) : value.description;
                    }
                });
            },
            function error(response) {

            }
            );
    }

    //FUNCTIONe
    function CutString(input, limit) {
        var output = angular.copy(input);
        var index = angular.copy(limit - 1);

        while ((output[index] != ' ') && index < (output.length - 1)) {
            index++;
        }

        return (output.substring(0, index) + "...");
    }



}]);