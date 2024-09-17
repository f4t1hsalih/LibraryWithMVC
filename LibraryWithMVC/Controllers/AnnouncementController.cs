using LibraryWithMVC.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public ActionResult Index()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var announcements = db.tbl_announcement.ToList();
                return View(announcements);
            }
        }

        [HttpGet]
        public ActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAnnouncement(tbl_announcement anc)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ModelState.Remove("anc_id");
                if (ModelState.IsValid)
                {
                    anc.anc_beginDate = DateTime.Now.Date;
                    db.tbl_announcement.Add(anc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(anc);
                }
            }
        }

        [HttpGet]
        public ActionResult EditAnnouncement(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var values = db.tbl_announcement.Find(id);
                return View(values);
            }
        }
        [HttpPost]
        public ActionResult EditAnnouncement(tbl_announcement anc)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var existingAnnouncement = db.tbl_announcement.Find(anc.anc_id);
                ModelState.Remove("anc_id");
                if (existingAnnouncement != null && ModelState.IsValid)
                {
                    anc.anc_beginDate = existingAnnouncement.anc_beginDate;
                    db.Entry(existingAnnouncement).CurrentValues.SetValues(anc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(anc);
                }
                
            }
        }

        public ActionResult DeleteAnnouncement(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var anc = db.tbl_announcement.Find(id);
                if (anc != null)
                {
                    db.tbl_announcement.Remove(anc);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}