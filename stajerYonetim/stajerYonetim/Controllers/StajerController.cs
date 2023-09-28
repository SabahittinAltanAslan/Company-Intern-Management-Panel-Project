using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stajerYonetim.Models;

namespace stajerYonetim.Controllers
{
    public class StajerController : Controller
    {
        Context c = new Context();
        public IActionResult Index()//girilen id ve şifreyi kontrol ederek loginde yönlendirme yapıyor
        {
            string userName = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("Password");
            var main = c.Interns
                .Where(x => x.UserName==userName&& x.Password==password)
                .Include(x => x.Company)
                .FirstOrDefault();
            if (main == null)
            {
                return NotFound();
            }
            return View(new List<Intern> { main});
        }
        public IActionResult InternView()//Stajer Listesini Getir
        {
            var ınternDatas = c.Interns.Include(x => x.Company).ToList();
            return View(ınternDatas);
        }
        public IActionResult InternDelete(int id)//Sectigin Stajeri Sil
        {
            var delete = c.Interns.Find(id);
            c.Interns.Remove(delete);
            c.SaveChanges();
            return RedirectToAction("InternView");
        }
        public IActionResult InternBring(int id)//Stajer Bilgileri Getirir 
        {
            var bring = c.Interns.Find(id);
            return View("InternBring", bring);

        }
        public IActionResult InternUpdate(Intern ıntern)//Stajer Bilgileri Guncelle
        {
            var stj = c.Interns.Find(ıntern.InternId);
            stj.InternId = ıntern.InternId;
            stj.InternName = ıntern.InternName;
            stj.InterntSurname = ıntern.InterntSurname;
            stj.InternUni = ıntern.InternUni;
            stj.InternDepart = ıntern.InternDepart;
            stj.InternClass = ıntern.InternClass;
            stj.InternMail = ıntern.InternMail;
            stj.InternNumber = ıntern.InternNumber;
            stj.InternGitHub = ıntern.InternGitHub;
            stj.InternLengues = ıntern.InternLengues;
            stj.InternWant = ıntern.InternWant;
            stj.CompId = ıntern.CompId;
            c.SaveChanges();
            return RedirectToAction("InternView");
        }
        public IActionResult InternSelfBring(int id)//Stajer Kendi bilgilerini getirir ve güncelleme için bu bilgileri kullanır
        {
            var bring = c.Interns.Find(id);
            return View("InternSelfBring", bring);

        }
        public IActionResult InternSelfUpdate(Intern ıntern)//Stajer Kendi Bilgilerini Gunceller
        {
            var stj = c.Interns.Find(ıntern.InternId);
            stj.InternId = ıntern.InternId;
            stj.InternName = ıntern.InternName;
            stj.InterntSurname = ıntern.InterntSurname;
            stj.InternUni = ıntern.InternUni;
            stj.InternDepart = ıntern.InternDepart;
            stj.InternClass = ıntern.InternClass;
            stj.InternMail = ıntern.InternMail;
            stj.InternNumber = ıntern.InternNumber;
            stj.InternGitHub = ıntern.InternGitHub;
            stj.InternLengues = ıntern.InternLengues;
            stj.InternWant = ıntern.InternWant;
            stj.CompId = ıntern.CompId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult InternDetails(int id)
        {
            var details = c.Interns.Find(id);
            return View("InternDetails", details);
        }
        public IActionResult InternPdf()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("Password");
            var main = c.Interns
                .Where(x => x.UserName == userName && x.Password == password)
                .Include(x => x.Company)
                .FirstOrDefault();
            var projectDatas = c.PdfRecords.Find(main.Id);
            return View(projectDatas);
        }

    }
} 