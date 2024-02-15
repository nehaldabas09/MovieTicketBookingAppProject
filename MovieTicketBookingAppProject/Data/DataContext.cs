using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAppProject.Entities;
using MovieTicketBookingAppProject.Models;

namespace MovieTicketBookingAppProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        {
            

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screenings> MovieSchedule {  get; set; }

        public DbSet<Theater> Theater { get; set; }
        public DbSet<Booking> SeatBooking { get; set; }


    }
    

}
