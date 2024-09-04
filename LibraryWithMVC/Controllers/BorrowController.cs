using LibraryWithMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class BorrowController : Controller
    {
        [HttpGet]
        public ActionResult Lend()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                List<SelectListItem> members = db.tbl_member
                    .Select(x => new SelectListItem
                    {
                        Text = x.mmb_name + " " + x.mmb_surname,
                        Value = x.mmb_id.ToString()
                    }).ToList();
                ViewBag.Members = members;

                List<SelectListItem> books = db.tbl_book.Where(x => x.bk_status == true)
                    .Select(x => new SelectListItem
                    {
                        Value = x.bk_id.ToString(),
                        Text = x.bk_name
                    }).ToList();
                ViewBag.Books = books;

                List<SelectListItem> staff = db.tbl_staff
                    .Select(x => new SelectListItem
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
                mov.mvm_status = false;

                var book = db.tbl_book.Find(mov.mvm_bk);

                if (book != null)
                {
                    book.bk_status = false;
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                }

                db.tbl_movement.Add(mov);
                db.SaveChanges();
                return RedirectToAction("ReturnTheBook");
            }
        }

        public ActionResult ReturnTheBook()
        {
            DB_LibraryWithMVCEntities dba = new DB_LibraryWithMVCEntities();
            var movements = dba.tbl_movement.Where(x => x.tbl_book.bk_status == false && x.mvm_status == false).ToList();
            return View(movements);
        }

        [HttpGet]
        public ActionResult ReturnTheBookClick(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var movement = db.tbl_movement.Find(id);

                if (movement != null)
                {
                    var member = db.tbl_member.FirstOrDefault(m => m.mmb_id == movement.mvm_mmb);
                    var book = db.tbl_book.FirstOrDefault(b => b.bk_id == movement.mvm_bk);
                    var staff = db.tbl_staff.FirstOrDefault(s => s.stf_id == movement.mvm_stf);

                    if (member != null)
                    {
                        ViewBag.MemberName = member.mmb_name + " " + member.mmb_surname;
                    }
                    if (book != null)
                    {
                        ViewBag.BookName = book.bk_name;
                    }
                    if (staff != null)
                    {
                        ViewBag.StaffName = staff.stf_name + " " + staff.stf_surname;
                    }
                }

                return View(movement);
            }
        }

        [HttpPost]
        public ActionResult ReturnTheBookClick(int id, DateTime returnDate)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var movement = db.tbl_movement.Find(id);
                if (movement != null)
                {
                    var book = db.tbl_book.Find(movement.mvm_bk);
                    if (book != null)
                    {
                        book.bk_status = true;
                        db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    }

                    movement.mvm_status = true;
                    movement.mvm_return_date = returnDate;

                    db.Entry(movement).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }

                return RedirectToAction("ReturnTheBook");
            }
        }
    }
}
