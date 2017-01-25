
var app;

(function () {
    app = angular.module("isthMeApp");
})();


app.controller("employeeController",
                ['$scope', '$cookies', '$timeout', '$rootScope', '$window',
                 '$http', 'employeeService', 'GeneralDataService', '$interval',
       function ($scope, $cookies, $timeout, $rootScope, $window,
                 $http, employeeService, GeneralDataService, $interval) {

           $scope.date = new Date();
           $scope.MyName = "IsthMe";
           $scope.showEmployeeAdd = true;
           $scope.addEditEmployees = false;
           $scope.employeesList = true;
           $scope.showItem = true;
           $scope.lockSectionClass = 'SectionLockOff';
           //Form Validation
           $scope.Message = "";
           $scope.IsFormSubmitted = false;
           $scope.IsFormValid = false;

           $rootScope.initEmployeeCtrl = function (userName) {
               GetEmployees();
               loadEmployeeByName(userName);
           };

           $rootScope.LoadEmployees = function () {
               GetEmployees();
           };

           var GetEmployees = function () {
               var promiseEmp = employeeService.GetEmployees();
               promiseEmp.success(function (response) {
                   if (response.Status === 1) {
                       $scope.Employees = response.Response;

                   } else {
                       $scope.error = "An Error has occured while loading employees!";
                   }
               });
           };

           $scope.myFunc = function (test) {
               $timeout(callAtInterval, 1);
           };

           function callAtInterval() {
               loadEmployeeById($scope.selectedCountry.originalObject.Id);
           };

           //Search
           $scope.searchEmployeeDetails = function () {
               selectEmployeeDetails($scope.employeeId);
           };

           $scope.$watch("f1.$valid", function (isValid) {
               $scope.IsFormValid = isValid;
           });

           //===========================================Save employee
           $scope.saveDetails = function () {
               var obj = scopeToEmployeeObj();
               console.log(`obj is ${obj}`);

               $scope.IsFormSubmitted = true;
               //$scope.IsFormValid = true;

               if ($scope.IsFormValid) {
                   $scope.lockSectionClass = 'SectionLockOn';

                   console.log($scope.employeeId);
                   if ($scope.employeeId === 0) {
                       $http.post('/api/employee/PostEmployee/', obj).success(function (data) {
                           if (data.Status === 1) {
                               $timeout(function () {
                                   $scope.lockSectionClass = 'SectionLockOff';
                                   //alert("Data successfully processed!");
                                   swal("Great", "Data successfully processed!", "success");
                                   $scope.employeesInserted = data;
                                   $('#ex1_value').val('');
                                   GetEmployees();
                               }, 1);
                           } else {
                               $timeout(function () {
                                   $scope.lockSectionClass = 'SectionLockOff';
                                   //alert("An Error has occured!");
                                   swal("Oops...", "Something went wrong with the db!", "error");
                                   $rootScope.LoadEmployees();
                               }, 1);
                           }
                       }).error(function () {
                           $timeout(function () {
                               $scope.lockSectionClass = 'SectionLockOff';
                               //alert("An Error has occured!");
                               swal("Oops...", "Request failed", "error");
                               $rootScope.LoadEmployees();
                           }, 1);
                       });
                   }
                   else {
                       $http.post('api/employee/UpdateEmployee/', obj).success(function (data) {
                           if (data.Status === 1) {
                               $timeout(function () {
                                   $scope.lockSectionClass = 'SectionLockOff';
                                   //alert("Data successfully processed!");
                                   swal("Great", "Data successfully processed!", "success");
                                   $scope.employeesInserted = data;
                                   $('#ex1_value').val('');
                                   GetEmployees();
                               }, 1);
                           } else {
                               $timeout(function () {
                                   $scope.lockSectionClass = 'SectionLockOff';
                                   //alert("An Error has occured!");
                                   swal("Oops...", "Something went wrong!", "error");
                                   $rootScope.LoadEmployees();
                               }, 1);
                           }
                       })
               .error(function () {
                   $timeout(function () {
                       $scope.lockSectionClass = 'SectionLockOff';
                       //alert("An Error has occured!");
                       swal("Oops...", "Something went wrong!", "error");
                       $rootScope.LoadEmployees();
                   }, 1);
               });
                   }

               }
               else {
                   $scope.Message = "All the fields are required.";
               }
           }

           $scope.newPassportVisaSelected = function (model) {
                              var id, Value;
               if (model === 'employeeHasVisa') {
                   id = ['txtEmpVisaExpeditionDate', 'txtEmpVisaExpirationDate'];
                   value = $scope.employeeHasVisa;
               } else if (model === 'employeeHasLicense') {
                   id = ['txtEmpLicenseExpeditionDate', 'txtEmpLicenseExpirationDate'];
                   value = $scope.employeeHasLicense;
               } else if (model === 'employeeHasPassport') {
                   id = ['employeePassportExpeditionDate', 'employeePassportExpirationDate'];
                   value = $scope.employeeHasPassport;
                }

               for (i = 0 ; i < id.length ;i++)
               {
                   var datepicker = $("#" + id[i]).data("kendoDatePicker");
                   datepicker.readonly(!value);
               }
           }

           function scopeToEmployeeObj() {
               var obj = {
                   Id: $scope.employeeId,
                   EmployeeNumber: $scope.employeeNumber,
                   UserId: $scope.employeeUserId,
                   Name: $scope.employeeName,
                   FirstLastName: $scope.employeeFirstLastName,
                   SecondLastName: $scope.employeeSecondLastName,
                   Gender: $scope.employeeGender,
                   Dependents: $scope.employeeDependents,
                   MaritalStatus: $scope.employeeMaritalStatus,
                   BirthDate: $scope.employeeBirthDate,
                   StartDate: $scope.employeeStartDate,
                   EndDate: $scope.employeeEndDate,
                   EndReason: $scope.employeeEndReason,
                   Nationality: $scope.employeeNationality,
                   Detail: $scope.employeeDetail,
                   PrimaryPhoneNumber: $scope.employeePrimaryPhoneNumber,
                   SecundaryPhoneNumber: $scope.employeeSecundaryPhoneNumber,
                   EmergencyPhoneNumber: $scope.employeeEmergencyPhoneNumber,
                   EmergencyContact: $scope.employeeEmergencyContact,
                   PersonalEmail: $scope.employeePersonalEmail,
                   NotificationsEmail: $scope.employeeNotificationsEmail,
                   Schooling: $scope.employeeSchooling,
                   Country: $scope.employeeCountry,
                   State: $scope.employeeState,
                   City: $scope.employeeCity,
                   District: $scope.employeeDistrict,
                   Address: $scope.employeeAddress,
                   Picture: $scope.employeePicture,
                   HasPassport: $scope.employeeHasPassport,
                   PassportNumber: $scope.employeePassportNumber,
                   PassportIssueCity: $scope.employeePassportIssueCity,
                   PassportExpeditionDate: $scope.employeePassportExpeditionDate,
                   PassportExpirationDate: $scope.employeePassportExpirationDate,
                   HasVisa: $scope.employeeHasVisa,
                   VisaNumber: $scope.employeeVisaNumber,
                   VisaIssueCity: $scope.employeeVisaIssueCity,
                   VisaExpeditionDate: $scope.employeeVisaExpeditionDate,
                   VisaExpirationDate: $scope.employeeVisaExpirationDate,
                   HasLicense: $scope.employeeHasLicense,
                   LicenseNumber: $scope.employeeLicenseNumber,
                   LicenseExpeditionDate: $scope.employeeLicenseExpeditionDate,
                   LicenseExpirationDate: $scope.employeeLicenseExpirationDate,
                   Enabled: $scope.employeeEnabled,
                   Identification: $scope.employeeIdentification,
                   CreatedBy: "Carce"
               };
               return obj;
           };

           function employeeObjToScope(data) {
               console.log('Data' + ' ' + data);
               if (data.Response.length < 1) {
                   console.log('Employee has not been included ...');
                   return;
               }
               $scope.employeeId = data.Response[0].Id;
               $rootScope.EmployeeID = data.Response[0].Id;
               $scope.employeeUserId = data.Response[0].UserId;
               $scope.employeeNumber = data.Response[0].EmployeeNumber;
               $scope.employeeName = data.Response[0].Name;
               $scope.employeeFirstLastName = data.Response[0].FirstLastName;
               $scope.employeeSecondLastName = data.Response[0].SecondLastName;
               $scope.employeeGender = data.Response[0].Gender;
               $scope.employeeDependents = data.Response[0].Dependents;
               $scope.employeeMaritalStatus = data.Response[0].MaritalStatus;
               $scope.employeeBirthDate = new Date(data.Response[0].BirthDate);
               $scope.employeeStartDate = new Date(data.Response[0].StartDate);
               $scope.employeeEndDate = new Date(data.Response[0].EndDate);
               $scope.employeeEndReason = data.Response[0].EndReason;
               $scope.employeeNationality = data.Response[0].Nationality;
               $scope.employeeDetail = data.Response[0].Detail;
               $scope.employeePrimaryPhoneNumber = data.Response[0].PrimaryPhoneNumber;
               $scope.employeeSecundaryPhoneNumber = data.Response[0].SecundaryPhoneNumber;
               $scope.employeeEmergencyPhoneNumber = data.Response[0].EmergencyPhoneNumber;
               $scope.employeeEmergencyContact = data.Response[0].EmergencyContact;
               $scope.employeePersonalEmail = data.Response[0].PersonalEmail;
               $scope.employeeNotificationsEmail = data.Response[0].NotificationsEmail;
               $scope.employeeSchooling = data.Response[0].Schooling;
               $scope.employeeCountry = data.Response[0].Country;
               $scope.employeeState = data.Response[0].State;
               $scope.employeeCity = data.Response[0].City;
               $scope.employeeDistrict = data.Response[0].District;
               $scope.employeeAddress = data.Response[0].Address;
               $scope.employeeHasPassport = data.Response[0].HasPassport;
               $scope.employeePassportNumber = data.Response[0].PassportNumber;
               $scope.employeePassportIssueCity = data.Response[0].PassportIssueCity;
               $scope.employeePassportExpeditionDate = new Date(data.Response[0].PassportExpeditionDate);
               $scope.employeePassportExpirationDate = new Date(data.Response[0].PassportExpirationDate);
               $scope.employeeHasVisa = data.Response[0].HasVisa;
               $scope.employeeVisaNumber = data.Response[0].VisaNumber;
               $scope.employeeVisaIssueCity = data.Response[0].VisaIssueCity;
               $scope.employeeVisaExpeditionDate = new Date(data.Response[0].VisaExpeditionDate);
               $scope.employeeVisaExpirationDate = new Date(data.Response[0].VisaExpirationDate);
               $scope.employeeHasLicense = data.Response[0].HasLicense;
               $scope.employeeLicenseNumber = data.Response[0].LicenseNumber;
               $scope.employeeLicenseExpeditionDate = new Date(data.Response[0].LicenseExpeditionDate);
               $scope.employeeLicenseExpirationDate = new Date(data.Response[0].LicenseExpirationDate);
               $scope.employeeEnabled = data.Response[0].Enabled;
               $scope.employeeIdentification = data.Response[0].Identification;

               $rootScope.LoadTechnologies();
               $rootScope.LoadTechnologiesFeatures();
           };

           function selectEmployeeDetails(employeeNumber) {

               $http.get('/api/employee/GetEmployeeById/', { params: { employeeId: employeeNumber } })
                   .success(function (data) {
                       employeeObjToScope(data);
                       $scope.showemployeeAdd = true;
                       $scope.addEditemployees = false;
                       $scope.employeesList = true;
                       $scope.showItem = true;

                   })
                  .error(function () {
                      $scope.error = "An Error has occured while loading Employee!";
                  });
           }

           function getCountries() {
               var promise = GeneralDataService.GetCountries();
               promise.success(function (response) {
                   if (response.Status === 1) {
                       $scope.countries = response.Response;
                       getStates();

                   } else {
                       $scope.error = "An Error has occured while loading Countries!";
                       $scope.countries = null;
                   }
               });
           }

           $scope.getStatesModel = function () {
               getStates();
           };

           function getStates() {
               if ($scope.employeeCountry) {
                   var promise = GeneralDataService.GetStates($scope.employeeCountry);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           $scope.states = response.Response;
                           getCities();
                       } else {
                           $scope.error = "An Error has occured while loading States!";
                           $scope.states = null;
                       }
                   });
               }
               else {
                   $scope.states = null;
               }
           }

           $scope.getCitiesModel = function () {
               getCities();
           }

           function getCities() {
               if ($scope.employeeState) {
                   var promise = GeneralDataService.GetCities($scope.employeeState);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           $scope.cities = response.Response;
                           getDistricts();
                       } else {
                           $scope.error = "An Error has occured while loading Cities!";
                           $scope.cities = null;
                       }
                   });
               }
               else {
                   $scope.cities = null;
               }
           }

           function getAllCities() {
               var promise = GeneralDataService.GetAllCities();
               promise.success(function (response) {
                   if (response.Status === 1) {
                       $scope.allCities = response.Response;
                   } else {
                       $scope.error = "An Error has occured while loading Cities!";
                       $scope.allCities = null;
                   }
               });

           }

           $scope.getDistrictsModel = function () {
               getDistricts();
           };

           function getDistricts() {
               if ($scope.employeeCity) {
                   var promise = GeneralDataService.GetDistricts($scope.employeeCity);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           $scope.districts = response.Response;

                       } else {
                           $scope.error = "An Error has occured while loading Districts!";
                           $scope.districts = null;
                       }
                   });
               }
               else {
                   $scope.districts = null;
               }
           }

           function getSchooling() {
               var promise = GeneralDataService.GetSchooling();
               promise.success(function (response) {
                   if (response.Status === 1) {
                       $scope.schoolings = response.Response;
                   } else {
                       $scope.error = "An Error has occured while loading Schooling!";
                       $scope.schoolings = null;
                   }
               });
           }

           function getGenders() {
               var promise = GeneralDataService.GetGenders();
               promise.success(function (response) {
                   if (response.Status === 1) {
                       $scope.genders = response.Response;
                   } else {
                       $scope.error = "An Error has occured while loading Genders!";
                       $scope.genders = null;
                   }
               });
           }

           function getMaritalStatus() {
               var promise = GeneralDataService.GetMaritalStatus();
               promise.success(function (response) {
                   if (response.Status === 1) {
                       $scope.maritalStatuses = response.Response;
                   } else {
                       $scope.error = "An Error has occured while loading Marital Statuses!";
                       $scope.maritalStatuses = null;
                   }
               });
           }

           function loadProfileDatePickers() {
               $("#txtEmpVisaExpeditionDate").kendoDatePicker({format:"yyyy-MM-dd"});
               $("#txtEmpVisaExpirationDate").kendoDatePicker({ format: "yyyy-MM-dd" });

               $("#txtEmpLicenseExpeditionDate").kendoDatePicker({ format: "yyyy-MM-dd" });
               $("#txtEmpLicenseExpirationDate").kendoDatePicker({ format: "yyyy-MM-dd" });

               $("#employeePassportExpeditionDate").kendoDatePicker({ format: "yyyy-MM-dd" });
               $("#employeePassportExpirationDate").kendoDatePicker({ format: "yyyy-MM-dd" });

               $scope.newPassportVisaSelected("employeeHasVisa");
               $scope.newPassportVisaSelected("employeeHasLicense");
               $scope.newPassportVisaSelected("employeeHasPassport");
           }

           function loadEmployeeByName(userName) {
               if (userName !== null) {
                   var promise = employeeService.GetEmployeeByName(userName);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           employeeObjToScope(response);
                       } else {
                           $scope.error = "An Error has occured while loading employee!";
                       }

                       loadGeneralData();
                   });
               }
           };

           function loadEmployeeById(id) {
               if (id !== null) {
                   var promise = employeeService.GetEmployeeById(id);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           employeeObjToScope(response);
                       } else {
                           $scope.error = "An Error has occured while loading employee!";
                       }

                       loadGeneralData();
                   });
               }
           };

           function loadGeneralData() {
               getCountries();

               getGenders();

               getMaritalStatus();

               getSchooling();

               getAllCities();

               loadProfileDatePickers();
           };

           function loadEmployeeByNameCopy(userName) {
               var userInfo = $cookies.get('userData');
               if (userInfo !== null) {
                   var promise = employeeService.GetEmployeeByName(userInfo);
                   promise.success(function (response) {
                       if (response.Status === 1) {
                           employeeObjToScope(response);
                           getStates2();
                       } else {
                           console.log(response);
                           $scope.error = "An Error has occured while loading employee!";
                       }
                   });
               }
           };

       }]);

app.directive('accordeonShow', function () {
    return {
        restrict: 'A',
        link: function (scope, elem) {
            elem.on('submit', function () {
                var firstInvalid = elem[0].querySelector('span.error:not(.ng-hide)');
                if (firstInvalid) {
                    console.log(firstInvalid);
                    $(firstInvalid).closest('.panel-collapse').collapse('show');
                    firstInvalid.focus();
                }
            });
        }
    };
});

app.run(function ($rootScope) {
    /*$rootScope.hello = function () {
        console.log('hello Carce');
    }*/
});

