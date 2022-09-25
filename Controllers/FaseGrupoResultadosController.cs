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
    public class FaseGrupoResultadosController : ControllerBase
    {
        private readonly traderapp_qatarContext _context;

        public FaseGrupoResultadosController(traderapp_qatarContext context)
        {
            _context = context;
        }

        // GET: api/FaseGrupoResultados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FasegruposResultado>>> GetFasegruposResultados()
        {
            return await _context.FasegruposResultados.ToListAsync();
        }

        // GET: api/FaseGrupoResultados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FasegruposResultado>> GetFasegruposResultado(int id)
        {
            var fasegruposResultado = await _context.FasegruposResultados.FindAsync(id);

            if (fasegruposResultado == null)
            {
                return NotFound();
            }

            return fasegruposResultado;
        }

        // PUT: api/FaseGrupoResultados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFasegruposResultado(int id, FasegruposResultado fasegruposResultado)
        {
            if (id != fasegruposResultado.Id)
            {
                return BadRequest();
            }

            _context.Entry(fasegruposResultado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FasegruposResultadoExists(id))
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

        // POST: api/FaseGrupoResultados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FasegruposResultado>> PostFasegruposResultado(FasegruposResultado fasegruposResultado)
        {
            _context.FasegruposResultados.Add(fasegruposResultado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFasegruposResultado", new { id = fasegruposResultado.Id }, fasegruposResultado);
        }

        // DELETE: api/FaseGrupoResultados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFasegruposResultado(int id)
        {
            var fasegruposResultado = await _context.FasegruposResultados.FindAsync(id);
            if (fasegruposResultado == null)
            {
                return NotFound();
            }

            _context.FasegruposResultados.Remove(fasegruposResultado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FasegruposResultadoExists(int id)
        {
            return _context.FasegruposResultados.Any(e => e.Id == id);
        }
    }
}
