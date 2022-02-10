using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRest.Data;
using ApiRest.Models;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CochesController : ControllerBase
    {
        private readonly ApiRestContext _context;

        public CochesController(ApiRestContext context)
        {
            _context = context;
        }

        // GET: api/Coches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coches>>> GetCoches()
        {
            return await _context.Coches.ToListAsync();
        }

        // GET: api/Coches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coches>> GetCoches(int id)
        {
            var coches = await _context.Coches.FindAsync(id);

            if (coches == null)
            {
                return NotFound();
            }

            return coches;
        }

        // PUT: api/Coches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoches(int id, Coches coches)
        {
            if (id != coches.Id)
            {
                return BadRequest();
            }

            _context.Entry(coches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CochesExists(id))
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

        // POST: api/Coches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coches>> PostCoches(Coches coches)
        {
            _context.Coches.Add(coches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoches", new { id = coches.Id }, coches);
        }

        // DELETE: api/Coches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoches(int id)
        {
            var coches = await _context.Coches.FindAsync(id);
            if (coches == null)
            {
                return NotFound();
            }

            _context.Coches.Remove(coches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CochesExists(int id)
        {
            return _context.Coches.Any(e => e.Id == id);
        }
    }
}
