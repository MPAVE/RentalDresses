using System;
using System.Collections.Generic;
using App.Models;
using PagedList;

namespace Interfaces
{
    public interface IDressManager
    {
        Dresses GetByTitle(string title);

        IPagedList<Dresses> GetAll(string search, int? page);

        Dresses GetDetailsById(int id);

        void Save(Dresses dress);



        Dresses Update(Dresses dress);

       

        bool DeleteById(int id);


    }
}
