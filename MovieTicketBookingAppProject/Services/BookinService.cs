using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieTicketBookingAppProject.Data;
using MovieTicketBookingAppProject.Entities;
using MovieTicketBookingAppProject.Services;

namespace MovieTicketBookingAppProject.Services
{



    public class BookingService : IBookingService
    {
        private readonly DataContext _context;
        public readonly IConfiguration _configuration;

        public BookingService(IConfiguration configuration, DataContext context)

        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<Booking> BookSeatsAsync(int id, int seatsToBook)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                throw new ArgumentException("Movie not found.");
            }

            var schedule = await _context.MovieSchedule.FirstOrDefaultAsync(s => s.MovieId == movie.Id);
            if (schedule == null)
            {
                throw new ArgumentException("Schedule not found for the movie with specified start and end time.");
            }
            /*            var schedule = await _context.MovieSchedule
                   .Include(s => s.Movie)
                   .Include(s => s.Theater)
                   .FirstOrDefaultAsync(s => s.MovieId == movie.Id);*/

            if (schedule == null)
            {
                throw new ArgumentException("Schedule not found for the movie with specified start and end time.");
            }

            var theater = await _context.Theater.FirstOrDefaultAsync(t => t.TheaterId == schedule.TheaterId);
            if (theater == null)
            {
                throw new ArgumentException("Theater not found for the schedule.");
            }

            if (theater.Capacity < seatsToBook)
            {
                throw new ArgumentException("Not enough seats available.");
            }

            theater.Capacity -= seatsToBook;
            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            Console.WriteLine(movie.Title);
            Console.WriteLine(schedule.ScheduleId);
            Console.WriteLine(theater.TheaterId);
            Console.WriteLine(movie.Id);
            Console.WriteLine(schedule.StartTime);
            Console.WriteLine(schedule.EndTime);
            Console.WriteLine(seatsToBook);
            Console.WriteLine(DateTime.Now);

            var booking = new Booking
            {
                MovieTitle = movie.Title,
                ScheduleId  = schedule.ScheduleId,
                TheaterId = theater.TheaterId,
                MovieId = movie.Id,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                SeatsBooked = seatsToBook,
                BookingDateTime = DateTime.Now
            };

            _context.SeatBooking.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
        /*var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Title.ToUpper()==movieTitle.ToUpper());
        if (movie == null)
        {
            throw new ArgumentException("Movie not found.");
        }

        var schedule = await _context.MovieSchedule.FirstOrDefaultAsync(s => s.MovieId == movie.Id);
        if (schedule == null)
        {
            throw new ArgumentException("Schedule not found for the movie.");
        }

        var theater = await _context.Theater.FirstOrDefaultAsync(t => t.TheaterId == schedule.TheaterId);
        if (theater == null)
        {
            throw new ArgumentException("Theater not found for the schedule.");
        }

        if (theater.Capacity < seatsToBook)
        {
            throw new ArgumentException("Not enough seats available.");
        }

        theater.Capacity -= seatsToBook;
        _context.Entry(theater).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        var booking = new Booking
        {
            ScheduleId = schedule.ScheduleId,
            TheaterId = theater.TheaterId,
            MovieId = movie.Id,
            SeatsBooked = seatsToBook,
            BookingDateTime = DateTime.Now
        };

        _context.SeatBooking.Add(booking);
        await _context.SaveChangesAsync();

        return booking;
    }*/
    }
}