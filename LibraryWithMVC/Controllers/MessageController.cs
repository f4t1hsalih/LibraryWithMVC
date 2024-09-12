using LibraryWithMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            int id = (int)Session["id"];
            var values = db.tbl_message.Where(x => x.msg_recipient == id).ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
            List<SelectListItem> members = (from x in db.tbl_member.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.mmb_email,
                                                Value = x.mmb_id.ToString()
                                            }).ToList();
            ViewBag.Recipient = members;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(tbl_message msg)
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();
            msg.msg_sender = (int)Session["id"];
            msg.msg_date = DateTime.Now.Date;
            db.tbl_message.Add(msg);
            db.SaveChanges();
            int currentUserId = (int)Session["id"];
            List<tbl_message> messages = db.tbl_message.Where(x => x.msg_recipient == currentUserId).ToList();
            return RedirectToAction("Index",messages);
        }
    }
}