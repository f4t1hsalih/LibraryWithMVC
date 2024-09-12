using LibraryWithMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MessageController : Controller
    {
        public void getName()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            int id = Convert.ToInt32(Session["id"].ToString());
            tbl_member value = db.tbl_member.FirstOrDefault(x => x.mmb_id == id);
            ViewBag.fullname = value.mmb_name + " " + value.mmb_surname;
        }

        // GET: Message
        public ActionResult Index()
        {
            getName();
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            int id = (int)Session["id"];
            var values = db.tbl_message.Where(x => x.msg_recipient == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            getName();
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
            return RedirectToAction("SendMessage", messages);
        }
        public ActionResult SendMessage()
        {
            getName();
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            int id = (int)Session["id"];
            var values = db.tbl_message.Where(x => x.msg_sender == id).ToList();
            //var values = db.tbl_message
            //                       .Where(x => x.msg_sender == id)
            //                       .Select(x => new
            //                       {
            //                           x.msg_id,
            //                           x.msg_recipient,
            //                           x.msg_subject,
            //                           x.msg_content,
            //                           x.msg_date
            //                       })
            //                       .ToList();
            return View(values);
        }
    }
}