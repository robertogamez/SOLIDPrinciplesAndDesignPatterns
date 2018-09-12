using SingleResponsibilityPrinciple.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleResponsibilityPrinciple.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public List<Customer> GetData(string criteria, string searchBy)
        {
            List<Customer> data = null;
            switch (searchBy)
            {
                case "companyname":
                    data = CustomerSearch.SearchByCompanyName(criteria);
                    break;
                case "contactname":
                    data = CustomerSearch.SearchByContactName(criteria);
                    break;
                case "country":
                    data = CustomerSearch.SearchByCountry(criteria);
                    break;
                default:
                    break;
            }

            return data;
        }

        [HttpPost]
        public ActionResult Search(string criteria, string searchby)
        {
            List<Customer> model = GetData(criteria, searchby);
            ViewBag.Criteria = criteria;
            ViewBag.SearchBy = searchby;

            return View(model);
        }

        [HttpPost]
        public FileResult Export(string criteria, string searchby)
        {
            List<Customer> data = GetData(criteria, searchby);
            string exportData = CustomerDataExporter.ExportToCSV(data);
            return File(System.Text.ASCIIEncoding.ASCII.GetBytes(exportData),
                "application/excel");
        }
    }
}