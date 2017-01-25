app.factory('logInCustom', [ '$http', 'skillsSetService', '$rootScope', '$timeout', function ( $http, skillsService, $rootScope, $timeout) {
    $rootScope.showHideContent = true;
    $rootScope.showHideAdminContent = true;

    return {
        showContent: function (UserName,isAdmin) {
            $rootScope.initEmployeeCtrl(UserName);
            
            $rootScope.GetUsersFromAD();
            $rootScope.showHideContent = false;
            $rootScope.showHideAdminContent = !isAdmin;

            $timeout(function ()
            {
                var href = $('#testpull');
                $('html, body').stop().animate({ scrollTop: $(href.attr('href')).offset().top }, 1000);
            }, 1);
        },
        hideContent: function () {
            var href = $('#logOutLink');

            $('html, body').stop().animate({ scrollTop: $(href.attr('href')).offset().top }, 1000, function () {
                $rootScope.showHideContent = true;
                $rootScope.showHideAdminContent = true;
                $rootScope.$apply();
            });
        }
    };
}]);