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
    public class FasegruposController : ControllerBase
    {
        private readonly traderapp_qatarContext _context;

        public FasegruposController(traderapp_qatarContext context)
        {
            _context = context;
        }

        // GET: api/Fasegrupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fasegrupo>>> GetFasegrupos()
        {
            return await _context.Fasegrupos.ToListAsync();
        }

        // GET: api/Fasegrupos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fasegrupo>> GetFasegrupo(int id)
        {
            var fasegrupo = await _context.Fasegrupos.FindAsync(id);

            if (fasegrupo == null)
            {
                return NotFound();
            }

            return fasegrupo;
        }

        // PUT: api/Fasegrupos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFasegrupo(int id, Fasegrupo fasegrupo)
        {
            if (id != fasegrupo.Id)
            {
                return BadRequest();
            }

            _context.Entry(fasegrupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FasegrupoExists(id))
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

        // POST: api/Fasegrupos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fasegrupo>> PostFasegrupo(Fasegrupo fasegrupo)
        {
            _context.Fasegrupos.Add(fasegrupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFasegrupo", new { id = fasegrupo.Id }, fasegrupo);
        }

        // DELETE: api/Fasegrupos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFasegrupo(int id)
        {
            var fasegrupo = await _context.Fasegrupos.FindAsync(id);
            if (fasegrupo == null)
            {
                return NotFound();
            }

            _context.Fasegrupos.Remove(fasegrupo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FasegrupoExists(int id)
        {
            return _context.Fasegrupos.Any(e => e.Id == id);
        }
    }
}
