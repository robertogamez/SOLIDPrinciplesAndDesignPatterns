using ContactManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Contacts App";

            using (AppDbContext db = new AppDbContext())
            {
                var query = from c in db.Contacts
                            orderby c.Id ascending
                            select c;

                List<Contact> model = query.ToList();

                return View(model);
            }
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    ViewBag.Message = "Contact added successfully!";
                }
            }

            return View(contact);
        }

        public ActionResult DeleteContact(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var contact = (from c in db.Contacts
                               where c.Id == id
                               select c).FirstOrDefault();

                db.Contacts.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}