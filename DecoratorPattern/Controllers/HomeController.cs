using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DecoratorPattern.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecoratorPattern.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IHostingEnvironment env)
        {
            this.hostingEnvironment = env;
        }

        public IActionResult GetImageOriginal()
        {
            string fileName = Path.Combine(hostingEnvironment.WebRootPath, "images", "computer.png");
            IPhoto photo = new Photo(fileName);
            Bitmap bitmap = photo.GetPhoto();
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        public IActionResult GetImageWatermarked()
        {
            string fileName = Path.Combine(hostingEnvironment.WebRootPath, "images", "computer.png");
            IPhoto photo = new Photo(fileName);
            WatermarkDecorator decorator = new WatermarkDecorator(photo, "Copyright (C) 2015.");
            Bitmap bmp = decorator.GetPhoto();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
