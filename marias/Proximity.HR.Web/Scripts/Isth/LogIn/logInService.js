app.factory('logInService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];
 
    return {
        logIn: function (data)
        {
            return $http.post("api/Account/PostAuthenticate", JSON.stringify(data),
            {
                headers: { 'Content-Type': 'application/json' }
            });
        }
    };
}]);