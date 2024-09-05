using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        public ActionResult Index()
        {
            ViewBag.Title = "Vitrin Paneli";
            return View();
        }
    }
}