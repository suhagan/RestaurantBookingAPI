using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBookingAPI.Models
{
    public class Customer
    {
        [Key]
        public int GuestId { get; set; }
        
        public required string GuestName { get; set; }  // Customer's name
        
        public required string GuestPhone { get; set; }  // Customer's contact information
        public required string GuestEmail { get; set; }  // Customer's contact information
        public required string GuestAddress { get; set; }  // Customer's contact information
    }
}
