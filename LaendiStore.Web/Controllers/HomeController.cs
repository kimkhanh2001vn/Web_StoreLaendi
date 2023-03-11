using LaendiStore.IBusiness;
using LaendiStore.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaendiStore.Data.EF;
using LaendiStore.ViewModel;
using LaendiStore.Common;

namespace LaendiStore.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            GetData();
            return View();
        }

        private void GetData()
        {
            
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
        public ActionResult ProductCollection(string CateValue = null)
        {
            GetProductCollectionByName(CateValue);
            return View();
        }

        private void GetProductCollectionByName(string CateValue)
        {
            #region GetProductByCategory
            List<Product> products = (List<Product>)_productReponsitory.GetAll();
            List<Category> categories = (List<Category>)_categoryReponsitory.GetAll();

            List<ProductByCategoryViewModel> model = (from a in products
                                                             join b in categories on a.CategoryID equals b.ID
                                                             select new ProductByCategoryViewModel
                                                             {
                                                                 products = a,
                                                                 categorys = b
                                                             }).OrderByDescending(x=>x.products.CreateDate).ToList();
            
            
            
            if (CateValue.Contains(CommonStants.ContentKey.KeyAccessories))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyAccessories)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyBomber))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyBomber)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyJacket))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyJacket)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyPants))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyPants)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyQuanJeans))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyQuanJeans)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyShirts))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyShirts)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyShoes))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyShoes)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else if (CateValue.Contains(CommonStants.ContentKey.KeyVay))
            {
                ViewBag.ListProduct = model.Where(x => x.categorys.Value == CommonStants.ContentKey.KeyVay)
                                            .OrderByDescending(x => x.products.CreateDate).ToList();
            }
            else
            {
                ViewBag.ListProduct = model;
            }
            #endregion
        }
        public ActionResult ProductDetai(int id)
        {
            ViewBag.ProductById = _productReponsitory.GetById(id);

            return View();
        }
        public ActionResult Header()
        {
            #region GetCatgories
            List<Category> categories = (List<Category>)_categoryReponsitory.GetAll();
            ViewBag.CategoryList = categories;
            #endregion
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}