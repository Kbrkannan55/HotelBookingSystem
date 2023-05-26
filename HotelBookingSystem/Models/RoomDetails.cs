using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Models
{
    public class RoomDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }

        [ForeignKey(nameof(HotelDetails))]
        public int HotelID { get; set; }
        [Required]
        public string? RoomStatus { get; set; }
        

        public ICollection<BookedDetails> BookedDetails { get; set; } = new List<BookedDetails>();

    }
}
