using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.IBusiness
{
    public interface IUserRepository : IGenericReponsitory<User>
    {
        int Login(string username, string password);
        User GetByUserName(string username);
    }
}
