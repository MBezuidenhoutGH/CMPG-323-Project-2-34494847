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

        //Create a GET method that retrieves
        //all Category entries from the
        //database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        //Create a GET method that will
        //retrieve one Category from the
        //database based on the ID parsed
        //through
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

        //Create a POST method that will
        //create a new Category entry on the
        //database
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

        //Create a PATCH method that will
        //update an existing Category entry
        //on the database
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

        //Create a DELETE method that will
        //delete an existing Category entry
        //on the database
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

        //Add a private method in the API
        //that checks if a Category exists
        //(based on the ID parsed through)
        //before editing or deleting an item
        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

        //Create a GET method that retrieves
        //all devices within a specific
        //category(based on the category ID
        //that is parsed through)
        [HttpGet("GETDevicesWithCategoryID")]
        public async Task<Object> GETDevicesWithCategory(Guid ID)
        {
            var results = await _context.Category.Join(
                            _context.Device, //GET THE DEVICES
                            firstentity => firstentity.CategoryId,
                            secondentity => secondentity.CategoryId,
                            (firstentity, secondentity) => new
                            {
                                FirstEntity = firstentity,
                                SecondEntity = secondentity
                            })
                            .Where(x => x.FirstEntity.CategoryId == ID) //BASED ON THE CATEGORY ID BEING PARSED
                            .ToListAsync();


            return results;
        }

        //Create a GET method that will
        //return the number of zones that are
        //associated to a specific category
        //(use the device entity to join the
        //data)
        [HttpGet("GETNumberOfZonesWithCategoryID")]
        public async Task<int> GETZonesWithCategory(Guid ID)
        {
            int count = await _context.Zone.Join(
                            _context.Device,
                            firstentity => firstentity.ZoneId,
                            secondentity => secondentity.ZoneId, 
                            (firstentity, secondentity) => new
                            {
                                FirstEntity = firstentity,
                                SecondEntity = secondentity
                            })
                            .Where(x => x.SecondEntity.CategoryId == ID) //BASED ON THE CATEGORY ID BEING PARSED
                            .CountAsync();


            return count;
        }
    }
}