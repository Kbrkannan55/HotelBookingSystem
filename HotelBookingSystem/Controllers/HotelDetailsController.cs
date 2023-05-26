using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository.HotelServices;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelDetailsController : ControllerBase
    {
        private readonly IHotelServices _context;

        public HotelDetailsController(IHotelServices context)
        {
            _context = context;
        }

        [HttpGet("All Hotels Available")]
        public async Task<ActionResult<List<HotelDetails>>> GetHotelDetails()
        {
            return await _context.GetHotelDetails();
        }

        [HttpPost("Add New Hotels")]
        public async Task<ActionResult<List<HotelDetails>>> PostHotelDetails(HotelDetails hotelDetails)
        {
            return await _context.PostHotelDetails(hotelDetails);
        }

        [HttpDelete("Delete Specific Hotel By its ID")]
        public async Task<string> DeleteDetails(int id)
        {
            return await _context.DeleteDetails(id);
        }

        [HttpGet]
        public async Task<ActionResult<RoomDetails>> GetHotelDetails(int id)
        {
            return await _context.GetHotelDetails(id);
        }
    }
}
