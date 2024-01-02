using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUdemy.Entities;
using WebAPIUdemy.Models;

namespace WebAPIUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DBDbContext _context;

        public CitiesController(DBDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Getcity()
        {
          if (_context.city == null)
          {
              return NotFound();
          }
            return await _context.city.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {
          if (_context.city == null)
          {
              return NotFound();
          }
            var city = await _context.city.FindAsync(id);

            if (city == null)
            {
                return Problem(detail:"Invalid City ID",statusCode:404, title:"City not found");
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
          if (_context.city == null)
          {
              return Problem("Entity set 'DBDbContext.city'  is null.");
          }
            _context.city.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (_context.city == null)
            {
                return NotFound();
            }
            var city = await _context.city.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.city.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(Guid id)
        {
            return (_context.city?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
