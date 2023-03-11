using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.ViewModel
{
    public class ProductByCategoryViewModel
    {
        public Product products { get; set; }
        public Category categorys { get; set; }
    }
}
