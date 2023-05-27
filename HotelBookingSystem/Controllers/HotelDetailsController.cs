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
            try
            {


                return await _context.GetHotelDetails();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("Add New Hotels")]
        public async Task<ActionResult<List<HotelDetails>>> PostHotelDetails(HotelDetails hotelDetails)
        {
            try
            {


                return await _context.PostHotelDetails(hotelDetails);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("Delete Specific Hotel By its ID")]
        public async Task<string> DeleteDetails(int id)
        {
                return await _context.DeleteDetails(id);
          
        }

        [HttpGet]
        public async Task<ActionResult<RoomDetails>> GetHotelDetails(int id)
        {
            try
            {
                return await _context.GetHotelDetails(id);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Search by Amenities")]
        public async Task<ActionResult<List<HotelDetails>>> HotelDetailsByAmenities()
        {
            try
            {
                return await _context.HotelDetailsByAmenities();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Total Hotels Count")]
        public async Task<ActionResult<object>> HotelsCount()
        {
            try
            {
                return await _context.HotelsCount();

               
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
