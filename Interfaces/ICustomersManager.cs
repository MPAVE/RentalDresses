using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using PagedList;

namespace Interfaces
{
    public interface ICustomersManager
    {
        Customers GetByFirstName(string firstname);

        IPagedList<Customers> GetAll(string search, int? page);

        Customers GetDetailsById(int id);

        void Save(Customers customer);



        Customers Update(Customers customer);


        bool DeleteById(int id);
    }
}
