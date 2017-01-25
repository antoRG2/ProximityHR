using System.Web.Mvc;

namespace Proximity.HR.Web.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginSection()
        {
            return View("_login");
        }

        public ActionResult MenuSection()
        {
            return View("_menu");
        }

        public ActionResult UserSection()
        {
            return View("_user");
        }

        public ActionResult TechnologySection()
        {
            return View("_technology");
        }


        public ActionResult ProfileSection()
        {
            return View("_profile");
        }

        public ActionResult SkillsSection()
        {
            return View("_skills");
        }

       
    } 
}
