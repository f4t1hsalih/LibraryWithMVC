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
                ViewBag.bookCount = db.tbl_book.Count();
                ViewBag.bookInDeposit = db.tbl_book.Where(x => x.bk_status == false).Count();
                ViewBag.safe = db.tbl_punishment.Sum(x => x.pnh_money);
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
            if (file.ContentLength > 0)
            {
                string pathOfFile = Path.Combine(Server.MapPath("~/Templates/web2/img/"), Path.GetFileName(file.FileName));
                file.SaveAs(pathOfFile);
                return RedirectToAction("Gallery");
            }
            return View();
        }

        public ActionResult LinqCards()
        {
            using (DB_LibraryWithMVCEntities db = new DB_LibraryWithMVCEntities())
            {
                ViewBag.bookCount = db.tbl_book.Count();
                ViewBag.memberCount = db.tbl_member.Count();
                ViewBag.safe = db.tbl_punishment.Sum(x => x.pnh_money);
                ViewBag.bookInDeposit = db.tbl_book.Where(x => x.bk_status == false).Count();
                ViewBag.CategoryCount = db.tbl_category.Count();
                ViewBag.MostActiveMember = db.tbl_member
                    .Where(m => m.mmb_id == db.tbl_movement
                        .GroupBy(mv => mv.mvm_mmb)  // Üye ID'sine göre gruplamar
                        .Select(g => new
                        {
                            MemberId = g.Key,
                            TotalBooks = g.Count()  // Toplam kitap hareketi sayısını hesaplar
                        })
                        .OrderByDescending(g => g.TotalBooks)  // En fazla kitap hareketi yapan üyeyi seçer
                        .Select(g => g.MemberId)
                        .FirstOrDefault())
                    .Select(m => m.mmb_name + " " + m.mmb_surname)
                    .FirstOrDefault();
                ViewBag.MostReadBook = db.tbl_book
                    .Where(b => b.bk_id == db.tbl_movement
                        .GroupBy(m => m.mvm_bk)  // Kitap ID'sine göre gruplamar
                        .Select(g => new
                        {
                            BookId = g.Key,
                            TotalReads = g.Count()  // Toplam okuma sayısını hesaplar
                        })
                        .OrderByDescending(g => g.TotalReads)  // En fazla okunan kitabı seçer
                        .Select(g => g.BookId)
                        .FirstOrDefault())
                    .Select(b => b.bk_name)  // Kitap adını seçer
                    .FirstOrDefault();
                ViewBag.TotalMessage = db.tbl_communication.Count();
                ViewBag.PublisherWithMostBooks = db.tbl_book.GroupBy(x => x.bk_publishing_house).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
                ViewBag.MostSuccessfulStaff = db.tbl_staff
                    .Where(s => s.stf_id == db.tbl_movement
                        .GroupBy(m => m.mvm_stf)  // Personel ID'sine göre gruplamar
                        .Select(g => new
                        {
                            StaffId = g.Key,
                            TotalMovements = g.Count()  // Toplam hareket sayısını hesaplar
                        })
                        .OrderByDescending(g => g.TotalMovements)  // En fazla hareket yapan personeli seçer
                        .Select(g => g.StaffId)
                        .FirstOrDefault())
                    .Select(s => s.stf_name + " " + s.stf_surname)  // Personel ismini seçer
                    .FirstOrDefault();
                ViewBag.CategoryWithMostBooks = db.tbl_category
                    .Where(c => c.ctg_id == db.tbl_book
                        .GroupBy(b => b.bk_ctg)  // Kategori ID'sine göre gruplamar
                        .Select(g => new
                        {
                            CategoryId = g.Key,
                            TotalBooks = g.Count()  // Toplam kitap sayısını hesaplar
                        })
                        .OrderByDescending(g => g.TotalBooks)  // En fazla kitaba sahip kategoriyi seçer
                        .Select(g => g.CategoryId)
                        .FirstOrDefault())
                    .Select(c => c.ctg_name)  // Kategori adını seçer
                    .FirstOrDefault();
                ViewBag.TopAuthorByBookCount = db.GetTopAuthorByBookCount().FirstOrDefault().Yazar;

                return View();
            }
        }
    }
}