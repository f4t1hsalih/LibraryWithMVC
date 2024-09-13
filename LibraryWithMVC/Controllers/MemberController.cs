using LibraryWithMVC.Models.Entity;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index(int page = 1)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                //var member = db.tbl_member.ToList();
                var members = db.tbl_member.Where(x => x.mmb_status == true).ToList().ToPagedList(page, 8);
                return View(members);
            }
        }

        // GET: AddMember
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(tbl_member member)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ModelState.Remove("mmb_id");
                if (ModelState.IsValid)
                {
                    member.mmb_status = true;
                    db.tbl_member.Add(member);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(member);
                }
            }
        }

        // GET: DeleteMember
        public ActionResult DeleteMember(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                // Üyenin aktif kitabı olup olmadığını kontrol et
                var hasActiveBooks = db.tbl_movement.Any(x => x.mvm_mmb == id && x.mvm_return_date == null);

                if (hasActiveBooks)
                {
                    TempData["ErrorMessage"] = "Üyenin iade edilmemiş kitapları olduğu için silinemez.";
                    return RedirectToAction("Index");
                }

                tbl_member member = db.tbl_member.Find(id);
                if (member != null)
                {
                    member.mmb_status = false;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


        // GET: EditMember
        [HttpGet]
        public ActionResult EditMember(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_member member = db.tbl_member.Where(x => x.mmb_status == true).FirstOrDefault(x => x.mmb_id == id);
                return View(member);
            }
        }
        [HttpPost]
        public ActionResult EditMember(tbl_member member)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                db.Entry(member).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}