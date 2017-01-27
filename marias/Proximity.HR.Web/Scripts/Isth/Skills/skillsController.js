app.controller('skillsController',
    ['$scope', '$rootScope', '$modal', '$log', 'skillsService', '$timeout', '$window',
function ($scope, $rootScope, $modal, $log, skillsService, $timeout, $window) {
    $scope.SelectFeature = 0;
    $scope.technologyName = "name";
    $scope.technologyDescription = "decription";
    $scope.IsFormSubmitted = false;
    $scope.IsFormValid = false;
    $scope.allowEdition = true;
    $scope.lockSectionClass = 'SectionLockOff';
    $scope.$watch("technologyForm.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    // 1) Load Technologiess 

    $rootScope.LoadTechnologiesFeatures = function () {
        var promise = skillsService.GetTechnologies();
        promise.success(function (response) {
            if (response.Status === 1) {

                $scope.Technologiess = response.Response;
            } else {
                $scope.error = "Error";
            }
        });
        promise.error(function (data, status, headers, config) {
        });
    };

    //tech selected

    $scope.TechSelected = function () {
        $timeout(loadTechnology, 1);
    };


    //save technology
    $scope.saveTechnology = function () {
        $scope.IsFormSubmitted = true;
        if ($scope.IsFormValid) {
            $scope.lockSectionClass = 'SectionLockOn';

            var promise = skillsService.SaveTechnology($scope.TechnologyId, $scope.Technology);
            promise.success(function (response) {
                if (response.Status === 1) {
                    $timeout(function () {

                        // Clear inputs ============================================================================
                        $scope.IsFormSubmitted = false;
                        $scope.Technology.Name = "";
                        $scope.Technology.Detail = "";
                        $scope.Technology.Features = "";

                        $scope.lockSectionClass = 'SectionLockOff';
                        swal("Great", "Data successfully processed!", "success");
                        $rootScope.LoadTechnologies();
                    }, 1);
                } else {
                    $timeout(function () {
                        $scope.lockSectionClass = 'SectionLockOff';
                        swal("Oops...", "Something went wrong!", "error");

                        $rootScope.LoadTechnologies();
                    }, 1);
                }


                $scope.allowEdition = true;
                $rootScope.LoadTechnologies();
            });

            promise.error(function (data, status, headers, config) {
                $timeout(function () {
                    $scope.lockSectionClass = 'SectionLockOff';
                    swal("Oops...", "Something went wrong!", "error");
                    $rootScope.LoadTechnologies();
                }, 1);
            });
            $scope.allowEdition = true;
        }
    };


    //LoadTechnology
    function loadTechnology () {
        $scope.allowEdition = false;
        $scope.Technology = $scope.selectedTechnology.originalObject;
        $scope.TechnologyId = $scope.selectedTechnology.originalObject.Id;
    };

    //2) add new button

    $scope.AddNew = function () {

        $scope.allowEdition = false;
        $scope.Technology = { "Id": 0, "Name": "", "Detail": "", "Enabled": null, "CreatedBy": "", "CreatedDate": null, "EditedBy": "", "EditedDate": null, "Features": [] };
        $scope.TechnologyId = 0;
        var element = $window.document.getElementById("txtTechnologyName");
        if (element)
            element.focus();
    };

    $scope.animationsEnabled = true;

    $scope.open = function (size, enabled) {
        var modalInstance = $modal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                features: function () {
                    return $scope.Technology.Features;
                },
                Selected: function () {
                    return $scope.currentItems;
                },
                allowEdit: function () { return enabled; },
                newFeature: function () {
                    $scope.Feature = { "Name": "", "Detail": "", "Enabled": null, "CreatedBy": "", "CreatedDate": null, "EditedBy": "", "EditedDate": null };

                    return $scope.Feature;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });

    };

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
        if ($scope.currentItems !== null) {
            console.log($scope.currentItems);

            console.log($scope.currentItems[0]);

            var index = $scope.Technology.Features.indexOf($scope.currentItems[0]);
            $scope.Technology.Features.splice(index, 1);        }
    };
}]);