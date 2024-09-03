using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                return View(db.tbl_author.ToList());
            }
        }

        // GET: Add Author
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(tbl_author author)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.tbl_author.Add(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Delete Author
        public ActionResult DeleteAuthor(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_author author = db.tbl_author.Find(id);
                db.tbl_author.Remove(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}