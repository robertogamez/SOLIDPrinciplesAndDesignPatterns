using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInversionPattern.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInversionPattern.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string notificationtype)
        {
            INotifier notifier = null;

            switch (notificationtype)
            {
                case "email":
                    notifier = new EmailNotifier();
                    break;
                case "sms":
                    notifier = new SMSNotifier();
                    break;
                case "popup":
                    notifier = new PopupNotifier();
                    break;
                default:
                    break;
            }

            UserManager mgr = new UserManager(notifier);
            mgr.ChangePassword("user1", "oldpwd", "newpwd");

            return View("Success");
        }
    }
}
