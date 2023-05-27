using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static NuGet.Packaging.PackagingConstants;

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


        public async Task<object> RoomsCount(int id)
        {
            if (id == null)
                throw new Exception("Id is not Valid");
            var count1 = _context.RoomDetails.Count(x => x.RoomStatus == "Available");
            var count2 = _context.RoomDetails.Count(x => x.RoomStatus == "Booked");
            var count = count1 + count2;

            return count;
        }

        public async Task<object> PriceDetails()
        {
            var MaxPrice = _context.RoomDetails.Max(x => x.RoomPrice);
            return MaxPrice;
        }

        public async Task<string> DeleteRooms(int id)
        {
            if (id == null)
                throw new Exception("Id not Valid");
            var room=await _context.RoomDetails.FirstOrDefaultAsync(x=>x.RoomID==id);
            _context.Remove(room);
            _context.SaveChanges();
            return "Room Deleted Successfully";
        }
    }
}
