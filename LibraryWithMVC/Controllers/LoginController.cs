using LibraryWithMVC.Models.Entity;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_member member)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.tbl_member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}