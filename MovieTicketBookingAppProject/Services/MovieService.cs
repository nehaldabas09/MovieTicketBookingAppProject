using MovieTicketBookingAppProject.Data;
using MovieTicketBookingAppProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;


namespace MovieTicketBookingAppProject.Services.MovieService
{

   
    public class MovieService : IMovieService
    {
        public readonly DataContext _context;
        public readonly IConfiguration _configuration;
        

              public MovieService(IConfiguration configuration,DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        private int GetNextScheduleId()
        {
            int highestId = 0;

            if (_context.MovieSchedule.Any())
            {
                highestId = _context.MovieSchedule.Max(ms => ms.ScheduleId);
            }

            return highestId + 1;
        }


        // Method to get all movies
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
            {
               
                return await _context.Movies.ToListAsync();
            }

           
            public async Task<Movie> GetMovieByIdAsync(int id)
            {
                
                return await _context.Movies.FindAsync(id);
            }

        // Method to add a new movie
        /* public async Task<Movie>  AddMovieAsync(Movie movie)
         {
             // Add the movie to the data context
             await _context.Movies.AddAsync(movie);
             // Save the changes to the database
             await _context.SaveChangesAsync();
         return movie;
         }*/
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            // Add the movie to the Movies table
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // Retrieve the newly added movie's ID
            int movieId = movie.Id;

            // Create an entry in the MovieSchedule table
            var movieSchedule = new Models.Screenings
            {
                MovieId = movieId,
                // Set other necessary details (e.g., start time, end time, theater ID)
                StartTime = DateTime.Now.AddDays(0), // Example: set start time to 7 days from now
                EndTime = DateTime.Now.AddDays(0),   // Example: set end time to 8 days from now
                TheaterId = 1 
            };
            movieSchedule.ScheduleId = GetNextScheduleId();
            _context.MovieSchedule.Add(movieSchedule);
            await _context.SaveChangesAsync();

            return movie;
        }

        // Method to update an existing movie
        public async Task<Movie> UpdateMovieAsync(int movieId, string Title, string Genre, string Director, int Duration, bool IsActive)
            {
               
                var existingMovie = await _context.Movies.FindAsync(movieId);

                if (existingMovie == null)
                {
                  
                    return null;
                }
                // Update the movie properties
                existingMovie.Title = Title;
                existingMovie.Genre = Genre;
            existingMovie.Director = Director;
            existingMovie.Duration = Duration;
            existingMovie.IsActive = IsActive;

            _context.Update(existingMovie);

                
                await _context.SaveChangesAsync();
                
                return existingMovie;
            }

            // Method to delete 
            public async Task<Movie> DeleteMovieAsync(int id)
            {
                
                var existingMovie = await _context.Movies.FindAsync(id);
                if (existingMovie == null)
                {
                    
                    return null;
                }
                
                _context.Movies.Remove(existingMovie);
                
                await _context.SaveChangesAsync();
                
                return existingMovie;
            }
          
    }
    }

