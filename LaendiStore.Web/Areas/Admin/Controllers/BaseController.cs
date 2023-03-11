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
using System.Web.Routing;

namespace LaendiStore.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        #region Get Service
        public static IUserRepository _userRepository { get { return ConvertClass.Singleton<UserReponsitory>(); } }
        public static IProductReponsitory _productReponsitory { get { return ConvertClass.Singleton<ProductReponsitory>(); } }
        public static ICategoryReponsitory _categoryReponsitory { get { return ConvertClass.Singleton<CategoryReponsitory>(); } }
        public static ICustomerRepository _customerRepository { get { return ConvertClass.Singleton<CustomerRepository>(); } }

        #endregion
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var session = (User)Session[CommonStants.User_Session];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                                new
                                {
                                    controller = "Authentication",
                                    action = "Login"
                                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}