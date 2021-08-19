using StarFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StarFarm.Controllers
{
    public class ProductsController : Controller
    {
        StarFarmProjectModels db = new StarFarmProjectModels();
        // GET: Products
        public ActionResult Index(int? id)
        {
            List<Product> products = null;
            ViewBag.Categories = db.Categories;
            if (id == null)
            {
                // hien thi all
                products = db.Products.ToList();
            }
            else
            {
                //categoryId = id;
                products = db.Products.Where(pr => pr.Category_Id == id).ToList();
            }

            return View(products);

        }
        public ActionResult ProductDetail(int id)
        {
            Product product = db.Products.Where(pr => pr.Product_Id == id).First();
            return View(product);

        }
        public ActionResult Recommend()
        {
            //  List<Product> products = null;
            //  ViewBag.Categories = db.Categories;
            //List<decimal> allIds = db.Products.Select(p => p.Product_Id).ToList();
            //var rnd = new Random(0);
            //decimal minId = allIds.Min();
            //decimal maxId = allIds.Max();
            //List<decimal> randomIds = new List<decimal>();
            //if(allIds.Count <= 5)
            //{
            //    randomIds = allIds;
            //}else
            //{
            //    while (randomIds.Count < 5)
            //    {
            //        rnd.Next((int)minId, (int)maxId);
            //    }

            //}

                List<int> randomIds = new List<int>();
                List<Product> products = db.Products.ToList();
                var rnd = new Random(0);
            if (products.Count <= 5)
            {
                // khong lam gi them
            }
            else
            {
                while (randomIds.Count < 5)
                {
                    int index = rnd.Next(0, products.Count - 1);
                    if (randomIds.Contains(index))
                    {
                        continue;
                    }
                    randomIds.Add(index);
                }
            }
            List<Product> result = new List<Product> { products[randomIds[0]]};
            return View(result);
        }
        //int? categoryId;

        // GET: Categories


        //public bool CheckProductOfCategory(Product p)
        //{
        //    return p.Category_Id == categoryId;
        //}
    }
}