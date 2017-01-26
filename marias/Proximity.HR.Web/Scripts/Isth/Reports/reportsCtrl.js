//Reference: http://docs.telerik.com/kendo-ui/api/javascript/ui/grid#configuration-columns.filterable

app.controller('reportsCtrl', ['$scope', '$rootScope', 'reportsService', '$timeout', '$window', '$http', '$route', '$routeParams', '$location',
function ($scope, $rootScope, reportsService, $timeout, $window, $http, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;

    var monthDataSource = new kendo.data.DataSource({
        data: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
    });

    var monthChangeFilter = function(value, filterField, grid) {
        if (value) {
            grid.data("kendoGrid").dataSource.filter({
                field: filterField,
                operator: function (fieldDate) {
                    var month;
                    switch (value) {
                        case "January":
                            month = 0;
                            break;
                        case "February":
                            month = 1;
                            break;
                        case "March":
                            month = 2;
                            break;
                        case "April":
                            month = 3;
                            break;
                        case "May":
                            month = 4;
                            break;
                        case "June":
                            month = 4;
                            break;
                        case "July":
                            month = 6;
                            break;
                        case "August":
                            month = 7;
                            break;
                        case "September":
                            month = 8;
                            break;
                        case "October":
                            month = 9;
                            break;
                        case "November":
                            month = 10;
                            break;
                        case "December":
                            month = 11;
                            break;
                        default:
                    }

                    var result;

                    if (typeof fieldDate.getMonth === 'function') {
                        var parsedFieldDate = fieldDate.getMonth();
                        result = (parsedFieldDate === month);
                    } else {
                        result = false;
                    }

                    return result;
                }
            });
        } else {
            grid.data("kendoGrid").dataSource.filter({});
        }
    }

    /*======================================== report features by expertise ========================================*/
    $scope.reportFeatByExpertise = function () {
        var promise = reportsService.GetFeaturesByExpertise();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("features' report is loading!");
                $scope.reportFeatExpertise = response.Response;
                //console.log($scope.reportFeatExpertise);
                var featGrid = $("#featGrid").kendoGrid({
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
                        mode: "row"
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
                        width: "120px",
                        filterable: {
                            cell: {
                                template: function (args) {
                                    args.element.kendoDropDownList({
                                        dataSource: args.dataSource,
                                        dataTextField: "LEVEL",
                                        dataValueField: "LEVEL",
                                        valuePrimitive: true
                                    });
                                }
                            }
                        }
                    }]
                });// kendo grid            

            } else {
                console.error('features by expertise report didnt load');
            }
        });

        promise.error(function (data, status, headers, config) { });
    };

    $scope.reportFeatByExpertise(); // calling the  function

    /*======================================== report average working years ========================================*/

    var months = new kendo.data.DataSource({
        data: [
            { name: "January", value: 1},
            { name: "February", price: 2 },
            { name: "March", price: 3 }
        ]
    });

    $scope.averageWYReport = function () {
        var promise = reportsService.GetAverageWYReport();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("Generating average working years report now...");
                $scope.aWYR = response.Response;
                //console.log($scope.aWYR);
                var avwyGrid = $("#avwyGrid").kendoGrid({
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
                            cell: {
                                enabled: false
                            }
                        },
                        headerTemplate: kendo.template($("#monthRangeFilter").html())
                       
                    }, {
                        field: "working_years",
                        title: "Working years",
                        width: "120px"
                    }]
                });// kendo grid
                var averageReport = avwyGrid.find("#monthRange").kendoDropDownList({
                    autoBind: false,
                    optionLabel: "Birth Date",
                    dataSource: monthDataSource,
                    change: function () {
                        var value = this.value();
                        monthChangeFilter(value, "started_on", avwyGrid);
                    }
                });
               
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
                            ui: function (element) {
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
                var agesGrid = $("#agesGrid").kendoGrid({
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
                                    BirthDate: { type: 'date' }
                                }
                            }
                        },
                        pageSize: 7
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
                        headerTemplate: kendo.template($("#monthRangeFilter").html())
                    }, {
                        field: "Age",
                        title: "Age",
                        width: "120px",
                        headerTemplate: kendo.template($("#ageRangeFilter").html()),
                        sortable: false
                    }]
                });// kendo grid

                var monthDropDown = agesGrid.find("#monthRange").kendoDropDownList({
                    autoBind: false,
                    optionLabel: "Birth Date",
                    dataSource: monthDataSource,
                    change: function () {
                        var value = this.value();
                        monthChangeFilter(value, "BirthDate", agesGrid);
                    }
                });

                var agedropDown = agesGrid.find("#ageRange").kendoDropDownList({
                    autoBind: false,
                    optionLabel: "Age",
                    dataSource: ["18-25", "26-30", "31-40", "41-50", "51-65"],
                    change: function () {
                        var value = this.value();
                        if (value) {
                            var ageRange = value.split("-");

                            agesGrid.data("kendoGrid").dataSource.filter({
                                logic: "and",
                                filters: [
                                    { field: "Age", operator: "gt", value: parseInt(ageRange[0]) },
                                    { field: "Age", operator: "lt", value: parseInt(ageRange[1]) }
                                ]
                            });
                        } else {
                            agesGrid.data("kendoGrid").dataSource.filter({});
                        }
                    }
                });

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
                var edGrid = $("#edGrid").kendoGrid({
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
                    pageable: true,
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [{
                        field: "Person",
                        title: "Person",
                        width: "200px",
                        filterable: false
                    }, {
                        field: "Passport",
                        title: "Passport",
                        width: "280px",
                        format: "{0:MM/dd/yyyy}",
                        headerTemplate: kendo.template($("#ExpDatesFilterPassport").html())
                    }, {
                        field: "License",
                        title: "License",
                        width: "280px",
                        format: "{0:MM/dd/yyyy}",
                        headerTemplate: kendo.template($("#ExpDatesFilterLicense").html())
                    }, {
                        field: "Visa",
                        title: "Visa",
                        width: "280px",
                        format: "{0:MM/dd/yyyy}",
                        headerTemplate: kendo.template($("#ExpDatesFilterVisa").html())
                    }]
                }).data("kendoGrid");// kendo grid



                $("#from, #to,#from1, #to1,#from2, #to2").kendoDatePicker({});
                $("#filterPassport").on("click", function () {
                    var isfrom = $("#from").data("kendoDatePicker").value();
                    var isto = $("#to").data("kendoDatePicker").value();
                    if (isfrom && isto) {
                        var filter = [
                        { field: "Passport", operator: "gte", value: isfrom },
                        { field: "Passport", operator: "lte", value: isto }
                        ];
                        edGrid.dataSource.filter(filter);
                    } else {
                        edGrid.dataSource.filter({});
                    }

                });
                $("#filterLicense").on("click", function () {
                    var isfrom = $("#from1").data("kendoDatePicker").value();
                    var isto = $("#to1").data("kendoDatePicker").value();
                    if (isfrom && isto) {
                        var filter = [
                        { field: "License", operator: "gte", value: isfrom },
                        { field: "License", operator: "lte", value: isto }
                        ];
                        edGrid.dataSource.filter(filter);
                    } else {
                        edGrid.dataSource.filter({});
                    }
                });
                $("#filterVisa").on("click", function () {
                    var isfrom = $("#from2").data("kendoDatePicker").value();
                    var isto = $("#to2").data("kendoDatePicker").value();
                    if (isfrom && isto) {
                        var filter = [
                        { field: "Visa", operator: "gte", value: isfrom },
                        { field: "Visa", operator: "lte", value: isto }
                        ];
                        edGrid.dataSource.filter(filter);
                    } else {
                        edGrid.dataSource.filter({});
                    }

                });
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


