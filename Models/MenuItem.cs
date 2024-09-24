using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBookingAPI.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuId { get; set; }
        
        public required string ItemName { get; set; }  // Name of the menu item
        
        [Required]
        public decimal ItemPrice { get; set; }  // Price of the item
        
        [Required]
        public bool ItemAvailable { get; set; }  // Availability of the item
    }
}
