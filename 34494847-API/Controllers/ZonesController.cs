﻿using System;
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
    public class ZonesController : ControllerBase
    {
        private readonly ConnectedOfficeContext _context;

        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

        public ZonesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZone()
        {
            return await _context.Zone.ToListAsync();
        }

        // GET: api/Zones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZone(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);

            if(!ZoneExists(id))
            {
                return NotFound();
            }

            return zone;
        }

        //Has the student created a a GET method that retrieves all devices within a specific zone (based on the zone ID that is parsed through)?
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

        // PUT: api/Zones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // POST: api/Zones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // DELETE: api/Zones/5
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

    }
}
