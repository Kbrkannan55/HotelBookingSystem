using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace HotelBookingSystem.Repository.HotelServices
{
    public class HotelServices : IHotelServices
    {
        private readonly HotelBookingDBContext _context;
        public HotelServices(HotelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<List<HotelDetails>> GetHotelDetails()
        {
            var Hotels=await _context.HotelDetails.ToListAsync();
            return Hotels;
        }

        public async Task<List<HotelDetails>> PostHotelDetails( HotelDetails hotelDetails)
        {
            _context.HotelDetails.Add(hotelDetails);
            _context.SaveChanges();
            return await _context.HotelDetails.ToListAsync();
           
        }

        public async Task<string> DeleteDetails(int id)
        {
            var Hotel= await _context.HotelDetails.FirstOrDefaultAsync(x=>x.HotelID==id);
            _context.Remove(Hotel);
            _context.SaveChanges();
            return "Hotel Deleted Successfully";

         

        }

        public async Task<RoomDetails> GetHotelDetails(int id)
        {
            var Hotel = await _context.RoomDetails.FirstOrDefaultAsync(x => x.HotelID == id);
            return Hotel;


        }
    }
}
