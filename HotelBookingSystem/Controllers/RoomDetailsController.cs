using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly HotelBookingDBContext _context;

        public RoomDetailsController(HotelBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDetails>>> GetRoomDetails()
        {
          if (_context.RoomDetails == null)
          {
              return NotFound();
          }
            return await _context.RoomDetails.ToListAsync();
        }

        // GET: api/RoomDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetails>> GetRoomDetails(int id)
        {
          if (_context.RoomDetails == null)
          {
              return NotFound();
          }
            var roomDetails = await _context.RoomDetails.FindAsync(id);

            if (roomDetails == null)
            {
                return NotFound();
            }

            return roomDetails;
        }

        // PUT: api/RoomDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDetails(int id, RoomDetails roomDetails)
        {
            if (id != roomDetails.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(roomDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomDetailsExists(id))
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

        // POST: api/RoomDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDetails>> PostRoomDetails(RoomDetails roomDetails)
        {
          if (_context.RoomDetails == null)
          {
              return Problem("Entity set 'HotelBookingDBContext.RoomDetails'  is null.");
          }
            _context.RoomDetails.Add(roomDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomDetailsExists(roomDetails.RoomID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomDetails", new { id = roomDetails.RoomID }, roomDetails);
        }

        // DELETE: api/RoomDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomDetails(int id)
        {
            if (_context.RoomDetails == null)
            {
                return NotFound();
            }
            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            _context.RoomDetails.Remove(roomDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomDetailsExists(int id)
        {
            return (_context.RoomDetails?.Any(e => e.RoomID == id)).GetValueOrDefault();
        }
    }
}
