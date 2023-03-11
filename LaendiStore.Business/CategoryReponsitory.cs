using LaendiStore.Data.DBContext;
using LaendiStore.Data.EF;
using LaendiStore.IBusiness;
using System.Collections.Generic;
using System.Linq;

namespace LaendiStore.Business
{
    public class CategoryReponsitory : GenericRepository<Category>, ICategoryReponsitory

    {
        private eLaendiStoreDBContext _context = null;

        public CategoryReponsitory()
        {
            this._context = new eLaendiStoreDBContext();
        }

    }
}