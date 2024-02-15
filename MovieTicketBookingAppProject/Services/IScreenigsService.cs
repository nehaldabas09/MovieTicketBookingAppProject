
using System;
using System.Threading.Tasks;

namespace MovieTicketBookingAppProject.Services
{
    public interface IScreeningsService
    {
        Task<(DateTime? StartTime, DateTime? EndTime)> GetScheduleTimesByMovieTitleAsync(string movieTitle);
    }
}
