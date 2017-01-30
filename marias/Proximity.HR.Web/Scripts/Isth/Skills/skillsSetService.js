app.factory('skillsSetService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        GetTechnologies: function (userId) {
            return $http.get("api/SkillsSet/GetEmployeeTechFeatureLst?userId=" + userId);
        },
        SaveEmployeeTechFeatureLst: function (data) {
            return $http.post("api/SkillsSet/PostEmployeeTechFeatureLst", JSON.stringify(data),
                    {
                        headers: { 'Content-Type': 'application/json' }
                    });
        },
        UpdateFeature: function(data) {
            return $http.post("api/Features/UpdateFeature", JSON.stringify(data), {
                headers: { 'Content-Type': 'application/json' }
            });
        },
        PostFeature: function (data) {
            data.Enabled = true;
            data.CreatedBy = "admin";
            data.CreatedDate = new Date();
            return $http.post("api/Features/PostFeature", JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                });
        },
        GetFeatures: function () {
            return $http.get("api/Features/GetFeat");
        }
        
    };
}]);
