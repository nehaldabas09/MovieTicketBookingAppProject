using MovieTicketBookingAppProject.Models;


public interface ITheaterService
{
    Task<List<Theater>> GetAllTheatersAsync();
    Task<Theater> GetTheaterByIdAsync(int theaterId);
}
