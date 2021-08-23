using StarFarm.Models;
using StarFarm.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StarFarm.Controllers
{
	public class CartController : Controller
	{
		StarFarmProjectModels db = new StarFarmProjectModels();
		// GET: Cart
		public ActionResult Index()
		{
			
			return View(GetCartItems());
		}
		public ActionResult AddToCart(int id)
		{
			var product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}


			if (GetCartItems().Any(item => item.ProductId == product.Product_Id))
			{
				TempData["Message"] = new NotificationMessage(
					string.Format("Product \"{0}\" has already been in cart.", product.Product_Name),
					"error");
			}

			else
			{
				

				GetCartItems().Add(new CartItem(product));
				TempData["Message"] = new NotificationMessage(
					string.Format("Product \"{0}\" is added to cart.", product.Product_Name),
					"success");
			}
			// Kiểm tra nếu tồn tại UrlReferrer  thì redirect về trang trước đó.
			//   Có trường hợp không tồn tại UrlReferrer (do trình duyệt chặn, không gửi lên) -> cần xử lí kiểu khác
			if (Request.UrlReferrer != null)
			{
				return Redirect(Request.UrlReferrer.AbsoluteUri);
			}
			return RedirectToAction("Index");
		}
		public ActionResult RemoveFromCart(int id)
		{
			var product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			var cartItem = GetCartItems().Where(item => item.ProductId == id).First();
			GetCartItems().Remove(cartItem);
			return RedirectToAction("Index");
		}

		private List<CartItem> GetCartItems()
		{
			if (Session["Cart"] == null)
			{
				Session["Cart"] = new List<CartItem>();

			}
			return Session["Cart"] as List<CartItem>;
		}
	}
}