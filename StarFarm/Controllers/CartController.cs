using Newtonsoft.Json;
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
        // GET: Cart
        StarFarmProjectModels db = new StarFarmProjectModels();
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AddToCart(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (GetCartItems().Any(item => item.ProductId == product.Product_Id))
        //    {
               
        //    }
        //}
        //private List<CartItem> GetCartItems()
        //{
        //    if (Session["Cart"] == null)
        //    {
        //        Session["Cart"] = new List<CartItem>();

        //    }
        //    return Session["Cart"] as List<CartItem>;
        //}

        // Dung de them product vao cart
        public string AddToCart(int id)
        {
            Product product = db.Products.Find(id);
            List<CartItem> cart = Session["Cart"] as List<CartItem>;
            if(cart == null)
            {
                cart = new List<CartItem>();
            }
            if (cart.Where(item => item.ProductId == (long)product.Product_Id).Count() > 0)
            {
                CartItem existItem = cart.Where(item => item.ProductId == (long)product.Product_Id).First();
                existItem.Quantity++;
            }
            else
            {
                 CartItem item = new CartItem
                            {
                                ProductId = (long)product.Product_Id,
                                ProductName = product.Product_Name
                            };
                cart.Add(item);
            }
            Session["Cart"] = cart;


            // Tra ve du lieu json
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                },
            };

            return JsonConvert.SerializeObject(cart, settings);
        }



    }
}