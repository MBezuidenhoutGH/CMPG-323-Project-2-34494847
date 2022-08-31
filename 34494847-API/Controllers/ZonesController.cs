using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _34494847_API.Models;
using Microsoft.AspNetCore.Authorization;
using _34494847_API.Authentication;

namespace _34494847_API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Create a GET method that retrieves
        //all Zone entries from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZone()
        {
            return await _context.Zone.ToListAsync();
        }

        //Create a GET method that will
        //retrieve one Zone from the
        //database based on the ID parsed
        //through
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZone(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);

            if (!ZoneExists(id))
            {
                return NotFound();
            }

            return zone;
        }

        //Create a POST method that will
        //create a new Zone entry on the
        //database
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
            _context.Zone.Add(zone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZoneExists(zone.ZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZone", new { id = zone.ZoneId }, zone);
        }

        //Create a PATCH method that will
        //update an existing Zone entry on
        //the database
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZone(Guid id, Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            _context.Entry(zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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
        //delete an existing Zone entry on
        //the database
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zone>> DeleteZone(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            if (!ZoneExists(id))
            {
                return NotFound();
            }

            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        //Add a private method in the API
        //that checks if a Zone exists(based
        //on the ID parsed through) before
        //editing or deleting an item
        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

        //Create a GET method that retrieves
        //all devices within a specific zone
        //(based on the zone ID that is
        //parsed through)
        [HttpGet("GETDevicesWithZoneID")]
        public async Task<Object> GETDevicesWithZoneID(Guid ID)
        {
            var results = await _context.Zone.Join(
                            _context.Device,
                            firstentity => firstentity.ZoneId,
                            secondentity => secondentity.ZoneId, //error
                            (firstentity, secondentity) => new
                            {
                                FirstEntity = firstentity,
                                SecondEntity = secondentity
                            })
                            .Where(x => x.FirstEntity.ZoneId == ID) //IMPORTANT
                            .ToListAsync();


            return results;
        }
    }
}
