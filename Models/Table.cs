using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBookingAPI.Models
{
    public class Table
    {
        [Key]  // Specifies the primary key for the Table model
        public int TableId { get; set; }
        
        [Required]  // Makes this field required
        public int NumOfSeats { get; set; }  // Number of seats at the table
        
        [Required]
        public int TableNumber { get; set; }  // Unique identifier for the table
    }
}
