using LibraryWithMVC.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    [Authorize]
    public class StudentPanelController : Controller
    {
        // GET: StudentPanel
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                int id = Convert.ToInt32(Session["id"].ToString());
                var value = db.tbl_member.FirstOrDefault(x => x.mmb_id == id);
                ViewBag.fullname = value.mmb_name + " " + value.mmb_surname;
                return View(value);
            }
        }
    }
}