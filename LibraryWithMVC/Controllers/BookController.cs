using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class BookController : Controller
    {
        DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
        // GET: Book
        public ActionResult Index()
        {

                return View(db.tbl_book.ToList());
        }
    }
}