using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using PagedList;

namespace BusinessLogic
{
    public class SqlRentalsManager : IRentalsManager
    {
        private readonly RentalDressesEntities1 rd;

        public SqlRentalsManager()
        {
            rd = new RentalDressesEntities1();
        }

        public Rentals GetByDateRented(DateTime daterented)
        {
            return rd.Rentals.Where(x => x.DateRented == daterented).FirstOrDefault();
        }
        public IPagedList<Rentals> GetAll(string search, int? page)
        {
            var list = rd.Rentals.Where(r => r.Customers.FirstName.StartsWith(search)|| r.Dresses.Brand.StartsWith(search)||search==null).ToList().ToPagedList(page ?? 1, 3);
            return list;
        }
      

        public Rentals GetDetailsById(int id)
        {
            return rd.Rentals.Where(x => x.RentalId == id).FirstOrDefault();
        }
        public void Save(Rentals rental)
        {
            Rentals r = this.GetDetailsById(rental.RentalId);
            if (r == null)
            {
                rd.Rentals.Add(rental);
                rd.SaveChanges();
            }
            else
            {
                throw new Exception("We already have this rentalID");
            }
        }
        public Rentals Update(Rentals rental)
        {
            Rentals r = this.GetDetailsById(rental.RentalId);
            r.DateRented = rental.DateRented;
            r.CustomerId = rental.CustomerId;
            r.DressId = rental.DressId;
            r.Dresses = rental.Dresses;
            r.Customers = rental.Customers;

            rd.SaveChanges();
            return r;
        }

        

        public bool DeleteById(int id)
        {
            var rental = rd.Rentals.Where(x => x.RentalId == id).FirstOrDefault();
            if (rental != null)
            {
                rd.Rentals.Remove(rental);
                rd.SaveChanges();
                return true;
            }
            return false;
        }



    }
}
