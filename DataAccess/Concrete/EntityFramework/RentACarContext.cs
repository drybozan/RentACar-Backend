using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres; Password=12345; Database=RentACar; Pooling=true");
        }

        public DbSet<Car> cars { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Colour> colours { get; set; }      
        public DbSet<Customer> customers { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<CarImage> car_images { get; set; }
        public DbSet<User> userss { get; set; }
        public DbSet<UserOperationClaim> user_operation_claims { get; set; }
        public DbSet<OperationClaim> operation_claims { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<CreditCard> credit_card{ get; set; }
    }
}
