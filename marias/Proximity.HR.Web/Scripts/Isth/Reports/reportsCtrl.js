﻿app.controller('reportsCtrl', ['$scope', '$rootScope', 'reportsService', '$timeout', '$window', '$http', '$route', '$routeParams', '$location',
function ($scope, $rootScope, reportsService, $timeout, $window, $http, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
    /*======================================== report features by expertise ========================================*/
    $scope.reportFeatByExpertise = function () {
        var promise = reportsService.GetFeaturesByExpertise();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("features' report is loading!");
                $scope.reportFeatExpertise = response.Response;
                //console.log($scope.reportFeatExpertise);
                $scope.featGrid = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "Features Report.xlsx",
                        proxyURL: $scope.reportFeatExpertise,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.reportFeatExpertise);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    EMPLOYEE: { type: "string" },
                                    FEATURE: { type: "string" },
                                    LEVEL: { type: "string" }
                                }
                            }
                        },
                        pageSize: 7,
                    },
                   
                    filterable: {
                        mode: "row",
                        extra: false,
                        operators: {
                            string: {
                                contains: "contains"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "EMPLOYEE",
                        title: "Person",
                        width: "120px"
                    }, {
                        field: "FEATURE",
                        title: "Feature",
                        width: "120px"
                    }, {
                        field: "LEVEL",
                        title: "Level",
                        width: "120px"
                    }]
                };// kendo grid
            } else {
                console.error('features by expertise report didnt load');
            }
        });

        promise.error(function (data, status, headers, config) { });
    };

    $scope.reportFeatByExpertise(); // calling the  function

    /*======================================== report average working years ========================================*/

    $scope.averageWYReport = function () {
        var promise = reportsService.GetAverageWYReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating average working years report now...");
                $scope.aWYR = response.Response;
                //console.log($scope.aWYR);
                $scope.avwyGrid = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "average working years Report.xlsx",
                        proxyURL: $scope.aWYR,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.aWYR);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    name: { type: "string" },
                                    started_on: { type: "date" },
                                    working_years: { type: "number" }
                                }
                            }
                        },
                        pageSize: 7
                    },
                    filterable: {
                        mode: "row",
                        extra: false,
                        operators: {
                            string: {
                                contains: "contains"
                            },
                            number: {
                                eq: "Is equal to"
                            },
                            date: {
                                eq: "Is equal to",
                                gte: "Is after or equal to",
                                gt: "Is after",
                                lte: "Is before or equal to",
                                lt: "Is before"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "name",
                        title: "Person",
                        width: "120px"
                    }, {
                        field: "started_on",
                        title: "Started On",
                        width: "120px",
                        format: "{0:MM/dd/yyyy}",
                        filterable: {
                            ui: "datepicker"
                        }
                    }, {
                        field: "working_years",
                        title: "Working years",
                        width: "120px"
                    }]
                };// kendo grid
            } else {
                console.error("awyr report didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.averageWYReport();
    /*======================================== report marital staus ========================================*/

    $scope.getMaritalStatusReport = function () {
        var promise = reportsService.getMaritalStatusReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating getMaritalStatusReport now...");
                $scope.ms = response.Response;
                //console.log($scope.ms);
                $scope.msGrid = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "Marital Status Report.xlsx",
                        proxyURL: $scope.ms,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.ms);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    Person: { type: "string" },
                                    Marital_Status: { type: "string" }
                                }
                            }
                        },
                        pageSize: 7,
                    },
                
                    filterable: {
                        extra: false,
                        operators: {
                            string: {
                                eq: "equal to"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "Person",
                        title: "Person",
                        width: "120px",
                        filterable: false
                    }, {
                        field: "Marital_Status",
                        title: "Marital Status",
                        width: "120px",
                        filterable: {
                            ui: function (element) {
                                element.kendoDropDownList({
                                    dataSource: ["Soltero (a)", "Casado (a)", "Divorciado (a)", "Viudo (a)", "Union Libre", "not specified"],
                                    optionLabel: "--Select Value--"
                                });
                            }
                        }
                    }]
                };// kendo grid

            } else {
                console.error("getMaritalStatusReport report didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.getMaritalStatusReport();

    /*======================================== getDemographicsReport ========================================*/

    $scope.getDemographicsReport = function () {
        var promise = reportsService.getDemographicsReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating getDemographicsReport now...");
                $scope.dem = response.Response;
                console.log($scope.dem);

                $scope.mainGridOptions = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "Demographic Report.xlsx",
                        proxyURL: $scope.dem,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.dem);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    Person: { type: "string" },
                                    Country: { type: "string" },
                                    City: { type: "string" }
                                }
                            }
                        },
                        pageSize: 7,
                    },
                    filterable: {
                        mode: "row",
                        extra: false,
                        operators: {
                            string: {
                                contains: "contains",
                                eq: "Is equal to"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "Person",
                        title: "Person",
                        width: "120px",
                        filterable: false
                    }, {
                        field: "Country",
                        title: "Country",
                        width: "120px",
                        filterable: {
                            ui: function(element) {
                                element.kendoDropDownList({
                                    dataSource: ["Costa Rica", "Peru"],
                                    optionLabel: "--Select Value--"
                                });
                            }
                        }
                    }, {
                        field: "City",
                        width: "120px"
                    }]
                };// kendo grid
                
            } else {
                console.error("getDemographicsReport report didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.getDemographicsReport();

    /*======================================== getAgesReport ========================================*/

    $scope.getAgesReport = function () {
        var promise = reportsService.getAgesReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating getAgesReport now...");
                $scope.agesr = response.Response;
                console.log($scope.agesr);
                $scope.agesrGrid = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "ages Report.xlsx",
                        proxyURL: $scope.agesr,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.agesr);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    Person: { type: "string" },
                                    Age: { type: "number" },
                                    BirthDate: {type: 'date'}
                                }
                            }
                        },
                        pageSize: 7,
                    },
                    filterable: {
                        //mode: "row",
                        extra: false,
                        operators: {
                            number: {
                                gte: "greater than or equal to",
                                lte: "less than or equal to",
                                lt: "less than",
                                gt: "greater than",
                                eq: "equal to"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "Person",
                        title: "Person",
                        width: "120px",
                        filterable: false
                    }, {
                        field: "BirthDate",
                        title: "BirthDate",
                        width: "120px",
                        format: "{0:MM/dd/yyyy}",
                        filterable: false
                    }, {
                        field: "Age",
                        title: "Age",
                        width: "120px",
                        filterable: {
                            ui: function (element) {
                                element.kendoDropDownList({
                                    dataSource: [18, 25, 30, 35, 40, 45, 50, 55, 60 ],
                                    optionLabel: "--Select Value--"
                                });
                            }
                        }
                    }]
                };// kendo grid
            } else {
                console.error("getAgesReport report didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.getAgesReport();

    /*======================================== getExpirationDatesReport ========================================*/

    $scope.getExpirationDatesReport = function () {
        var promise = reportsService.getExpirationDatesReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating getExpirationDatesReport now...");
                $scope.ed = response.Response;
                //console.log($scope.ed);
                $scope.edGrid = {
                    toolbar: ["excel"],
                    excel: {
                        fileName: "expiration dates Report.xlsx",
                        proxyURL: $scope.ed,
                        filterable: true,
                        allPages: true
                    },
                    dataSource: {
                        transport: {
                            read: function (options) {
                                options.success($scope.ed);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    Person: { type: "string" },
                                    Passport: { type: "date" },
                                    License: { type: "date" },
                                    Visa: { type: "date" }
                                }
                            }
                        },
                        pageSize: 7,
                    },
                    
                    filterable: {
                        mode: "row",
                        extra: false,
                        operators: {
                            
                            date: {
                                eq: "Is equal to",
                                gte: "Is after or equal to",
                                gt: "Is after",
                                lte: "Is before or equal to",
                                lt: "Is before"
                            }
                        }
                    },
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "Person",
                        title: "Person",
                        width: "120px",
                        filterable: false
                    }, {
                        field: "Passport",
                        title: "Passport",
                        width: "120px",
                        format: "{0:MM/dd/yyyy}",
                        filterable: {
                            ui: "datepicker"
                        }
                    }, {
                        field: "License",
                        title: "License",
                        width: "120px",
                        format: "{0:MM/dd/yyyy}",
                        filterable: {
                            ui: "datepicker"
                        }
                    }, {
                        field: "Visa",
                        title: "Visa",
                        width: "120px",
                        format: "{0:MM/dd/yyyy}",
                        filterable: {
                            ui: "datepicker"
                        }
                    }]
                };// kendo grid
            } else {
                console.error("getExpirationDatesReport report didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.getExpirationDatesReport();


    /*======================================== avg ========================================*/

    $scope.avg = function () {
        var promise = reportsService.avg();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating avg report now...");
                $scope.avg0 = response.Response;
                //console.log($scope.avg0);
            } else {
                console.error(" avg didn't load");
            }
        });
        promise.error(function (data, status, headers, config) { });
    };
    $scope.avg();

  

}]); // end of ctrl


//}]).config(function($routeProvider, $locationProvider) {
//    $routeProvider
//     .when('/Reports#/average', {
//         templateUrl: '/Reports/AverageReport'
//     })
//    .when('/Reports#/demo', {
//        templateUrl: '/Reports/DemoReport'
//    });
//});