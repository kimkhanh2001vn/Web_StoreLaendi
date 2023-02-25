using LaendiStore.IBusiness;
using LaendiStore.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductReponsitory _productReponsitory;
        public HomeController(IProductReponsitory productReponsitory)
        {
            this._productReponsitory = productReponsitory;
        }
        public ActionResult Index()
        {
            ViewBag.port = _productReponsitory.GetAll();
            return View();
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

        public PartialViewResult Header()
        {
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}