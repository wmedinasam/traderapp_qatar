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
    public class UsuariosLigaController : ControllerBase
    {
        private readonly traderapp_qatarContext _context;

        public UsuariosLigaController(traderapp_qatarContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosLiga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarioliga>>> GetUsuarioligas()
        {
            return await _context.Usuarioligas.ToListAsync();
        }

        // GET: api/UsuariosLiga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarioliga>> GetUsuarioliga(int id)
        {
            var usuarioliga = await _context.Usuarioligas.FindAsync(id);

            if (usuarioliga == null)
            {
                return NotFound();
            }

            return usuarioliga;
        }

        // PUT: api/UsuariosLiga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioliga(int id, Usuarioliga usuarioliga)
        {
            if (id != usuarioliga.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioliga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioligaExists(id))
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

        // POST: api/UsuariosLiga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarioliga>> PostUsuarioliga(Usuarioliga usuarioliga)
        {
            _context.Usuarioligas.Add(usuarioliga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioliga", new { id = usuarioliga.Id }, usuarioliga);
        }

        // DELETE: api/UsuariosLiga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioliga(int id)
        {
            var usuarioliga = await _context.Usuarioligas.FindAsync(id);
            if (usuarioliga == null)
            {
                return NotFound();
            }

            _context.Usuarioligas.Remove(usuarioliga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioligaExists(int id)
        {
            return _context.Usuarioligas.Any(e => e.Id == id);
        }
    }
}
