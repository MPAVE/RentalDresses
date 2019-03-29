using App.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface IRentalsManager
    {
        Rentals GetByDateRented(DateTime daterented);

        IPagedList<Rentals> GetAll(string search, int? page);

        Rentals GetDetailsById(int id);

        void Save(Rentals rental);



        Rentals Update(Rentals rental);

        

        bool DeleteById(int id);

    }
}
