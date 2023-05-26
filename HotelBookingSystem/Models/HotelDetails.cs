using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Models
{
    public class HotelDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelID { get; set; }
        [Required]
        public string? HotelName { get; set; }
        [Required]
        public string? HotelLocation { get; set; }

        public ICollection<RoomDetails> RoomDetails { get; set; } = new List<RoomDetails>();
        public ICollection<BookedDetails> BookedDetails { get; set; } = new List<BookedDetails>();
    }
}
