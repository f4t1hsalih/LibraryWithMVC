using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Showcase");
        }
    }
}