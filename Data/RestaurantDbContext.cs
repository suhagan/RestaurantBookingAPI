using Microsoft.EntityFrameworkCore;
using RestaurantBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBookingAPI.Data
{

    public class RestaurantDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions to configure the context (e.g., connection strings, providers)
        // The base(options) call passes these options to the parent class DbContext
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) {}

        // Define DbSet properties for each model that will correspond to tables in the database
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        // This method is used to configure the model and the relationships between entities
        // It can be overridden to define relationships, constraints, and other database rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: We can define relationships, constraints, and additional configurations here.
            // Example: modelBuilder.Entity<Booking>().HasOne(b => b.Customer).WithMany(c => c.Bookings);
        }
    }
}
