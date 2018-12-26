using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AbstractFactory.Core;
using AbstractFactory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AbstractFactory.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<SettingsModel> appSettings;

        public HomeController(IOptions<SettingsModel> app)
        {
            appSettings = app;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExecuteQuery(string query)
        {
            IDatabaseFactory factory = null;
            string factorytype = appSettings.Value.Factory;

            if (factorytype != null)
            {
                factory = new SqlClientFactory();
            }
            else
            {
                factory = new OleDbFactory();
            }

            DatabaseHelper helper = new DatabaseHelper(factory);

            query = query.ToLower();

            if (query.StartsWith("select"))
            {
                DbDataReader reader = helper.ExecuteSelect(query);
                return View("ShowTable", reader);
            }
            else
            {
                int i = helper.ExecuteAction(query);
                return View("ShowResult", i);
            }
        }
    }
}
