using App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;


namespace DataAccess
{
    public partial class RentalDressesEntities : DbContext
    {
        public RentalDressesEntities()
            : base("name=RentalDressesEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Dresses> Dresses { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
