using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using PrototypePattern.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrototypePattern.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                ContentDispositionHeaderValue header
                    = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                string fileName = header.FileName.Value;
                fileName = fileName.Trim('"');
                fileName = Path.GetFileName(fileName);

                MemoryStream ms = new MemoryStream();
                Stream s = file.OpenReadStream();
                s.CopyTo(ms);
                byte[] data = ms.ToArray();
                s.Close();
                ms.Close();

                UplodadedFile primaryObj = new UplodadedFile();
                primaryObj.FileName = fileName;
                primaryObj.ContentType = file.ContentType;
                primaryObj.Size = file.Length;
                primaryObj.TimeStamp = DateTime.Now;
                primaryObj.FileContent = data;

                IUploadedFile backupObj = primaryObj.Clone();
                //send primaryObj to main system
                //send backupObj to backup system
            }

            ViewBag.Message = files.Count + " file(s) uploaded successfully!";

            return View("Index");

        }
    }
}
