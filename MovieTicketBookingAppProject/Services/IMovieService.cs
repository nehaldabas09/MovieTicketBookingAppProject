using MovieTicketBookingAppProject.Data;
using MovieTicketBookingAppProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MovieTicketBookingAppProject.Services
{


    // Interface for the movie service
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(int movieId, string Title, string Genre, string Director,int Duration, bool IsActive);
        Task<Movie> DeleteMovieAsync(int id);
    }
}
      /*  // Service class for the movie service
        public class MovieService : IMovieService
        {
            private readonly DataContext _context;

            // Constructor that receives the data context
            public MovieService(DataContext context)
            {
                _context = context;
            }

            // Method to get all movies
            public async Task<IEnumerable<Movie>> GetMoviesAsync()
            {
                // Query the data context for all movies
                return await _context.Movies.ToListAsync();
            }

            // Method to get a movie by id
            public async Task<Movie> GetMovieByIdAsync(int id)
            {
                // Query the data context for a movie by id
                return await _context.Movies.FindAsync(id);
            }

            // Method to add a new movie
            public async Task AddMovieAsync(Movie movie)
            {
                // Add the movie to the data context
                await _context.Movies.AddAsync(movie);
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }

            // Method to update an existing movie
            public async Task<Movie> UpdateMovieAsync(Movie movie)
            {
                // Check if the movie exists in the data context
                var existingMovie = await _context.Movies.FindAsync(movie.Id);
                if (existingMovie == null)
                {
                    // Return null if not found
                    return null;
                }
                // Update the movie properties
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                
                // Save the changes to the database
                await _context.SaveChangesAsync();
                // Return the updated movie
                return existingMovie;
        }

        // Method to delete a movie by id
        public async Task<Movie> DeleteMovieAsync(int id)
        {
            // Check if the movie exists in the data context
            var existingMovie = await _context.Movies.FindAsync(id);
            if (existingMovie == null)
            {
                // Return null if not found
                return null;
            }
            // Remove the movie from the data context
            _context.Movies.Remove(existingMovie);
            // Save the changes to the database
            await _context.SaveChangesAsync();
            // Return the deleted movie
            return existingMovie;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            // Query the data context for all movies
            return await _context.Movies.ToListAsync();
        }
    }
}*/
