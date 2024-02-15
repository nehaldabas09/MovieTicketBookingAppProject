
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieTicketBookingAppProject.Data;
using MovieTicketBookingAppProject.Models;

namespace MovieTicketBookingAppProject.Services
{
    public class TheaterService : ITheaterService
    {
        private readonly DataContext _context;

        public TheaterService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Theater>> GetAllTheatersAsync()
        {
            return await _context.Theater.ToListAsync();
        }

        public async Task<Theater> GetTheaterByIdAsync(int theaterId)
        {
            return await _context.Theater.FirstOrDefaultAsync(t => t.TheaterId == theaterId);
        }
    }
}