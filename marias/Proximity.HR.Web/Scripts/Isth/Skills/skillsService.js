app.factory('skillsService', ['$http', function ($http) {
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        GetTechnologies: function () {
            return $http.get("api/SkillsSet/GetEmployeeTechFeatureLst?userId=" + 1);
        },
        GetTechnologyByName: function (technologyName) {
            return $http.get("api/Tech/GetTechnologyByTechnologyName?technologyName=" + technologyName);
        },
        SaveTechnology: function (Id, data) {

            if (Id === 0) {

                data.Enabled = true;
                data.CreatedBy = "admin";
                data.CreatedDate = new Date();

                return $http.post("api/Tech/PostTechnology", JSON.stringify(data),
                    {
                        headers: { 'Content-Type': 'application/json' }
                    });
            } else {

                data.Enabled = true;
                data.EditedBy = "admin";
                data.EditedDate = new Date();
                return $http.post("api/Tech/UpdateTechnology", JSON.stringify(data),
                              {
                                  headers: { 'Content-Type': 'application/json' }
                              });
            }
        },

        UpdateTechnologyFeatures: function (Id, data) {

        debugger;

        if (Id === 0) {

            data.Enabled = true;
            data.CreatedBy = "admin";
            data.CreatedDate = new Date();

            return $http.post("api/Tech/PostTechnologyFeature", JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                });
        } else {

            data.Enabled = true;
            data.EditedBy = "admin";
            data.EditedDate = new Date();
            return $http.post("api/Tech/UpdateTechnologyFeature", JSON.stringify(data),
                          {
                              headers: { 'Content-Type': 'application/json' }
                          });
        }
    }
    };
}]);
