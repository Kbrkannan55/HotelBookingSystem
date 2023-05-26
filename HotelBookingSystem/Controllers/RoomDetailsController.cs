using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository.RoomServices;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly IRoomServices _context;

        public RoomDetailsController(IRoomServices context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List<RoomDetails>>> PostRoomDetails(RoomDetails roomdetails)
        {
            return await _context.PostRoomDetails(roomdetails);
        }


        [HttpGet("Available Rooms in All Hotels")]
        public async Task<ActionResult<List<RoomDetails>>> GetRoomDetails()
        {
            return await _context.GetRoomDetails();
        }

        [HttpGet("Search Rooms in specific Hotel By the Hotel ID")]
        public async Task<ActionResult<List<RoomDetails>>> GetRoomDetailsByID(int id)
        {
            return await _context.GetRoomDetailsByID(id);
        }
    }
}
