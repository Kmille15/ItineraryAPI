using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItineraryAPI.Data;
using ItineraryAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ItineraryAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Guides")]
    public class GuidesController : Controller
    {
        private readonly ItineraryAPIContext _context;

        public GuidesController(ItineraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/Guides
        [HttpGet]
        public IEnumerable<Guides> GetGuides()
        {
            return _context.Guides;
        }

        // GET: api/Guides/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guides = await _context.Guides.SingleOrDefaultAsync(m => m.GuideId == id);

            if (guides == null)
            {
                return NotFound();
            }

            return Ok(guides);
        }

        // PUT: api/Guides/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuides([FromRoute] int id, [FromBody] Guides guides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guides.GuideId)
            {
                return BadRequest();
            }

            _context.Entry(guides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuidesExists(id))
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

        // POST: api/Guides
        [HttpPost]
        public async Task<IActionResult> PostGuides([FromBody] Guides guides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Guides.Add(guides);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuides", new { id = guides.GuideId }, guides);
        }

        // DELETE: api/Guides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guides = await _context.Guides.SingleOrDefaultAsync(m => m.GuideId == id);
            if (guides == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guides);
            await _context.SaveChangesAsync();

            return Ok(guides);
        }

        private bool GuidesExists(int id)
        {
            return _context.Guides.Any(e => e.GuideId == id);
        }
    }
}