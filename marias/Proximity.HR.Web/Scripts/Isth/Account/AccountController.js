app.controller('AccountController',
              ['$scope', '$cookies', 'AccountService', '$timeout', '$rootScope',
     function ($scope, $cookies, AccountService, $timeout, $rootScope) {

         $scope.userObj = null;
         $scope.IsFormSubmitted = false;
         $scope.IsFormValid = false;
         $scope.lockSectionClass = 'SectionLockOff';

         $scope.$watch("userForm.$valid", function (isValid) {
             $scope.IsFormValid = isValid;
         });

         $scope.UserSelected = function () {
             $timeout(LoadUser, 1);
         };

         $scope.saveUser = function () {
             $scope.IsFormSubmitted = true;

             if ($scope.IsFormValid) {

                 $scope.lockSectionClass = 'SectionLockOn';


                 if (!$scope.selectedUser) {
                     $timeout(function () {
                         $scope.lockSectionClass = 'SectionLockOff';
                         //alert("An user account must be selected");
                         swal("Oops...", "An user account must be selected!", "error");
                     }, 1);
                     return;
                 }


                 var data = {
                     Id: 0,
                     UserName: $scope.selectedUser.originalObject.AccountName,
                     DisplayName: $scope.selectedUser.originalObject.DisplayName,
                     Password: "",
                     IsAdmin: $scope.userIsAdmin,
                     IsResource: $scope.userIsResource,
                     IsProyectManager: false,
                     Enabled: true,
                     CreatedBy: "admin",
                     CreatedDate: new Date(),
                     EditedBy: null,
                     EditedDate: null
                 };

                 if ($scope.userId !== 0) {
                     data = $scope.userObj;
                     data.IsAdmin = $scope.userIsAdmin;
                     data.IsResource = $scope.userIsResource;
                     data.EditedBy = "admin";
                     data.EditedDate = new Date();
                 }

                 var promise = AccountService.SaveUser($scope.userId, data);

                 promise.success(function (response) {
                     if (response.Status === 1) {
                         $timeout(function () {
                             $scope.lockSectionClass = 'SectionLockOff';
                             //alert("Data successfully processed!");
                             swal("Great", "Data successfully processed!", "success");
                             $rootScope.LoadEmployees();
                         }, 1);
                     } else {
                         $timeout(function () {
                             $scope.lockSectionClass = 'SectionLockOff';
                             //alert("An Error has occured!");
                             swal("Oops...", "Something went wrong!", "error");
                             $rootScope.LoadEmployees();
                         }, 1);
                     }
                 });

                 promise.error(function (data, status, headers, config) {
                     $timeout(function () {
                         $scope.lockSectionClass = 'SectionLockOff';
                         //alert("An Error has occured!");
                         swal("Oops...", "Something went wrong!", "error");
                         $rootScope.LoadEmployees();
                     }, 1);
                 });
             }
         };

         var CleanData = function () {
             $scope.userName = "";
             $scope.userIsAdmin = false;
             $scope.userIsResource = false;
         };

         var LoadUser = function () {


             if (!$scope.selectedUser) {
                 return;
             }

             CleanData();

             $scope.userName = $scope.selectedUser.originalObject.DisplayName;
             $scope.userId = 0;

             var promise = AccountService.GetUserByUserName($scope.selectedUser.originalObject.AccountName);

             promise.success(function (response) {
                 if (response.Status === 1) {
                     if (response.Response[0]) {
                         $scope.userObj = response.Response[0];
                         $scope.userIsAdmin = response.Response[0].IsAdmin;
                         $scope.userIsResource = response.Response[0].IsResource;
                         $scope.userId = response.Response[0].Id;
                     }
                 } else {
                     $scope.error = "An Error has occured while loading Countries!";
                 }
             });
         };

         $rootScope.GetUsersFromAD = function () {
             var promise = AccountService.GetUsersFromAD();

             promise.success(function (response) {
                 if (response.Status === 1) {
                     $scope.UsersFromAD = response.Response;

                 } else {
                     $scope.error = "Error";
                 }
             });
         };
     }]);
