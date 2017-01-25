app.factory('employeeService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];
    
    return {
        GetEmployeeByName: function (userName) {
            return $http.get("api/Employee/GetEmployeeByUserName?userName=" + userName);
        },
        GetEmployeeById: function (id) {
            return $http.get("api/Employee/GetEmployeeById?employeeId=" + id);
        },
        GetEmployees: function () {
            return $http.get("api/Employee/GetEmployees");
        }


    };
}]);