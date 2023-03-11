using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.ViewModel
{
    public class CartViewModel
    {
        public int ProductID { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; } 
    }
}
