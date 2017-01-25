app.factory('GeneralDataService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        GetTechnologies: function () {
            return $http.get("api/Skills/GetSkills");
        },
        GetCountries: function () {
            return $http.get("api/GeneralData/GetCountries");
        },
        GetStates: function (countryId) {
            return $http.get("api/GeneralData/GetStates?countryId=" + countryId);
        },
        GetCities: function (stateId) {
            return $http.get("api/GeneralData/GetCities?stateId=" + stateId);
        },
        GetAllCities: function () {
            return $http.get("api/GeneralData/GetAllCities");
        },
        GetDistricts: function (cityId) {
            return $http.get("api/GeneralData/GetDistricts?cityId=" + cityId);
        },
        GetSchooling: function () {
            return $http.get("api/GeneralData/GetSchooling");
        },
        GetGenders: function () {
            return $http.get("api/GeneralData/GetGenders");
        },
        GetMaritalStatus: function () {
            return $http.get("api/GeneralData/GetMaritalStatus");
        }
    };
}]);