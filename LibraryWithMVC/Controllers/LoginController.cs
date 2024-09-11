using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryWithMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_member member)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_member mmb = db.tbl_member.FirstOrDefault(x => x.mmb_username == member.mmb_username && x.mmb_password == member.mmb_password);
                if (mmb != null)
                {
                    FormsAuthentication.SetAuthCookie(mmb.mmb_name + " " + mmb.mmb_surname, false);
                    Session.Add("id", mmb.mmb_id);
                    return RedirectToAction("Index","StudentPanel");
                }
                else { return View(member); }
            }
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