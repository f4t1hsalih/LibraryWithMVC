using LibraryWithMVC.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class StudentPanelController : Controller
    {
        public void getName()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                int id = Convert.ToInt32(Session["id"].ToString());
                tbl_member value = db.tbl_member.FirstOrDefault(x => x.mmb_id == id);
                ViewBag.fullname = value.mmb_name + " " + value.mmb_surname;
            }
        }

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
            getName();
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
                ModelState.Remove("mmb_id");
                if (ModelState.IsValid)
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
                    return View("Index", value);
                }
                return View(mem);
            }
        }

        public ActionResult MyBooks()
        {
            getName();
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
            int id = Convert.ToInt32(Session["id"].ToString());
            var values = db.tbl_movement.Where(x => x.mvm_mmb == id).ToList();
            return View(values);
        }

        public ActionResult Announcement()
        {
            getName();
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var announcements = db.tbl_announcement.ToList();
                return View(announcements);
            }
        }
    }
}