using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuilderPattern.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuilderPattern.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext AppDbContext { get; }

        public HomeController(AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Build(string usagetype)
        {
            IComputerBuilder builder = null;

            switch (usagetype)
            {
                case "home":
                    builder = new HomeComputerBuilder(AppDbContext);
                    break;
                default:
                    break;
            }

            ComputerAssembler assembler = new ComputerAssembler(builder);
            Computer computer = assembler.AssembleComputer();

            return View("Success", computer);
        }
    }
}
