
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using HotelBookingSystem.Repository.BookingServices;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookedDetailsController : ControllerBase
    {
        private readonly IBookingServices _context;

        public BookedDetailsController(IBookingServices context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<BookedDetails>>> GetBookedDetails()
        {
         
                return await _context.GetBookedDetails();
        
            
        }

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
