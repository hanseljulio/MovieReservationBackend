using Microsoft.EntityFrameworkCore;
using MovieReservation.Shared.Entities;

namespace MovieReservation.Infrastructure.Context
{
    public class MovieReservationContext: DbContext
    {
        public MovieReservationContext(DbContextOptions<MovieReservationContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Reservations> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Seats> Seats { get; set; }

    }
}
