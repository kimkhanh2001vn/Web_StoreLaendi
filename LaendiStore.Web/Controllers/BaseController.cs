using LaendiStore.Business;
using LaendiStore.Common;
using LaendiStore.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaendiStore.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Get Service
        public static IProductReponsitory _productReponsitory { get { return ConvertClass.Singleton<ProductReponsitory>(); } }
        public static ICategoryReponsitory _categoryReponsitory { get { return ConvertClass.Singleton<CategoryReponsitory>(); } }
        public static ICustomerRepository _customerRepository { get { return ConvertClass.Singleton<CustomerRepository>(); } }
        #endregion
    }
}