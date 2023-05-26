using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Repository.RoomServices
{
    public interface IRoomServices
    {
        Task<List<RoomDetails>> PostRoomDetails(RoomDetails roomdetails);
        Task<List<RoomDetails>> GetRoomDetails();
        Task<List<RoomDetails>> GetRoomDetailsByID(int id);
    }
}
