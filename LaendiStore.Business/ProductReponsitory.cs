using LaendiStore.IBusiness;
using LaendiStore.Data.DBContext;
using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Business
{
    public class ProductReponsitory : GenericRepository<Product>,IProductReponsitory
    {
        private eLaendiStoreDBContext _context = null;
        public ProductReponsitory()
        {
            this._context = new eLaendiStoreDBContext();       
        }
    }
}
