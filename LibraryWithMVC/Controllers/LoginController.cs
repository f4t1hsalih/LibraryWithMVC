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
                    //FormsAuthentication ile veri çekme
                    FormsAuthentication.SetAuthCookie(mmb.mmb_name + " " + mmb.mmb_surname, false);

                    //Session ile id'yi alma
                    Session.Add("id", mmb.mmb_id);

                    //Session ile tüm verileri çekme(farklı kullanım)
                    //Session["Name"] = mmb.mmb_name;
                    //Session["Surname"] = mmb.mmb_surname;
                    //Session["Email"] = mmb.mmb_email;
                    //Session["Username"] = mmb.mmb_username;
                    //Session["Tel"] = mmb.mmb_tel;
                    //Session["School"] = mmb.mmb_school;

                    //TempData ile Veri Çekme
                    //TempData["Name"] = mmb.mmb_name;
                    //TempData["Surname"] = mmb.mmb_surname;
                    //TempData["Email"] = mmb.mmb_email;
                    //TempData["Username"] = mmb.mmb_username;
                    //TempData["Tel"] = mmb.mmb_tel;
                    //TempData["School"] = mmb.mmb_school;

                    return RedirectToAction("Index", "StudentPanel");
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