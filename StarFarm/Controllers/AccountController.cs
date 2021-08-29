using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using StarFarm.Models;
using StarFarm.Models.ViewModel;

namespace StarFarm.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Hiển thị màn hình Login
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
        }

        [HttpPost]
        {
            {

                {
                }
                return RedirectToAction("Index", "Products", new { area = "Admin" });

            }

        }

        {
            // Initialization.    
            var claims = new List<Claim>();
            try
            {

            }
            {
            }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        {
            try
            {
            }
            {
            }
            return RedirectToAction("SignIn");
        }

    }
}
