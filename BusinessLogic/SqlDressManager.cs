using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;

using Interfaces;
using PagedList;

namespace BusinessLogic
{
    public class SqlDressManager : IDressManager
    {
        private readonly RentalDressesEntities1 rd;

        public SqlDressManager()
        {
            rd = new RentalDressesEntities1();
        }

        public Dresses GetByTitle(string title)
        {
            return rd.Dresses.Where(x => x.Title == title).FirstOrDefault();
        }

        public IPagedList<Dresses> GetAll(string search, int? page)
        {
            var list = rd.Dresses.Where(d => d.Brand.StartsWith(search) || d.Colour.StartsWith(search) || d.Size.StartsWith(search) || d.Title.StartsWith(search)|| d.Style.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3);
            return list;
        }


        public Dresses GetDetailsById(int id)
        {
            return rd.Dresses.Where(x => x.DressId == id).FirstOrDefault();
        }


        public void Save(Dresses dress)
        {
            Dresses d = this.GetDetailsById(dress.DressId);
            if (d == null)
            {
                rd.Dresses.Add(dress);
                rd.SaveChanges();
            }
            else
            {
                throw new Exception("WE Already have this dress");
            }
        }


        public Dresses Update(Dresses dress)
        {
            Dresses d = this.GetDetailsById(dress.DressId);
            d.Brand = dress.Brand;
            d.Colour = dress.Colour;
            d.Length = dress.Length;
            d.Title = dress.Title;
            d.Price = dress.Price;
            d.Size = dress.Size;
            d.Style = dress.Style;

            rd.SaveChanges();
            return d;
        }

        

        public bool DeleteById(int id)
        {
            var dress = rd.Dresses.Where(x => x.DressId == id).FirstOrDefault();
            if (dress != null)
            {
                rd.Dresses.Remove(dress);
                rd.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
