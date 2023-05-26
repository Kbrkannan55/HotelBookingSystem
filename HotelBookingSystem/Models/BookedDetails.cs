using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Models
{
    public class BookedDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingID { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        [ForeignKey(nameof(HotelDetails))]
        public int HotelID { get; set; }
        [ForeignKey(nameof(RoomDetails))]
        public int RoomID { get; set; }

       public RoomDetails? RoomDetails { get; set; }
        public Customer? Customer { get; set; }

    }
}
