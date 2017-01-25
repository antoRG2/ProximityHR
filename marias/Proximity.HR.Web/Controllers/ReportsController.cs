using System.Web.Mvc;

namespace Proximity.HR.Web.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AverageReport()
        {
            return PartialView("_AverageReport");
        }

        public PartialViewResult AgeReport()
        {
            return PartialView("_AgeReport");
        }

        public PartialViewResult FeatureReport()
        {
            return PartialView("_FeatRep");
        }
        // demographics
        public PartialViewResult DemoReport()
        {
            return PartialView("_DemoRep");
        }
        // marital status
        public PartialViewResult MSReport()
        {
            return PartialView("_MSRep");
        }
        // expiration dates
        public PartialViewResult EDReport()
        {
            return PartialView("_EDRep");
        }

        // dashboard
        public PartialViewResult dashboard()
        {
            return PartialView("_dash");
        }

    }
}
