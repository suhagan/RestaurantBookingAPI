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
    // The [Route] attribute defines the route to this controller's API endpoints (e.g., /api/tables)
    // [ApiController] provides functionality specific to API controllers (e.g., automatic model validation)
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public TablesController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        // This method handles GET requests to retrieve all table records from the database.
        // It returns an IEnumerable of Table objects in an asynchronous operation.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Tables/5
        // This method handles GET requests for a specific table by its ID.
        // The {id} in the route defines a route parameter for the table ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);

            // If no table is found, return a 404 Not Found status
            if (table == null)
            {
                return NotFound();
            }
            return table;
        }

        // POST: api/Tables
        // This method handles POST requests to add a new table to the database.
        // The [HttpPost] attribute indicates that this is a POST method.
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            
            // Returns a 201 Created response along with the details of the newly created table.
            // The "CreatedAtAction" method includes a link to the GET method for the newly created table.
            return CreatedAtAction(nameof(GetTable), new { id = table.TableId }, table);
        }

        // PUT: api/Tables/5
        // This method handles PUT requests to update an existing table by its ID.
        // The [HttpPut("{id}")] attribute binds the ID in the URL to the method parameter.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, Table table)
        {
            // If the ID in the URL doesn't match the ID in the table object, return a BadRequest response (400)
            if (id != table.TableId)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
                {
                    return NotFound(); // Return 404 if the table is not found
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tables/5
        // This method handles DELETE requests to remove a table by its ID.
        // The [HttpDelete("{id}")] attribute binds the ID in the URL to the method parameter.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound(); // If the table is not found, return a 404 Not Found status
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            // Returns NoContent (204) after successful deletion
            return NoContent();
        }

        private bool TableExists(int id)
        {
            // Returns true if a table with the specified ID exists, otherwise false
            return _context.Tables.Any(e => e.TableId == id);
        }
    }
}
