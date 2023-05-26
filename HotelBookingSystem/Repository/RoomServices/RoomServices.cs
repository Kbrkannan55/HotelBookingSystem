using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repository.RoomServices
{
    public class RoomServices : IRoomServices
    {
        private readonly HotelBookingDBContext _context;

        public RoomServices(HotelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<List<RoomDetails>> PostRoomDetails(RoomDetails roomdetails)
        {

            _context.RoomDetails.Add(roomdetails);
            _context.SaveChanges();
            return await _context.RoomDetails.ToListAsync();
        }

        public  async Task<List<RoomDetails>> GetRoomDetails()
        {
            var room = await _context.RoomDetails.ToListAsync();
            if (room ==null)
            {
                throw new ArithmeticException("No Rooms Available");
            }     
            return room;
        }

        public async Task<List<RoomDetails>> GetRoomDetailsByID(int id)
        {
            if(id==null)
                throw new ArithmeticException("ID doesn't match");
            var room=await _context.RoomDetails.FirstOrDefaultAsync(x=>x.HotelID==id);
            return await _context.RoomDetails.ToListAsync();
        }

       public async Task<List<RoomDetails>> FilterRoom()
        {
            var room = _context.RoomDetails.Where(x => x.RoomStatus == "Available");
            return room.ToList();
        }


    }
}
