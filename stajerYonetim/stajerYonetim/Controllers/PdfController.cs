using Microsoft.AspNetCore.Mvc;
using stajerYonetim.Models;
using System;
using System.IO;
using System.Linq;

namespace stajerYonetim.Controllers
{
    public class PdfController : Controller
    {
        Context _dbContext=new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            var projects =_dbContext.PdfRecords.ToList();
            return View(projects);
        }

        [HttpPost]
        public IActionResult Upload(PdfViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PdfFile.FileName;
                string filePath = Path.Combine(@"C:\Users\Legen\OneDrive\Masaüstü\", "Uploads", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PdfFile.CopyTo(fileStream);
                }

                // Veritabanına kayıt işlemleri
                var pdfRecord = new PdfRecord
                {
                    FileName = uniqueFileName,
                    OriginalFileName = model.PdfFile.FileName
                };

                _dbContext.PdfRecords.Add(pdfRecord);
                _dbContext.SaveChanges();
                return RedirectToAction("Upload", "Pdf");
            }

            return View(model);
        }
        public IActionResult FileBring(int id)
        {
            var bring=_dbContext.PdfRecords.Find(id);
            return View("FileBring",bring);
        }
        public IActionResult FileUpdate(PdfRecord pdfRecord,Intern ıntern)
        {
            var _pdfRecord = _dbContext.PdfRecords.Find(pdfRecord.Id);
            _pdfRecord.OriginalFileName = pdfRecord.OriginalFileName;
            _pdfRecord.InternId = pdfRecord.InternId;
            var _ıntern = _dbContext.Interns.Find(pdfRecord.InternId);
            if (_ıntern != null)
            {
                _ıntern.Id = pdfRecord.Id;
                _dbContext.SaveChanges();
                return RedirectToAction("Upload", "Pdf");
            }
            //ViewData["DontFoundFlag"] = "Intern Not Found!";
            return RedirectToAction("FileUpload");
        }

        public IActionResult DownloadPdf(int id)
        {
            var pdfRecord = _dbContext.PdfRecords.Where(p => p.Id == id).FirstOrDefault();
            if (pdfRecord == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(@"C:\Users\Legen\OneDrive\Masaüstü\", "Uploads", pdfRecord.FileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", pdfRecord.OriginalFileName);
        }

    }
}

