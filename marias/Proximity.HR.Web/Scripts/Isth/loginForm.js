app.controller('loginCtrl', ['$scope', '$cookies', 'logInService', 'logInCustom', '$rootScope', '$timeout',
                    function ($scope, $cookies, logInService, logInCustom, $rootScope, $timeout) {
                        $scope.lockClass = 'LockOff';

                        var userInfo = $cookies.get('userData');
                        var userIsAdmin = $cookies.get('userIsAdmin');

                        
                        //Si existe un cookie.
                        if (userInfo != null) {
                            $scope.LogInMessage = "Welcome Back: " + userInfo + "!";
                            $timeout(function () {
                                logInCustom.showContent(userInfo, userIsAdmin);
                            }, 5);
                        } else {
                            logInCustom.hideContent();
                        }

                        //LogIn
                        $scope.logIn = function () {
                            $scope.lockClass = 'LockOn';
                            var data = {
                                UserName: $scope.UserName,
                                Password: $scope.UserPassword
                            };

                            var promise = logInService.logIn(data);

                            promise.error(function (data, status, headers, config) {
                                console.log("Error: " + status + " " + data);
                                //alert("Error: " + status + " " + data);
                            });

                            promise.success(function (response) {
                                if (response.Status == 1) {

                                    //Si el usuario desea ser recordado crea los cookies
                                    if ($scope.RememberMe || !$scope.RememberMe) {
                                        $cookies.put('userData', $scope.UserName);
                                        $cookies.put('userIsAdmin', response.Response.IsAdmin);                                        
                                    }
                                    $scope.EmployeeID = null;
                                    $scope.EmployeeID = response.Response.Id;
                                    $scope.TechnologyFeatureList = null;
                                    $scope.TechnologyFeatureList = {};
                                    $scope.LogInMessage = "Welcome " + $scope.UserName + " !!";

                                    //Carga el contenido
                                    logInCustom.showContent($scope.UserName, response.Response.IsAdmin);
                                } else {
                                    $cookies.remove('userData');
                                    $cookies.remove('userIsAdmin');
                                    $scope.LogInMessage = response.Message;

                                    //Esconde el contenido
                                    logInCustom.hideContent();
                                }
                                $scope.lockClass = 'LockOff';
                            });
                        };

                        //LogOut
                        $scope.logOut = function () {
                            $cookies.remove('userData');
                            $cookies.remove('userIsAdmin');
                            $scope.UserName = "";
                            $scope.UserPassword = "";
                            $scope.LogInMessage = "";
                            logInCustom.hideContent();
                        };
                    }]);

app.directive('loginForm', function () {
    return {
        restrict: 'EA',
        replace: true,
        controller: 'loginCtrl',
        template: '<div class="container"><form class="form-signin" id="logInForm" ng-show="showHideContent"><label for="userName"><i class="fa fa-user" aria-hidden="true"></i>&nbsp;&nbsp;User Name</label><input id="userName" class="form-control" type="text" placeholder="User Name" required="" ng-model="UserName" autofocus=""><label for="userPassword"><i class="fa fa-key" aria-hidden="true"></i> Password</label><input id="userPassword" class="form-control" type="password"  placeholder="Password" required="" ng-model="UserPassword"><div class="checkbox"><label><input value="remember-me" type="checkbox" ng-model="RememberMe">Remember me</label></div><button class="btn btn-lg btn-primary btn-block" type="submit" ng-click="logIn()"><i class="fa fa-sign-in" aria-hidden="true"></i> Sign in</button></form><h3 class="logInFormMessage">{{LogInMessage}}</h3><form class="form-signin" id="logOutForm" ng-hide="showHideContent"><button class="btn btn-lg btn-primary btn-block" type="submit" ng-click="logOut()"><i class="fa fa-sign-out" aria-hidden="true"></i> Sign Out</button></form></div>'
    }
});


