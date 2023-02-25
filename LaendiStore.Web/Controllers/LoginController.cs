using LaendiStore.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Controllers
{
    public class LoginController : Controller
    {
        private ICustomerRepository _customerRepository;
        public LoginController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        // GET: Login
        public ActionResult SignIn()
        {
            bool check = _customerRepository.Login("", "");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}