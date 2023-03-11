using LaendiStore.Common;
using LaendiStore.IBusiness;
using LaendiStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            GetData();
            return View();
        }


        private void GetData()
        {
            var cart = Session[CommonStants.CartSession];
            var list = new List<CartViewModel>();
            if (cart != null)
            {
                list = (List<CartViewModel>)cart;
            }
            if (TempData["Check"] != null)
            {
                ViewBag.err1 = TempData["Check"];
            }
            else if (TempData["success"] != null)
            {
                ViewBag.success = TempData["success"];
            }
            ViewBag.listOrder = list;
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult AddItem(int cartId, int quantity)
        {
            var Product = _productReponsitory.GetById(cartId);
            var cart = Session[CommonStants.CartSession];
            if (cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(x => x.Products.ID == cartId))
                {
                    foreach (var item in list)
                    {
                        if (item.Products.ID == cartId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cartitem
                    var item = new CartViewModel();
                    item.Products = Product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CommonStants.CartSession] = list;
            }
            else
            {
                //tao moi doi tuong cartitem
                var item = new CartViewModel();
                item.Products = Product;
                item.Quantity = quantity;
                var list = new List<CartViewModel>();
                list.Add(item);
                //gan session
                Session[CommonStants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}