using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigasController : ControllerBase
    {
        private readonly traderapp_qatarContext _context;

        public LigasController(traderapp_qatarContext context)
        {
            _context = context;
        }

        // GET: api/Ligas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Liga>>> GetLigas()
        {
            return await _context.Ligas.ToListAsync();
        }

        // GET: api/Ligas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Liga>> GetLiga(int id)
        {
            var liga = await _context.Ligas.FindAsync(id);

            if (liga == null)
            {
                return NotFound();
            }

            return liga;
        }

        // PUT: api/Ligas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiga(int id, Liga liga)
        {
            if (id != liga.Id)
            {
                return BadRequest();
            }

            _context.Entry(liga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LigaExists(id))
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

        // POST: api/Ligas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Liga>> PostLiga(Liga liga)
        {
            _context.Ligas.Add(liga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiga", new { id = liga.Id }, liga);
        }

        // DELETE: api/Ligas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiga(int id)
        {
            var liga = await _context.Ligas.FindAsync(id);
            if (liga == null)
            {
                return NotFound();
            }

            _context.Ligas.Remove(liga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LigaExists(int id)
        {
            return _context.Ligas.Any(e => e.Id == id);
        }
    }
}
