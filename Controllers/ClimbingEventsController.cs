using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KlimEvenementenAPI.Data;
using KlimEvenementenAPI.Models;

namespace KlimEvenementenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClimbingEventsController : ControllerBase
    {
        private readonly ClimbingEventsDBContext _context;

        public ClimbingEventsController(ClimbingEventsDBContext context)
        {
            _context = context;
        }

        // GET: api/ClimbingEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClimbingEvent>>> GetClimbingEvent()
        {
            return new List<ClimbingEvent>()
            {
                new KlimEvenementenAPI.Models.ClimbingEvent() { Id = 0, Name = "test" },
            };
        }

        // GET: api/ClimbingEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClimbingEvent>> GetClimbingEvent(int id)
        {
            var climbingEvent = await _context.ClimbingEvents.FindAsync(id);

            if (climbingEvent == null)
            {
                return NotFound();
            }

            return climbingEvent;
        }

        // PUT: api/ClimbingEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClimbingEvent(int id, ClimbingEvent climbingEvent)
        {
            if (id != climbingEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(climbingEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimbingEventExists(id))
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

        // POST: api/ClimbingEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClimbingEvent>> PostClimbingEvent(ClimbingEvent climbingEvent)
        {
            _context.ClimbingEvents.Add(climbingEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClimbingEvent", new { id = climbingEvent.Id }, climbingEvent);
        }

        // DELETE: api/ClimbingEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClimbingEvent(int id)
        {
            var climbingEvent = await _context.ClimbingEvents.FindAsync(id);
            if (climbingEvent == null)
            {
                return NotFound();
            }

            _context.ClimbingEvents.Remove(climbingEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimbingEventExists(int id)
        {
            return _context.ClimbingEvents.Any(e => e.Id == id);
        }
    }
}
