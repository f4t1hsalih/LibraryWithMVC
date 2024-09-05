using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        public ActionResult Index()
        {
            ViewBag.Title = "Vitrin Paneli";
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
            var books = db.tbl_book.ToList();
            return View(books);
        }
    }
}