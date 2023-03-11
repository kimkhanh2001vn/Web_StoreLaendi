using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
    }
}
