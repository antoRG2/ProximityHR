app.factory('AccountService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        GetUsersFromAD: function () {
            return $http.get("api/Account/GetADAccounts");
        },
        GetUserByUserName: function (userName) {
            return $http.get("api/Account/GetUserByUserName?userName=" + userName);
        },
        SaveUser: function (Id, data) {
            if (Id === 0) {
                return $http.post("api/Account/PostSaveUser", JSON.stringify(data),
                    {
                        headers: { 'Content-Type': 'application/json' }
                    });
            } else {
                return $http.post("api/Account/UpdateUser", JSON.stringify(data),
                              {
                                  headers: { 'Content-Type': 'application/json' }
                              });
            }
        }
    };
}]);