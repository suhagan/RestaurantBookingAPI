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
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) {}

        // Define DbSet for each model
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        // Configuring relationships (optional, if needed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining relationships and any additional configuration
        }
    }
}
