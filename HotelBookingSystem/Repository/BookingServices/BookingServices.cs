using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repository.BookingServices
{
    public class BookingServices : IBookingServices
    {

        private readonly HotelBookingDBContext _context;
        public BookingServices(HotelBookingDBContext context)
        {
            _context = context;
        }   

        public async Task<List<BookedDetails>> GetBookedDetails()
        {
            if(_context == null)
            {
                throw new ArithmeticException("Valid is not Valid");
            }
            var book = await _context.BookedDetails.ToListAsync();
            return book;
        }

        public async Task<BookedDetails> GetBookedDetails(int id)
        {
            if(id<0)
                throw new ArithmeticException("Not Valid");
            var book=await _context.BookedDetails.FirstOrDefaultAsync(x=>x.RoomID==id);
            return book;
        }


    }
}
