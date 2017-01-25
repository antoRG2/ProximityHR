app.factory('reportsService', ['$http', function ($http) {

    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        GetFeaturesByExpertise: function () {
            return $http.get("api/Report/GetfeaturesReportByExpertise");
        },

        GetAverageWYReport: function () {
            return $http.get("api/Report/averageWorkingYearsReport");
        }
         ,
        avg: function () {
            return $http.get("api/Report/average");
        }
        ,
        getMaritalStatusReport: function () {
            return $http.get("api/Report/maritalStatusReport");
        }
        ,
        getDemographicsReport: function () {
            return $http.get("api/Report/demographicReport");
        }
        ,
        getAgesReport: function () {
            return $http.get("api/Report/agesReport");
        }
        ,
        getExpirationDatesReport: function () {
            return $http.get("api/Report/expirationDatesReport");
        }
        ,
        shittyReport: function () {
            return $http.get("api/Report/shittyReport");
        }
    };

}]);