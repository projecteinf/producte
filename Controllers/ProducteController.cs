using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mba.Articles;

namespace Classe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducteController : ControllerBase
    {
        private readonly DataContext _context;

        public ProducteController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Producte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producte>>> GetProductes()
        {
          if (_context.Productes == null)
          {
              return NotFound();
          }
            return await _context.Productes.ToListAsync();
        }

        // GET: api/Producte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producte>> GetProducte(int id)
        {
          if (_context.Productes == null)
          {
              return NotFound();
          }
            var producte = await _context.Productes.FindAsync(id);

            if (producte == null)
            {
                return NotFound();
            }

            return producte;
        }

        // PUT: api/Producte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducte(int id, Producte producte)
        {
            if (id != producte.Id)
            {
                return BadRequest();
            }

            _context.Entry(producte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducteExists(id))
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

        // POST: api/Producte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producte>> PostProducte(Producte producte)
        {
          if (_context.Productes == null)
          {
              return Problem("Entity set 'DataContext.Productes'  is null.");
          }
            _context.Productes.Add(producte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducte", new { id = producte.Id }, producte);
        }

        // DELETE: api/Producte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducte(int id)
        {
            if (_context.Productes == null)
            {
                return NotFound();
            }
            var producte = await _context.Productes.FindAsync(id);
            if (producte == null)
            {
                return NotFound();
            }

            _context.Productes.Remove(producte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProducteExists(int id)
        {
            return (_context.Productes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
