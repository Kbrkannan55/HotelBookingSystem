using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Repository.BookingServices
{
    public interface IBookingServices
    {
        Task<List<BookedDetails>> GetBookedDetails();

        Task<BookedDetails> GetBookedDetails(int id);
    }
}
