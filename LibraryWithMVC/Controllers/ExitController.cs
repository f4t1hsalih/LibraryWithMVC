using System.Web.Mvc;
using System.Web.Security;

namespace LibraryWithMVC.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Showcase");
        }
    }
}