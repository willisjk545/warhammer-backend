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
    public class FactionsController : ControllerBase
    {
        private readonly WarhammerContext _context;

        public FactionsController(WarhammerContext context)
        {
            _context = context;
        }

        // GET: api/Factions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factions>>> GetFactions()
        {
            return await _context.Factions.ToListAsync();
        }

        // GET: api/Factions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factions>> GetFactions(int id)
        {
            var factions = await _context.Factions.FindAsync(id);

            if (factions == null)
            {
                return NotFound();
            }

            return factions;
        }

        // PUT: api/Factions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactions(int id, Factions factions)
        {
            if (id != factions.Id)
            {
                return BadRequest();
            }

            _context.Entry(factions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactionsExists(id))
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

        // POST: api/Factions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Factions>> PostFactions(Factions factions)
        {
            _context.Factions.Add(factions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactions", new { id = factions.Id }, factions);
        }

        // DELETE: api/Factions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factions>> DeleteFactions(int id)
        {
            var factions = await _context.Factions.FindAsync(id);
            if (factions == null)
            {
                return NotFound();
            }

            _context.Factions.Remove(factions);
            await _context.SaveChangesAsync();

            return factions;
        }

        private bool FactionsExists(int id)
        {
            return _context.Factions.Any(e => e.Id == id);
        }
    }
}
