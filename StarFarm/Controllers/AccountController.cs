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
		/// <summary>
		/// Hiển thị màn hình Login
		/// </summary>
		/// <returns></returns>
		public ActionResult SignIn()
		{
			return View(new LoginModel());
		}

		/// <summary>
		/// Xử lí đăng nhập, nếu thành công thì chuyển đến trang chỉ định.
		/// Nếu không có trang chỉ định thì redirect tới trang quản lý sản phẩm.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SignIn(LoginModel model)
		{
			StarFarmProjectModels db = new StarFarmProjectModels();
			string returnUrl = Request.Params["ReturnUrl"];
			var userRec = db.Users.FirstOrDefault(user => user.LoginName.ToLower() ==
			model.LoginName && user.Password == model.Password);
			if (userRec != null)
			{
				SignInUser(userRec.LoginName, userRec.Role, model.RememberLogin);

				if (!string.IsNullOrEmpty(returnUrl))
				{
					return Redirect(returnUrl);
				}
				return RedirectToAction("Index", "Products", new { area = "Admin" });

			}

			ModelState.AddModelError("", "Invalid Username or Password");
			return View(model);
		}

		private void SignInUser(string username, string role, bool isPersistent)
		{
			// Initialization.    
			var claims = new List<Claim>();
			try
			{
				// Thiết lập thông tin cần lưu vào cookie    
				claims.Add(new Claim(ClaimTypes.Name, username));
				claims.Add(new Claim(ClaimTypes.Role, role));

				// Sigin
				var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
				var ctx = Request.GetOwinContext();
				var authenticationManager = ctx.Authentication;
				authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
			}
			catch (Exception ex)
			{
				// Info    
				throw ex;
			}
		}

		/// <summary>
		/// Xử lí đăng xuất
		/// </summary>
		/// <returns></returns>
		public ActionResult SignOut()
		{
			try
			{
				// Setting.    
				var ctx = Request.GetOwinContext();
				var authenticationManager = ctx.Authentication;
				// Sign Out.    
				authenticationManager.SignOut();
			}
			catch (Exception ex)
			{
				// Info    
				throw ex;
			}
			return RedirectToAction("SignIn");
		}



	}
}