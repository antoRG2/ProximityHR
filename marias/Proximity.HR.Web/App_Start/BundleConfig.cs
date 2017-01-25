using System.Web.Optimization;

namespace Proximity.HR.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/Custom").Include(
               "~/Scripts/lib/bootstrap.js",
               "~/Scripts/lib/jquery.parallax-1.1.3.js",
               "~/Scripts/lib/imagesloaded.pkgd.js",
               "~/Scripts/lib/jquery.sticky.js",
               "~/Scripts/lib/smoothscroll.js",
               "~/Scripts/lib/wow.js",
               "~/Scripts/lib/jquery.easypiechart.js",
               "~/Scripts/lib/waypoints.js",
               "~/Scripts/lib/jquery.cbpQTRotator.js",
               "~/Scripts/lib/custom.js",
               "~/Scripts/lib/jquery.rateit.js",
               "~/Scripts/lib/owl.carousel.js",
               "~/Scripts/lib/jquery-ui.js",
               //"~/Scripts/lib/kendo.all.js",
               "~/Scripts/lib/bootstrap-switch.js",
               "~/Scripts/lib/ui-bootstrap-tpls-0.13.3.js",
               //"~/Scripts/lib/mine-ui.js",
               "~/Scripts/lib/angular-ui-switch.js"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/kendo/jquery.js",
                        "~/Scripts/lib/jquery-1.11.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoui").Include(
                       //"~/Scripts/kendo/jquery.js",
                       "~/Scripts/kendo/jszip.js",
                       "~/Scripts/kendo/kendo.all.js",
                       "~/Scripts/lib/mine-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/lib/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/lib/jquery.unobtrusive*",
                        "~/Scripts/lib/jquery.validate*"));



            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/lib/angular.js",
                        "~/Scripts/lib/angular-resource.js",
                        "~/Scripts/lib/angular-route.js",
                        "~/Scripts/lib/angular-cookies.js",
                        "~/Scripts/lib/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                         "~/Scripts/lib/sweetalert.min.js",
                        "~/Scripts/lib/ngSweetAlert.min.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/lib/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/font-awesome.css",
                    "~/Content/simple-line-icons.css",
                    "~/Content/animate.css",
                    "~/Content/Site.css",
                    "~/Content/reports.css",
                    "~/Content/rateit.css",
                    "~/Content/owl.carousel.css",
                    "~/Content/owl.theme.css",
                    "~/Content/themes/base/jquery-ui.css",
                    "~/Content/bootstrap-switch.css",
                    "~/Content/angular-ui-switch.css",
                    "~/Content/angucomplete.css",
                    //"~/Content/kendo.common.css",
                    //"~/Content/kendo.rtl.css",
                    //"~/Content/kendo.default.css",
                    "~/Content/kendo.common-material.css",
                    "~/Content/kendo.material.css",
                    "~/Content/kendo.material.mobile.css",
                    "~/Content/overwrite.css",
                    "~/Content/sweetalert.css"
                   ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/scripts/isthMeApp").Include(
                         "~/Scripts/Isth/Layout.js",
                         "~/Scripts/Isth/loginForm.js",
                         "~/Scripts/Isth/LogIn/logInService.js",
                         "~/Scripts/Isth/LogIn/loginCustom.js",
                         "~/Scripts/Isth/Skills/skillsController.js",
                         "~/Scripts/Isth/Skills/skillsService.js",
                         "~/Scripts/Isth/Skills/skillsSetController.js",
                         "~/Scripts/Isth/Skills/skillsSetService.js",
                         "~/Scripts/Isth/Skills/skillsForm.js",
                         "~/Scripts/Isth/EmployeeInfo/employeeApp.js",
                         "~/Scripts/Isth/EmployeeInfo/employeeController.js",
                         "~/Scripts/Isth/EmployeeInfo/employeeService.js",
                         "~/Scripts/Isth/MYAngular/controller.js",
                         "~/Scripts/Isth/GeneralData/GeneralDataCtrl.js",
                         "~/Scripts/Isth/GeneralData/GeneralDataService.js",
                         "~/Scripts/Isth/Account/AccountController.js",
                         "~/Scripts/Isth/Account/AccountService.js",
                         "~/Scripts/Isth/Reports/reportsCtrl.js",
                         "~/Scripts/Isth/Reports/reportsService.js",

                          "~/Scripts/lib/angular-touch.js",
                          "~/Scripts/Isth/angucomplete.js"
                         ));
        }
    }
}