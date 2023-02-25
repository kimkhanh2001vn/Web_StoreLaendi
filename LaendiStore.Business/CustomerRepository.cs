using LaendiStore.Data.DBContext;
using LaendiStore.Data.EF;
using LaendiStore.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.Business
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private eLaendiStoreDBContext _context = null;
        public CustomerRepository()
        {
            this._context = new eLaendiStoreDBContext();
        }

        public bool Login(string username, string password)
        {
            var customerLogin = _context.Customers.Where(x => x.UserName == username && x.PassWord == password).ToList();

            return customerLogin != null ? true : false;
        }
    }
}
