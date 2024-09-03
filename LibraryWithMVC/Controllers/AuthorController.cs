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
    }
}