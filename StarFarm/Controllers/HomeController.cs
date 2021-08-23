
using StarFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarFarm.Controllers
{    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "ID,User_Name,Email,Phone,Message")] ContactU contactU)
        {
            StarFarmProjectModels db = new StarFarmProjectModels();
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactU);
        }


        public ActionResult Sitemap()
        {
            ViewBag.Message = "Your Sitemap page.";

            return View();
        }
    }
}