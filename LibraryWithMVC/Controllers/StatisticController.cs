using LibraryWithMVC.Models.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ViewBag.memberCount = db.tbl_member.Count();

                return View();
            }
        }

        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0)
            {
                string pathOfFile = Path.Combine(Server.MapPath("~/Templates/web2/img/"), Path.GetFileName(file.FileName));
                file.SaveAs(pathOfFile);
                return RedirectToAction("Gallery");
            }
            return View();
        }
    }
}