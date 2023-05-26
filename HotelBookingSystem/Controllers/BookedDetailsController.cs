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

        
        [HttpGet]
        public async Task<ActionResult<List<BookedDetails>>> GetBookedDetails()
        {
          try 
          {
                return await _context.BookedDetails.ToListAsync();
           }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/BookedDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedDetails>> GetBookedDetails(int id)
        {
            try
            {
                return await _context.GetBookedDetails(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

      
        }

    }
}
