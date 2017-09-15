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
    [Route("api/UserEvents")]
    public class UserEventsController : Controller
    {
        private readonly ItineraryAPIContext _context;

        public UserEventsController(ItineraryAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserEvents
        [HttpGet]
        public IEnumerable<UserEvents> GetUserEvents()
        {
            return _context.UserEvents;
        }

        // GET: api/UserEvents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserEvents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userEvents = await _context.UserEvents.SingleOrDefaultAsync(m => m.UserEventId == id);

            if (userEvents == null)
            {
                return NotFound();
            }

            return Ok(userEvents);
        }

        // PUT: api/UserEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEvents([FromRoute] int id, [FromBody] UserEvents userEvents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userEvents.UserEventId)
            {
                return BadRequest();
            }

            _context.Entry(userEvents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEventsExists(id))
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

        // POST: api/UserEvents
        [HttpPost]
        public async Task<IActionResult> PostUserEvents([FromBody] UserEvents userEvents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserEvents.Add(userEvents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEvents", new { id = userEvents.UserEventId }, userEvents);
        }

        // DELETE: api/UserEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEvents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userEvents = await _context.UserEvents.SingleOrDefaultAsync(m => m.UserEventId == id);
            if (userEvents == null)
            {
                return NotFound();
            }

            _context.UserEvents.Remove(userEvents);
            await _context.SaveChangesAsync();

            return Ok(userEvents);
        }

        private bool UserEventsExists(int id)
        {
            return _context.UserEvents.Any(e => e.UserEventId == id);
        }
    }
}