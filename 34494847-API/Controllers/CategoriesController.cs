using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _34494847_API.Models;

namespace _34494847_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ConnectedOfficeContext _context;

        public CategoriesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        //Has the student created a GET method that gets the devices based on a category ID being parsed in?
        [HttpGet("GETDevicesCategoryID")]
        public async Task<Object> GETDevicesWithCategory(Guid ID)
        {
            var results = await _context.Category.Join(
                            _context.Device,
                            firstentity => firstentity.CategoryId,
                            secondentity => secondentity.CategoryId, //error
                            (firstentity, secondentity) => new
                            {
                                FirstEntity = firstentity,
                                SecondEntity = secondentity
                            })
                            .Where(x => x.FirstEntity.CategoryId == ID) //IMPORTANT
                            .ToListAsync();


            return results;
        }

        //Has the student created a GET method that will return the number of zones that are associated to a specific category?
        [HttpGet("GETZonesCategoryID")]
        public async Task<int> GETZonesWithCategory(Guid ID)
        {
            int count = await _context.Zone.Join(
                            _context.Device,
                            firstentity => firstentity.ZoneId,
                            secondentity => secondentity.ZoneId, //error
                            (firstentity, secondentity) => new
                            {
                            FirstEntity = firstentity,
                            SecondEntity = secondentity
                            })
                            .Where(x => x.SecondEntity.CategoryId == ID) //IMPORTANT
                            .CountAsync();


            return count;
        }


        //TESTING
        /*[HttpGet("GETDevicesCategoryID")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevice(Guid ID)
        {

            var test = await _context.Device
                .Where(x => x.CategoryId == ID).ToListAsync();

            return test;
        }*/

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Category.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }   
    }
}