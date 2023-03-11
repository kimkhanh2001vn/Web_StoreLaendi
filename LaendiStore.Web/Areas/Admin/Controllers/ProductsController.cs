using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaendiStore.Data.DBContext;
using LaendiStore.Data.EF;
using LaendiStore.ViewModel;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private eLaendiStoreDBContext db = new eLaendiStoreDBContext();
        #region Get Service
        private List<Category> categoriesListItem = (List<Category>)_categoryReponsitory.GetAll();
        #endregion
        // GET: Admin/Products
        public ActionResult Index()
        {
            GetData();
            return View();
        }
        private void GetData()
        {
            #region GetProductByCategory
            List<Product> products = (List<Product>)_productReponsitory.GetAll();
            List<Category> categories = (List<Category>)_categoryReponsitory.GetAll();

            List<ProductByCategoryViewModel> itemCategory = (from a in products
                                                             join b in categories on a.CategoryID equals b.ID
                                                             select new ProductByCategoryViewModel
                                                             {
                                                                 products = a,
                                                                 categorys = b
                                                             }).ToList();
            ViewBag.productModel = itemCategory;
            #endregion
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            
            ViewBag.CategoryID = new SelectList(categoriesListItem, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,CategoryID,Image,MoreImage,Price,PromotionPrice,Warranty,Description,Content,ViewCount,Tags,Code,Brand,CreateDate,CreatedBy,UpdatedDate,UpdatedBy,MetaKeyword,MetaDescription,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productReponsitory.Insert(product);
                _productReponsitory.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(categoriesListItem, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productReponsitory.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(categoriesListItem, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,CategoryID,Image,MoreImage,Price,PromotionPrice,Warranty,Description,Content,ViewCount,Tags,Code,Brand,CreateDate,CreatedBy,UpdatedDate,UpdatedBy,MetaKeyword,MetaDescription,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productReponsitory.Update(product);
                _productReponsitory.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(categoriesListItem, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productReponsitory.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                _productReponsitory.Delete(product.ID);
                _productReponsitory.Save();
                return RedirectToAction("Index");
            }
        }

        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
