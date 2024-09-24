using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantBookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }  // Foreign key reference to the Table
        [ForeignKey("Customer")]
        public int GuestIdId { get; set; }  // Foreign key reference to the Customer
        
        [Required]
        public DateTime BookingDate { get; set; }  // Date of the booking
        [Required]
        public DateTime BookingTime { get; set; }  // Time of the booking
        [Required]
        public int NumberOfGuests { get; set; }  // Number of people in the booking
        
        //public Table? Table { get; set; }  // Navigation property
        
        //public Customer? Customer { get; set; }  // Navigation property
    }
}
