using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UD25.Models;

namespace UD25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly APIContext _context;

        public ArticulosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulo()
        {
            return await _context.Articulo.ToListAsync();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var articulos = await _context.Articulo.FindAsync(id);

            if (articulos == null)
            {
                return NotFound();
            }

            return articulos;
        }

        // PUT: api/Articulos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
        {
            if (id != articulos.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(articulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(id))
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

        // POST: api/Articulos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
        {
            _context.Articulo.Add(articulos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulos", new { id = articulos.Codigo }, articulos);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articulos>> DeleteArticulos(int id)
        {
            var articulos = await _context.Articulo.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }

            _context.Articulo.Remove(articulos);
            await _context.SaveChangesAsync();

            return articulos;
        }

        private bool ArticulosExists(int id)
        {
            return _context.Articulo.Any(e => e.Codigo == id);
        }
    }
}
