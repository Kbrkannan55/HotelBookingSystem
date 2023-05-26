using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CusID { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? CustomerPassword { get; set; }
        [Required]
        public string? CustomerEmail { get; set; }
        public ICollection<BookedDetails> BookedDetails { get; set; } = new List<BookedDetails>();


    }
}
