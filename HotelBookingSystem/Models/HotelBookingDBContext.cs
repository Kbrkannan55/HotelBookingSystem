using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models
{
    public class HotelBookingDBContext : DbContext
    {
        public HotelBookingDBContext(DbContextOptions<HotelBookingDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<HotelDetails> HotelDetails { get; set; }
        public virtual DbSet<RoomDetails> RoomDetails { get; set; }
        public virtual DbSet<BookedDetails> BookedDetails { get; set; }


   
    }
}
