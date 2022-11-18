using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSFlyFabioPedro;
using VSFlyFabioPedro.Models;

namespace VSFlyFabioPedroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompagniesController : ControllerBase
    {
        private readonly VSFlyContext _context;

        public CompagniesController(VSFlyContext context)
        {
            _context = context;
        }

        // GET: api/Compagnies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnieSet()
        {
            return await _context.CompagnieSet.ToListAsync();
        }

        // GET: api/Compagnies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compagnie>> GetCompagnie(int id)
        {
            var compagnie = await _context.CompagnieSet.FindAsync(id);

            if (compagnie == null)
            {
                return NotFound();
            }

            return compagnie;
        }

        // PUT: api/Compagnies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompagnie(int id, Compagnie compagnie)
        {
            if (id != compagnie.CompagnieId)
            {
                return BadRequest();
            }

            _context.Entry(compagnie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompagnieExists(id))
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

        // POST: api/Compagnies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compagnie>> PostCompagnie(Compagnie compagnie)
        {
            _context.CompagnieSet.Add(compagnie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompagnie", new { id = compagnie.CompagnieId }, compagnie);
        }

        // DELETE: api/Compagnies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompagnie(int id)
        {
            var compagnie = await _context.CompagnieSet.FindAsync(id);
            if (compagnie == null)
            {
                return NotFound();
            }

            _context.CompagnieSet.Remove(compagnie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompagnieExists(int id)
        {
            return _context.CompagnieSet.Any(e => e.CompagnieId == id);
        }
    }
}
