using LaendiStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaendiStore.IBusiness
{
    public interface ICustomerRepository : IGenericReponsitory<Customer>
    {
        Customer GetByUserName(string username);
        int Login(string username, string password);
        bool CheckContainAccount(string email, string username);
        Customer GetbyEmailResestPassword(string email);
    }
}
