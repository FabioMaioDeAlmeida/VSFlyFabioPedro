using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSFlyFabioPedro;
using VSFlyFabioPedro.Models;
using VSFlyFabioPedroWebAPI.Extension;

namespace VSFlyFabioPedroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagersController : ControllerBase
    {
        private readonly VSFlyContext _context;

        public PassagersController(VSFlyContext context)
        {
            _context = context;
        }

        // GET: api/Passagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passager>>> GetPassagerSet()
        {
            var passagerListe = await _context.PassagerSet.ToListAsync();
            List<ModelsAPI.Passager> passagerModels = new List<ModelsAPI.Passager>();
            foreach (var passager in passagerListe)
            {
                var pass = passager.ConvertToPassagerM();
                passagerModels.Add(pass);
            }
            return await _context.PassagerSet.ToListAsync();
        }

        // GET: api/Passagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passager>> GetPassager(int id)
        {
            var passager = await _context.PassagerSet.FindAsync(id);

            if (passager == null)
            {
                return NotFound();
            }

            return passager;
        }

        // PUT: api/Passagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassager(int id, Passager passager)
        {
            if (id != passager.PassagerId)
            {
                return BadRequest();
            }

            _context.Entry(passager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagerExists(id))
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

        // POST: api/Passagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passager>> PostPassager(Passager passager)
        {
            _context.PassagerSet.Add(passager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassager", new { id = passager.PassagerId }, passager);
        }

        // DELETE: api/Passagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassager(int id)
        {
            var passager = await _context.PassagerSet.FindAsync(id);
            if (passager == null)
            {
                return NotFound();
            }

            _context.PassagerSet.Remove(passager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagerExists(int id)
        {
            return _context.PassagerSet.Any(e => e.PassagerId == id);
        }
    }
}
