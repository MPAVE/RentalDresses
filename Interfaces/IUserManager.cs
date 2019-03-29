using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace Interfaces
{
    public interface IUserManager
    {
        bool CreateUser(User user);
        bool IsRegister(string username, string password);
    }
}
