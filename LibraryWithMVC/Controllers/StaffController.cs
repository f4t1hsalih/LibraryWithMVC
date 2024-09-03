using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var staff = db.tbl_staff.ToList();
                return View(staff);
            }
        }

        // GET: AddStaff
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(tbl_staff staff)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ModelState.Remove("stf_id");
                if (ModelState.IsValid)
                {
                    db.tbl_staff.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(staff);
                }
            }
        }

        //GET: DeleteStaff
        public ActionResult DeleteStaff(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.tbl_staff.Remove(db.tbl_staff.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: EditStaff
        [HttpGet]
        public ActionResult EditStaff(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var value = db.tbl_staff.Find(id);
                return View(value);
            }
        }
        [HttpPost]
        public ActionResult EditStaff(tbl_staff staff)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.Entry(staff).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}