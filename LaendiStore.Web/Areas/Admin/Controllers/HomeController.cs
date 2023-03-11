using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderAdmin()
        {
            return PartialView();
        }
        public PartialViewResult FooterAdmin()
        {
            return PartialView();
        }
    }
}