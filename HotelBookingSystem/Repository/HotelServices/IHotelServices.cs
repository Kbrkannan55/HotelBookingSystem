using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Repository.HotelServices
{
    public interface IHotelServices
    {
        Task<List<HotelDetails>> GetHotelDetails();
        Task<List<HotelDetails>> PostHotelDetails(HotelDetails hoteldetails);

        Task<string> DeleteDetails(int id);

        Task<RoomDetails> GetHotelDetails(int id);

    }
}
