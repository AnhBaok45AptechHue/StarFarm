using System;
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
    public class ProductsController : Controller
    {
        private StarFarmProjectModels db = new StarFarmProjectModels();

        // GET: ADMIN/Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: ADMIN/Products/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ADMIN/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_Id,Product_Name,Category_Id,Flavor,Description,Price,Image,Image2")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                SaveUploadedImage(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: ADMIN/Products/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ADMIN/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_Id,Product_Name,Category_Id,Flavor,Description,Price,UploadFile1,UploadFile2")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                SaveUploadedImage(product);
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(product);
        }
      
        // GET: ADMIN/Products/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ADMIN/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
        private void SaveUploadedImage(Product product)
        {
            // Bỏ qua xử lí nếu không có file được upload
            if (product.Image == null && product.Image2 == null ) { return; }

            // Lấy đường dẫn để lưu
            string uploadDir = "/Content/Image";

            string absolutePath = Server.MapPath(uploadDir + "/"+ product.UploadFile1.FileName);
            string absolutePath2 = Server.MapPath(uploadDir + "/" + product.UploadFile2.FileName);



            // Cơ bản để lưu file về
            product.UploadFile1.SaveAs(absolutePath);
            product.UploadFile2.SaveAs(absolutePath2);

            // Gắn thông tin imgage vào sản phẩm (lưu dữ liệu vào bảng ProductImage)
            product.Image = absolutePath;
            product.Image = absolutePath2;
        }

    }
}
