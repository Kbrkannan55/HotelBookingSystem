using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.Xml;

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
            if (id == null)
                throw new Exception("Not Valid");
            var Hotel= await _context.HotelDetails.FirstOrDefaultAsync(x=>x.HotelID==id);
            _context.Remove(Hotel);
            _context.SaveChanges();
            return "Hotel Deleted Successfully";

         

        }

        public async Task<RoomDetails> GetHotelDetails(int id)
        {
            if (id < 0)
                throw new Exception("Not Valid");
            var Hotel = await _context.RoomDetails.FirstOrDefaultAsync(x => x.HotelID == id);
            return Hotel;


        }

        public async Task<List<HotelDetails>> HotelDetailsByAmenities()
        {
            var Hotel = await _context.HotelDetails.Where(x => x.Amenities == "Fully Furnished").ToListAsync();
            return Hotel;
        }

        public async Task<object> HotelsCount()
        {
            var Hotel =  _context.HotelDetails.ToList().Count();
            return Hotel;
        }
    }
}
