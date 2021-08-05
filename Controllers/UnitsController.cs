using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _40K.Models;

namespace _40K.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly WarhammerContext _context;

        public UnitsController(WarhammerContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Units>>> GetUnits()
        {
            return await _context.Units.ToListAsync();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Units>> GetUnits(int id)
        {
            var units = await _context.Units.FindAsync(id);

            if (units == null)
            {
                return NotFound();
            }

            return units;
        }

        // GET: api/Armies/byArmyID/1
        [HttpGet("byArmyID/{armyid}")]
        public async Task<ActionResult<IEnumerable<Units>>> GetUnitsByArmyID(int armyid)
        {
            var units = _context.Units.AsQueryable();

            units = _context.Units.Where(i => i.ArmyID == armyid);

            return Ok(await units.ToListAsync());
        }

        // PUT: api/Units/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutUnits(int id, Units units)
        {
            _context.Entry(units).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsExists(id))
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

        // POST: api/Units
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Units>> PostUnits(Units units)
        {
            _context.Units.Add(units);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnits", new { id = units.Id }, units);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Units>> DeleteUnits(int id)
        {
            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }

            _context.Units.Remove(units);
            await _context.SaveChangesAsync();

            return units;
        }

        private bool UnitsExists(int id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}
