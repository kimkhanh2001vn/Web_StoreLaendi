using LaendiStore.Business;
using LaendiStore.Common;
using LaendiStore.Data.EF;
using LaendiStore.IBusiness;
using LaendiStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        public static IUserRepository _userRepository { get { return ConvertClass.Singleton<UserReponsitory>(); } }
        // GET: Admin/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userRepository.Login(model.UserName, model.PassWord);
                if (result == 1)
                {
                    var userByUsername = _userRepository.GetByUserName(model.UserName);
                    var userSession = new User();
                    userSession.UserName = userByUsername.UserName;
                    userSession.UserID = userByUsername.UserID;
                    userSession.Name = userByUsername.Name;
                    Session.Add(CommonStants.User_Session, userSession);
                    Session[CommonStants.username_User] = userByUsername.Name;
                    Session[CommonStants.ID_User] = userByUsername.UserID;
                    //Session["ID"] = model.UserID;
                    //HttpContext.Application["ID"] = userByUsername.UserID;
                    return RedirectToAction("index", "home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", Resources.Common.MsgAccountNotContain);
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", Resources.Common.MsgAccountIsLock);
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", Resources.Common.MsgPassworkIsNotVaild);
                }
                else
                {
                    ModelState.AddModelError("", Resources.Common.MsgUserIsNotVaild);
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }

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

        public ActionResult Logout()
        {
            Session[CommonStants.User_Session] = null;
            Session[CommonStants.username_User] = null;
            Session[CommonStants.ID_User] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }
    }
}