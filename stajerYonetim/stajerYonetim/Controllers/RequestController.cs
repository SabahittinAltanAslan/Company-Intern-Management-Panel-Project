using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using stajerYonetim.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;
using stajerYonetim.Models;       

namespace stajerYonetim.Controllers
{
    public class RequestController : Controller
    {
        Context c=new Context();
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("Password");
            var main = c.Requests
                .Where(x => x.UserName == userName && x.Password == password)
                .Include(x => x.Company)
                .FirstOrDefault();
            if (main == null)
            {
                return NotFound();
            }
            return View(new List<Request> { main });
            
        }

        public IActionResult RequestView()//Staj Başvuru Listesini Getir
        {
            var requestDatas = c.Requests.Include(x => x.Company).ToList();
            return View(requestDatas);
        }
        public IActionResult RequestDecline(int id)//Sectigin Staj Başvurusunu reddet
        {
            var delete = c.Requests.Find(id);
            c.Requests.Remove(delete);
            c.SaveChanges();
            return RedirectToAction("RequestView");
        }
        public IActionResult RequestDetails(int id)
        {
            var details = c.Requests.Find(id);
            return View("RequestDetails", details);
        }

        public IActionResult RequestAccept(int id)
        {
            // Verileri kaynaktan, verilen ID'ye göre filtreleyerek alın
            List<Request> sourceDataList = c.Requests
                .Where(x => x.ReqId == id)
                .Include(x => x.Company)
                .ToList();

            // Verileri hedef tabloya kopyalayın
            foreach (var sourceData in sourceDataList)
            {
                var destinationData = new Intern
                {

                InternName = sourceData.ReqName,
                InterntSurname = sourceData.ReqtSurname,
                InternUni = sourceData.ReqUni,
                InternDepart = sourceData.ReqDepart,
                InternClass = sourceData.ReqClass,
                InternMail = sourceData.ReqMail,
                InternNumber = sourceData.ReqNumber,
                InternGitHub = sourceData.ReqGitHub,
                InternLengues = sourceData.ReqLengues,
                InternWant = sourceData.ReqWant,
                CompId = sourceData.CompId,
                Company = sourceData.Company,
                UserName = sourceData.UserName,
                Password  = sourceData.Password
                
            };

                c.Interns.Add(destinationData);
                c.Requests.Remove(sourceData);
            }

            // Değişiklikleri kaydedin
            c.SaveChanges();

            return RedirectToAction("RequestView");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult RequestAdd()
        {
            List<SelectListItem> compnaies=(from x in c.Companies.ToList()
                                            select new SelectListItem
                                            {
                                                Text=x.CompName,
                                                Value=x.CompId.ToString(),
                                            }).ToList();
            ViewBag.cmp = compnaies;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestAdd(Request request)
        {
            var req=c.Companies.Where(x=>x.CompId==request.Company.CompId).FirstOrDefault();
            request.Company = req;
            request.CompId = req.CompId;
            c.Requests.Add(request);
            c.SaveChanges();
            return RedirectToAction("Index","Login");
        }
        public IActionResult CvUpload()
        {
            return RedirectToAction("Index","FileUpload");
        }
    }

}

