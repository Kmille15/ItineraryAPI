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
using System.Net.Http.Headers;
using System.IO;

namespace ItineraryAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/UserGuides")]
    public class UserGuidesController : Controller
    {
        private readonly ItineraryAPIContext _context;

        public UserGuidesController(ItineraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserGuides
        [Authorize]
        [HttpGet]
        public IEnumerable<UserGuides> GetUserGuides()
        {
            return _context.UserGuides;
        }

        // GET: api/UserGuides/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGuides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGuides = await _context.UserGuides.SingleOrDefaultAsync(m => m.UserGuideId == id);

            if (userGuides == null)
            {
                return NotFound();
            }

            return Ok(userGuides);
        }

        // PUT: api/UserGuides/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGuides([FromRoute] int id, [FromBody] UserGuides userGuides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userGuides.UserGuideId)
            {
                return BadRequest();
            }

            _context.Entry(userGuides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGuidesExists(id))
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

        // POST: api/UserGuides
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostUserGuides([FromBody] UserGuides userGuides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserGuides.Add(userGuides);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGuides", new { id = userGuides.UserGuideId }, userGuides);
        }

        // DELETE: api/UserGuides/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGuides([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGuides = await _context.UserGuides.SingleOrDefaultAsync(m => m.UserGuideId == id);
            if (userGuides == null)
            {
                return NotFound();
            }

            _context.UserGuides.Remove(userGuides);
            await _context.SaveChangesAsync();

            return Ok(userGuides);
        }

        private bool UserGuidesExists(int id)
        {
            return _context.UserGuides.Any(e => e.UserGuideId == id);
        }
    }
}