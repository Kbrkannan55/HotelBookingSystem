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
    public class BookedDetailsController : ControllerBase
    {
        private readonly HotelBookingDBContext _context;

        public BookedDetailsController(HotelBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/BookedDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedDetails>>> GetBookedDetails()
        {
          if (_context.BookedDetails == null)
          {
              return NotFound();
          }
            return await _context.BookedDetails.ToListAsync();
        }

        // GET: api/BookedDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedDetails>> GetBookedDetails(int id)
        {
          if (_context.BookedDetails == null)
          {
              return NotFound();
          }
            var bookedDetails = await _context.BookedDetails.FindAsync(id);

            if (bookedDetails == null)
            {
                return NotFound();
            }

            return bookedDetails;
        }

        // PUT: api/BookedDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookedDetails(int id, BookedDetails bookedDetails)
        {
            if (id != bookedDetails.BookingID)
            {
                return BadRequest();
            }

            _context.Entry(bookedDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookedDetailsExists(id))
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

        // POST: api/BookedDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookedDetails>> PostBookedDetails(BookedDetails bookedDetails)
        {
          if (_context.BookedDetails == null)
          {
              return Problem("Entity set 'HotelBookingDBContext.BookedDetails'  is null.");
          }
            _context.BookedDetails.Add(bookedDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookedDetailsExists(bookedDetails.BookingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookedDetails", new { id = bookedDetails.BookingID }, bookedDetails);
        }

        // DELETE: api/BookedDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookedDetails(int id)
        {
            if (_context.BookedDetails == null)
            {
                return NotFound();
            }
            var bookedDetails = await _context.BookedDetails.FindAsync(id);
            if (bookedDetails == null)
            {
                return NotFound();
            }

            _context.BookedDetails.Remove(bookedDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookedDetailsExists(int id)
        {
            return (_context.BookedDetails?.Any(e => e.BookingID == id)).GetValueOrDefault();
        }
    }
}
