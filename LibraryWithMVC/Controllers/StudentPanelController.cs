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
                tbl_member value = db.tbl_member.FirstOrDefault(x => x.mmb_id == id);
                ViewBag.fullname = value.mmb_name + " " + value.mmb_surname;
                return View(value);
            }
        }

        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var values = db.tbl_member.FirstOrDefault(x => x.mmb_id == id);
                return View(values);
            }
        }
        [HttpPost]
        public ActionResult EditProfile(tbl_member mem)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                tbl_member value = db.tbl_member.FirstOrDefault(x => x.mmb_id == mem.mmb_id);
                value.mmb_name = mem.mmb_name;
                value.mmb_surname = mem.mmb_surname;
                value.mmb_email = mem.mmb_email;
                value.mmb_tel = mem.mmb_tel;
                value.mmb_photo = mem.mmb_photo;
                value.mmb_school = mem.mmb_school;
                value.mmb_password = mem.mmb_password;
                db.Entry(value).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View("Index",value);
            }
        }
        public ActionResult Exit()
        {
            Session.Clear();
            return RedirectToAction("Index","Showcase");
        }
    }
}