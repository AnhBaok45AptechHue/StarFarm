using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarFarm.Models;

namespace StarFarm.Areas.ADMIN
{
    public class ContactUsController : Controller
    {
        private StarFarmProjectModels db = new StarFarmProjectModels();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View(db.ContactUs.ToList());
        }

        // GET: ContactUs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,User_Name,Email,Phone,Message")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactU);
        }

        // GET: ContactUs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,User_Name,Email,Phone,Message")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactU);
        }

        // GET: ContactUs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = db.ContactUs.Find(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ContactU contactU = db.ContactUs.Find(id);
            db.ContactUs.Remove(contactU);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
