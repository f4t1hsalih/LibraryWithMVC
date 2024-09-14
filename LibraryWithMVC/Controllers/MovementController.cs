using LibraryWithMVC.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryWithMVC.Controllers
{
    public class MovementController : Controller
    {
        // GET: Movement
        public ActionResult Index()
        {
            DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities();

            var values = db.tbl_movement.ToList();
            return View(values);

        }
        public ActionResult Detail(int id)
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                var movement = db.tbl_movement.Find(id);

                DateTime d1 = DateTime.Parse(movement.mvm_receipt_date.ToString());
                DateTime d2 = DateTime.Now.Date;
                TimeSpan d3 = d2 - d1;
                ViewBag.day = d3.TotalDays;

                if (movement != null)
                {
                    var member = db.tbl_member.Where(x => x.mmb_status == true).FirstOrDefault(m => m.mmb_id == movement.mvm_mmb);
                    var book = db.tbl_book.Where(x => x.bk_status == true).FirstOrDefault(b => b.bk_id == movement.mvm_bk);
                    var staff = db.tbl_staff.Where(x => x.stf_status == true).FirstOrDefault(s => s.stf_id == movement.mvm_stf);

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
    }
}