﻿using System;
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
    public class ArmiesController : ControllerBase
    {
        private readonly masterContext _context;

        public ArmiesController(masterContext context)
        {
            _context = context;
        }

        // GET: api/Armies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Armies>>> GetArmies()
        {
            return await _context.Armies.ToListAsync();
        }

        // GET: api/Armies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Armies>> GetArmiesByID(int id)
        {
            var armies = await _context.Armies.FindAsync(id);

            if (armies == null)
            {
                return NotFound();
            }

            return armies;
        }

        // GET: api/Armies/byFactionID/1
        [HttpGet("byFactionID/{factionId}")]
        public async Task<ActionResult<IEnumerable<Armies>>> GetArmiesByFactionID(int factionId)
        {
            var armies = _context.Armies.AsQueryable();

                armies = _context.Armies.Where(i => i.FactionID == factionId);

            return Ok(await armies.ToListAsync());
        }

        // PUT: api/Armies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmies(int id, Armies armies)
        {
            if (id != armies.Id)
            {
                return BadRequest();
            }

            _context.Entry(armies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmiesExists(id))
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

        // POST: api/Armies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Armies>> PostArmies(Armies armies)
        {
            _context.Armies.Add(armies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmies", new { id = armies.Id }, armies);
        }

        // DELETE: api/Armies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Armies>> DeleteArmies(int id)
        {
            var armies = await _context.Armies.FindAsync(id);
            if (armies == null)
            {
                return NotFound();
            }

            _context.Armies.Remove(armies);
            await _context.SaveChangesAsync();

            return armies;
        }

        private bool ArmiesExists(int id)
        {
            return _context.Armies.Any(e => e.Id == id);
        }
    }
}
