using LibraryWithMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class BorrowController : Controller
    {
        // GET: Borrow
        public ActionResult Index()
        {
            return View();
        }

        //Kitap Ödünç Ekranı
        [HttpGet]
        public ActionResult Lend()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                //Kullanıcıları Dropdowna gönderme
                List<SelectListItem> members = (from x in db.tbl_member
                                                select new SelectListItem
                                                {
                                                    Text = x.mmb_name + " " + x.mmb_surname,
                                                    Value = x.mmb_id.ToString()
                                                }).ToList();
                ViewBag.Members = members;

                //Kitapları Dropdowna gönderme
                List<SelectListItem> books = (from x in db.tbl_book
                                              select new SelectListItem
                                              {
                                                  Value = x.bk_id.ToString(),
                                                  Text = x.bk_name
                                              }).ToList();
                ViewBag.Books = books;

                //Personelleri Dropdowna gönderme
                List<SelectListItem> staff = (from x in db.tbl_staff
                                              select new SelectListItem
                                              {
                                                  Value = x.stf_id.ToString(),
                                                  Text = x.stf_name + " " + x.stf_surname
                                              }).ToList();
                ViewBag.Staff = staff;

                return View();
            }

        }
        [HttpPost]
        public ActionResult Lend(tbl_movement mov)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                mov.mvm_receipt_date = DateTime.Now.Date;
                mov.mvm_delivery_date = DateTime.Now.Date.AddDays(30);
                db.tbl_movement.Add(mov);
                db.SaveChanges();
                return RedirectToAction("Lend");
            }

        }
    }
}