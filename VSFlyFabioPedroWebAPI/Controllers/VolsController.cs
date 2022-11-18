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
    public class VolsController : ControllerBase
    {
        private readonly VSFlyContext _context;

        public VolsController(VSFlyContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVolSet()
        {
            return await _context.VolSet.ToListAsync();
        }

        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id)
        {
            var vol = await _context.VolSet.FindAsync(id);

            if (vol == null)
            {
                return NotFound();
            }

            return vol;
        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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

        // POST: api/Vols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.VolSet.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVol(int id)
        {
            var vol = await _context.VolSet.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.VolSet.Remove(vol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolExists(int id)
        {
            return _context.VolSet.Any(e => e.VolId == id);
        }
    }
}
