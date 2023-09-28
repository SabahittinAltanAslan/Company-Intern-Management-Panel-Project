using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stajerYonetim.Models;
using System;
using System.IO;
using System.Linq;

namespace stajerYonetim.Controllers
{
    public class DocumentController : Controller
    {
        Context _dbContext = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upload()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string password = HttpContext.Session.GetString("Password");
            var main = _dbContext.Interns
                .Where(x => x.UserName == userName && x.Password == password)
                .Include(x => x.Company)
                .FirstOrDefault();
            var projects = _dbContext.Documents
            .Where(doc => doc.InternId == main.InternId) // Sadece oturum sahibine ait olduğu belgeleri getir
            .ToList();
            return View(projects);
        }

        [HttpPost]
        public IActionResult Upload(PdfViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userName = HttpContext.Session.GetString("UserName");
                string password = HttpContext.Session.GetString("Password");
                var main = _dbContext.Interns
                    .Where(x => x.UserName == userName && x.Password == password)
                    .Include(x => x.Company)
                    .FirstOrDefault();
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PdfFile.FileName;
                string filePath = Path.Combine(@"C:\Users\Legen\OneDrive\Masaüstü\", "Documents", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PdfFile.CopyTo(fileStream);
                }

                // Veritabanına kayıt işlemleri
                var documents = new Document
                {
                    FileName = uniqueFileName,
                    OriginalFileName = model.PdfFile.FileName,
                    InternId=main.InternId
                };

                _dbContext.Documents.Add(documents);
                _dbContext.SaveChanges();
                return RedirectToAction("Upload", "Document");
            }

            return View(model);
        }
        public IActionResult Download(int id)
        {
            var pdfRecord = _dbContext.Documents.Where(p => p.Id == id).FirstOrDefault();
            if (pdfRecord == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(@"C:\Users\Legen\OneDrive\Masaüstü\", "Documents", pdfRecord.FileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", pdfRecord.OriginalFileName);
        }
        public IActionResult CheckDocument(int id)
        {
            var ıntern=_dbContext.Interns.Find(id);
            var projects = _dbContext.Documents
            .Where(doc => doc.InternId == ıntern.InternId) 
            .ToList();
            return View(projects);
        }
    }
}
