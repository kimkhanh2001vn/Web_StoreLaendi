﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Admin/Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Resest()
        {
            return View();
        }
    }
}