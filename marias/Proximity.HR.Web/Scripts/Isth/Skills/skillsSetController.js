﻿app.controller('skillsSetController',
    ['$scope', '$rootScope', '$modal', '$log', 'skillsSetService', '$timeout', '$window', 
function ($scope, $rootScope, $modal, $log, skillsSetService, $timeout, $window) {
    $scope.SelectFeature = 0;
    $scope.technologyName = "name";
    $scope.technologyDescription = "decription";
    $scope.IsFormSubmitted = false;
    $scope.IsForm2Submitted = false;
    $scope.IsFormValid = false;
    $scope.allowEdition = true;
    $scope.editedby = 'Admin';
    $scope.filteredTechnologies = [];
    $scope.someFeat = [];
    $scope.currentPage = 1;
    $scope.numPerPage = 10;
    $scope.maxSize = 10;
    $scope.lockSectionClass = 'SectionLockOff';
    $scope.FeaturesModel = { "Technology": 0, "Name": "", "Detail": "", "Enabled": null, "CreatedBy": "", "CreatedDate": null, "EditedBy": "", "EditedDate": null };
    $scope.Featuress = $scope.FeaturesModel;
    $scope.$watch("EmployeeTechFeatureLstForm.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    //create pagination============================================================
    function createPaging() {
        $scope.$watch("currentPage + numPerPage", function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = begin + $scope.numPerPage;

            $scope.filteredTechnologies = $scope.Technologies.slice(begin, end);
            //console.log($scope.filteredTechnologies);
        });
    }
    
    //==================================Add tech feat
    $scope.addTechFeat = function (id, rate, isDesirable, isTeachable) {
        var data = {
            Employee: $scope.EmployeeID,
            Feature: id,
            Teachable: isTeachable,
            Desirable: isDesirable,
            Detail: "",
            Enabled: 1,
            CreatedBy: "admin",
            CreatedDate: new Date(),
            EditedBy: "admin",
            EditedDate: null,
            Level: rate
        };
        $scope.TechnologyFeatureList[id] = data;
        $scope.allowEdition = false;
    };

    //load technologies===============================================================
    $rootScope.LoadTechnologies = function () {
        if ($rootScope.EmployeeID !== "undefined") {
            console.log("Tecnologies loading ...");
            var promise = skillsSetService.GetTechnologies($rootScope.EmployeeID);
            promise.success(function (response) {
                if (response.Status == 1) {
                    console.log("Tecnologies loading success");
                    $scope.Technologies = response.Response;
                    //console.log($scope.Technologies);
                    createPaging();
                } else {
                    $scope.error = "Error";
                    console.log("Tecnologies loading error");
                }
            });
            promise.error(function (data, status, headers, config) {
            });
        }
    };

    /*======================================== load features ========================================*/
    $rootScope.loadFeatures = function () {
        var promise = skillsSetService.GetFeatures();
        promise.success(function (response) {
            if (response.Status === 1) {
                console.log("features are loading!");
                $rootScope.FeatList = response.Response;
                //console.log($scope.FeatList);
                // calling this shit
                $scope.featExist($scope.FeatList);
                createPaging();
            } else {
                console.error('features didnt load');
            }
        });

        promise.error(function (data, status, headers, config) { });
    };

    // Does the feature already exist ? ============================================
    $scope.featExist = function (feat) {
        $scope.someFeat = feat;
        $scope.someFeat.forEach(function (ft) {
            //console.log('ft name: ' + ft.Name);
            return ft.Name;
        });
    }

    console.log('HEREEEEEEE ' + $rootScope.FeatList);

    $rootScope.loadFeatures(); // calling the function

    

/*======================================SAVE FEATURE()====================================================*/
    $scope.saveFeature = function (id) {
        $scope.Featuress.Technology = id;
        if ($scope.Featuress.Name !== "") {
            // foreach
            console.log(`returning ft.Name ${$scope.featExist($rootScope.FeatList)}`);
            //if $scope.Features.Name !== $scope.FeatList.Name
            var data = [$scope.Featuress.Technology, $scope.Featuress.Name, $scope.Featuress.Detail];
            var promise = skillsSetService.PostFeature($scope.Featuress);
            promise.success(function (response) {
                if (response.Status == 1) {
                    $timeout(function () {
                        $scope.Featuress.Name = "";
                        $scope.Featuress.Detail = "";
                        swal("Great", "Data successfully processed!", "success");
                        $rootScope.LoadEmployees();
                    }, 1);
                } else {
                    $timeout(function () {
                        swal("Oops...", "Something went wrong!", "error");
                        console.log(data);
                    }, 1);
                }
                $rootScope.LoadTechnologies();
            });

            promise.error(function (data, status, headers, config) {
                $timeout(function () {
                    swal("Oops...", "Request Failed", "error");
                    console.log(data);
                }, 1);
            });
        } else {
            $timeout(function () {
                swal("Oops...", "Seems like feature name is empty", "error");
            }, 1);
        }
    };

    //save()=======================================================================
    $scope.saveEmployeeTechFeatureLst = function () {
        $scope.IsFormSubmitted = true;

        if ($scope.IsFormValid) {
            $scope.lockSectionClass = 'SectionLockOn';
            var features = $scope.TechnologyFeatureList;
            var data = [];
            for (var feat in features) {
                data.push(features[feat]);
            }
            var promise = skillsSetService.SaveEmployeeTechFeatureLst(data);
            promise.success(function (response) {
                if (response.Status == 1) {
                    $timeout(function () {
                        $scope.lockSectionClass = 'SectionLockOff';
                        swal("Great", "Data successfully processed!", "success");
                        $rootScope.LoadEmployees();
                    }, 1);
                } else {
                    $timeout(function () {
                        $scope.lockSectionClass = 'SectionLockOff';
                        swal("Oops...", "Something went wrong!", "error");
                        console.log(data);
                    }, 1);
                }
                $scope.allowEdition = true;
                LoadTechnologies();
            });

            promise.error(function (data, status, headers, config) {
                $timeout(function () {
                    $scope.lockSectionClass = 'SectionLockOff';
                    swal("Oops...", "Something went wrong!", "error");
                    console.log(data);
                }, 1);
            });
            $scope.allowEdition = true;
        }
    };

    $scope.animationsEnabled = true;

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    $scope.yesNoFlag = function (val) {
        if (val) {
            return "Yes";
        }
        else {
            return "No";
        }
    };

    $scope.yesNoColor = function (val) {
        if (val) {
            return "#381ad0";
        }
        else {
            return "#4f4d4d";
        }
    };

    $scope.setActiveSkill = function (num) {
        $scope.SelectFeature = num;
    };

    $scope.deleteFeature = function () {
        if ($scope.currentItems != null) {
            console.log($scope.currentItems);

            console.log($scope.currentItems[0]);

            $scope.Technology.Features.splice($scope.currentItems[0], 1);
        }
    };
}]);






