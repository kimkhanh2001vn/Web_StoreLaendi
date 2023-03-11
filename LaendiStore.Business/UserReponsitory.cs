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
    public class UserReponsitory : GenericRepository<User>, IUserRepository
    {
        private eLaendiStoreDBContext _context = null;
        public UserReponsitory()
        {
            this._context = new eLaendiStoreDBContext();
        }
        public User GetByUserName(string username)
        {
            return _context.Users.SingleOrDefault(x => x.UserName == username);
        }
        public int Login(string username, string password)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserName == username);
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
    }
}
