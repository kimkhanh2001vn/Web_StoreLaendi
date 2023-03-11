using LaendiStore.Common;
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
        public Customer GetByUserName(string username)
        {
            return _context.Customers.SingleOrDefault(x => x.UserName == username);
        }
        public Customer GetbyEmailResestPassword(string email)
        {
            return _context.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
        }
        public int Login(string username, string password)
        {
            var result = _context.Customers.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.PassWord == Encryptor.MD5Hash(password))
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public bool CheckContainAccount(string email, string username)
        {
            var result = _context.Customers.Where(x => x.CustomerEmail == email || x.UserName == username).ToList();
            if (result.Count > 0)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            return true;
        }
    }
}
