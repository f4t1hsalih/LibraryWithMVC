using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MovementController : Controller
    {
        // GET: Movement
        public ActionResult Index()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            var values = db.tbl_movement.ToList();
            return View(values);

        }
    }
}