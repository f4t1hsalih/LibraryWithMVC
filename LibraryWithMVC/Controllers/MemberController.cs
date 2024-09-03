using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

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
                var members = db.tbl_member.ToList().ToPagedList(page, 5);
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
    }
}