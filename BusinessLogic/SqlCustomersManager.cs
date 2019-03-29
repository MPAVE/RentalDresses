using App.Models;
using Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SqlCustomersManager : ICustomersManager
    {
        private readonly RentalDressesEntities1 rd;

        public SqlCustomersManager()
        {
            rd = new RentalDressesEntities1();
        }

        public Customers GetByFirstName(string firstname)
        {
            return rd.Customers.Where(x => x.FirstName == firstname).FirstOrDefault();
        }
       
        public IPagedList<Customers> GetAll(string search, int? page)
        {
            var list =rd.Customers.Where(r => r.FirstName.StartsWith(search) || r.LastName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3);
            return list;
        }
        public Customers GetDetailsById(int id)
        {
            return rd.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }
        public void Save(Customers customer)
        {
            Customers c = this.GetDetailsById(customer.CustomerId);
            if (c == null)
            {
                rd.Customers.Add(customer);
                rd.SaveChanges();
            }
            else
            {
                throw new Exception("WE Already have this customer");
            }
        }


        public Customers Update(Customers customer)
        {
            Customers c = this.GetDetailsById(customer.CustomerId);
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.Email = customer.Email;
            c.Phone = customer.Phone;
            c.Rentals = customer.Rentals;

            rd.SaveChanges();
            return c;
        }

      

        public bool DeleteById(int id)
        {
            var customer = rd.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (customer != null)
            {
                rd.Customers.Remove(customer);
                rd.SaveChanges();
                return true;
            }
            return false;
        }

       
    }
}
