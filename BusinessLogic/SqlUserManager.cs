using App.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SqlUserManager : IUserManager
    {
        private readonly RentalDressesEntities1 rd;

        public SqlUserManager()
        {
            rd = new RentalDressesEntities1();
        }

        public bool CreateUser(User user)
        {
            bool isCreated;
            User userEntity = rd.User.FirstOrDefault(x => x.UserName == user.UserName);
            if (userEntity == null)
            {
                rd.User.Add(user);
                rd.SaveChanges();
                isCreated = true;
            }
            else
            {
                isCreated = false;
            }
            return isCreated;
        }
        public bool IsRegister(string username, string password)
        {
            bool isRegister;
            User userEntity = rd.User.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (userEntity == null)
            {
                isRegister = false;
            }
            else
            {
                isRegister = true;
            }
            return isRegister;
        }

    }
}
