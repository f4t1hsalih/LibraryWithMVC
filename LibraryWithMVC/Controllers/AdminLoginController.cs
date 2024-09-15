using LibraryWithMVC.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryWithMVC.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_admin admin)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var value = db.tbl_admin.FirstOrDefault(x => x.adm_username == admin.adm_username && x.adm_password == admin.adm_password);
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(value.adm_username, false);
                    Session.Add("adminID", value.adm_id);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View(admin);
                }
            }

        }
    }
}