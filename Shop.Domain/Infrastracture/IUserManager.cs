using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database.Interfaces
{
    public interface IUserManager
    {
        Task CreateManagerUser(string username, string password);
    }
}


