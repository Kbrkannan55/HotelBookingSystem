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
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
            try
            {
                return await _context.PostRoomDetails(roomdetails);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }            
        }


        [HttpGet("Available Rooms in All Hotels")]
        public async Task<ActionResult<List<RoomDetails>>> GetRoomDetails()
        {
            return await _context.GetRoomDetails();
        }

        [HttpGet("Search Rooms in specific Hotel By the Hotel ID")]
        public async Task<ActionResult<List<RoomDetails>>> GetRoomDetailsByID(int id)
        {
            try
            {
                return await _context.GetRoomDetailsByID(id);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("Available Rooms")]
        public async Task<ActionResult<List<RoomDetails>>> FilterRoom()
        {
       
           return await _context.FilterRoom();
           
        }

        [HttpGet("Available Rooms Count")]
        public async Task<ActionResult<object>> RoomsCount(int id)
        {
            try
            {
                return await _context.RoomsCount(id);
            }
            catch(ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
