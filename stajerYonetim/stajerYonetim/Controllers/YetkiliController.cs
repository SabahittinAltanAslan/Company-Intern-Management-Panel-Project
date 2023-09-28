using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stajerYonetim.Models;

namespace stajerYonetim.Controllers
{
    public class YetkiliController : Controller
    {
        Context c = new Context();
        public IActionResult Index()//Girilen id ve şifreye göre login yönlendirmesi yapıyor
        {
            string userName = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("Password");

            var main = c.Admins
                .Where(x => x.UserName == userName && x.Password==password)
                .Include(x => x.Company)
                .FirstOrDefault();
            if (main == null)
            {
                return NotFound();
            }
            return View(new List<Admin> { main });
        }
        public IActionResult AdminSelfBring(int id)//Admin Kendi bilgilerini getirir ve güncelleme için bu bilgileri kullanır
        {
            var bring = c.Admins.Find(id);
            return View("AdminSelfBring", bring);

        }
        public IActionResult AdminSelfUpdate(Admin admin)//Admin Kendi Bilgilerini Gunceller
        {
            var stj = c.Admins.Find(admin.AdminId);
            stj.AdminId = admin.AdminId;
            stj.AdminName = admin.AdminName;
            stj.AdminSurname = admin.AdminSurname;
            stj.UserName = admin.UserName;
            stj.Password = admin.Password;
            stj.CompId = admin.CompId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult AddAnnouncement()
        {
            return View();
        }
    }
}
