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
    public class RéservationController : ControllerBase
    {
        private readonly VSFlyContext _context;

        public RéservationController(VSFlyContext context)
        {
            _context = context;
        }

        // GET: api/Réservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Réservation>>> GetRéservationSet()
        {
            return await _context.RéservationSet.ToListAsync();
        }

        // GET: api/Réservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Réservation>> GetRéservation(int id)
        {
            var réservation = await _context.RéservationSet.FindAsync(id);

            if (réservation == null)
            {
                return NotFound();
            }

            return réservation;
        }

        // PUT: api/Réservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRéservation(int id, Réservation réservation)
        {
            if (id != réservation.RéservationId)
            {
                return BadRequest();
            }

            _context.Entry(réservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RéservationExists(id))
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

        // POST: api/Réservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Réservation>> PostRéservation(Réservation réservation)
        {
            _context.RéservationSet.Add(réservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRéservation", new { id = réservation.RéservationId }, réservation);
        }

        // DELETE: api/Réservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRéservation(int id)
        {
            var réservation = await _context.RéservationSet.FindAsync(id);
            if (réservation == null)
            {
                return NotFound();
            }

            _context.RéservationSet.Remove(réservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RéservationExists(int id)
        {
            return _context.RéservationSet.Any(e => e.RéservationId == id);
        }
    }
}
