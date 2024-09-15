using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using LibraryWithMVC.Models.MyClasses;

namespace LibraryWithMVC.Controllers
{
    [AllowAnonymous] //Bu controllerda bulunan action'ları authorizationdan muaf tutar
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        [HttpGet]
        public ActionResult Index()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            ViewBag.Title = "Vitrin Paneli";

            Class1 cs = new Class1();
            cs.bookEnumerable = db.tbl_book.ToList();
            cs.aboutEnumerable = db.tbl_about.ToList();

            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(tbl_communication cmm)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.tbl_communication.Add(cmm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}