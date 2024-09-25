using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBookingAPI.Data;
using RestaurantBookingAPI.Models;

namespace RestaurantBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public MenuItemsController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            
            // If no menu item is found, return a 404 Not Found status
            if (menuItem == null)
            {
                return NotFound();
            }
            return menuItem;
        }

        // POST: api/MenuItems
        // This method handles POST requests to add a new menu item to the database.
        // The [HttpPost] attribute indicates that this is a POST method.
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            // Returns a 201 Created response along with the details of the newly created menu item.
            // The "CreatedAtAction" method includes a link to the GET method for the newly created menu item.
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuId }, menuItem);
        }

        // PUT: api/MenuItems/5
        // This method handles PUT requests to update an existing menu item by its ID.
        // The [HttpPut("{id}")] attribute binds the ID in the URL to the method parameter.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            // If the ID in the URL doesn't match the ID in the menu item object, return a BadRequest response (400)
            if (id != menuItem.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If there's a concurrency issue (e.g., the menu item doesn't exist), check if the menu item still exists
                if (!MenuItemExists(id))
                {
                    return NotFound(); // Return 404 if the menu item is not found
                }
                else
                {
                    throw; // Otherwise, rethrow the exception
                }
            }

            return NoContent(); // Return NoContent (204) to indicate a successful update
            
        }

        // DELETE: api/MenuItems/5
        // This method handles DELETE requests to remove a menu item by its ID.
        // The [HttpDelete("{id}")] attribute binds the ID in the URL to the method parameter.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            
            // If the menu item is not found, return a 404 Not Found status
            
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            // Returns NoContent (204) after successful deletion
            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            // Returns true if a menu item with the specified ID exists, otherwise false
            return _context.MenuItems.Any(e => e.MenuId == id);
        }
    }
}
