
// ScreeningsServices.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAppProject.Data;
using MovieTicketBookingAppProject.Entities;

namespace MovieTicketBookingAppProject.Services
{
    public class ScreeningsService : IScreeningsService
        
    {
        public readonly DataContext _context;
        public readonly IConfiguration _configuration;


        public ScreeningsService(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

      

       /* public async Task<DateTime?> GetStartTimeByMovieTitleAsync(string movieTitle)
        {
            var startTime = await _context.MovieSchedule
                .Where(schedule => schedule.Movie.Title.ToUpper() == movieTitle.ToUpper())
                .Select(schedule => schedule.StartTime)
                .FirstOrDefaultAsync();

            return startTime; 
        }*/
        public async Task<(DateTime? StartTime, DateTime? EndTime)> GetScheduleTimesByMovieTitleAsync(string movieTitle)
        {
            var scheduleTimes = await _context.MovieSchedule
                .Where(schedule => schedule.Movie.Title.ToUpper() == movieTitle.ToUpper())
                .Select(schedule => new
                {
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime 
                })
                .FirstOrDefaultAsync();

            return (scheduleTimes?.StartTime, scheduleTimes?.EndTime);
        }

    }
}

