using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAppProject.Entities;
using MovieTicketBookingAppProject.Models;
using Newtonsoft.Json;
using MovieTicketBookingAppProject.Services;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Azure;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace MovieTicketBookingAppProject.Controllers

{
    // Controller class for the movies API
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;


        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GETAllMovies
        [HttpGet]
        [Route("GetMovie")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
        public async Task<APIResponse<List<Movie>>> GetMovies()

        {
            APIResponse<List<Movie>> response = new APIResponse<List<Movie>>();


            var movies = await _movieService.GetMoviesAsync();


            if (movies.Any())
            {

                response.data = movies.ToList();
                response.Status = System.Net.HttpStatusCode.OK;

            }
            else
            {
                response.Error = new Error() { errorMessage = "No Movies Found" };
                response.Status = System.Net.HttpStatusCode.InternalServerError;
            }
                return response;
            
        }
        /* {
             
             var movies = await _movieService.GetMoviesAsync();
             
             return Ok(movies);
         }*/

        // GETMovieById
        [HttpGet("{id}")]

        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(404)]
        public async Task<APIResponse<Movie>> GetMovie(int id)
        {
            APIResponse<Movie> response = new APIResponse<Movie>();

            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie != null)
            {

                response.data = movie;
                response.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {


                // JSON
                response.Error = new Error() { errorMessage = "No Movies Found" };
                response.Status = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }

        // POST
        /* [HttpPost]
         [Route("AddMovie")]
         [ProducesResponseType(typeof(Movie), 201)]
         [ProducesResponseType(400)]
         public async Task<APIResponse<Movie>> AddMovie([FromBody] Movie movie)
         {

             APIResponse<Movie> response = new APIResponse<Movie>();

             var addedmovie = await _movieService.AddMovieAsync(movie);

             if (addedmovie != null)
             {

                 response.data = addedmovie;
                 response.Status = System.Net.HttpStatusCode.OK;
             }
             else
             {
                 // JSON
                 response.Error = new Error() { errorMessage = "Failed to add the movie." };
                 response.Status = System.Net.HttpStatusCode.InternalServerError;

             }
             return response;
         }*/
        [HttpPost]
        [Route("AddMovie")]
        [ProducesResponseType(typeof(Movie), 201)]
        [ProducesResponseType(400)]
        public async Task<APIResponse<Movie>> AddMovie([FromBody] Movie movie)
        {
            APIResponse<Movie> response = new APIResponse<Movie>();

            var addedmovie = await _movieService.AddMovieAsync(movie);

            if (addedmovie != null)
            {
                // Set StartTime and EndTime here
                addedmovie.StartTime = DateTime.Now.AddDays(0); // Example: set start time to 7 days from now
                addedmovie.EndTime = DateTime.Now.AddDays(0);   // Example: set end time to 8 days from now

                response.data = addedmovie;
                response.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Error = new Error() { errorMessage = "Failed to add the movie." };
                response.Status = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }


        // PUT
        [HttpPut("Update/")]
        
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<APIResponse<Movie>> UpdateMovieAsync( int movieId, string Title, string Genre, string Director, int Duration, bool IsActive)
        {
            APIResponse<Movie> response = new APIResponse<Movie>();

            if (!ModelState.IsValid)
            {
                response.Error = new Error() { errorMessage = "Model State is not correct" };
                response.Status = System.Net.HttpStatusCode.BadRequest;
                return response;
            }

            // Call the service to update the movie
            var updatedMovie = await _movieService.UpdateMovieAsync(movieId, Title, Genre, Director, Duration, IsActive);

            if (updatedMovie != null)
            {
                response.data = updatedMovie;
                response.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.Error = new Error() { errorMessage = "The database you are trying to update is empty" };
                response.Status = System.Net.HttpStatusCode.NotFound;
            }

            return response;
        }

        // DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        /*public async Task<IActionResult> DeleteMovie(int id)
        {

            var result = await _movieService.DeleteMovieAsync(id);

            if (result == null)
            {

                return NotFound("Movie not found");
            }

            return NoContent();
        }*/
        public async Task<APIResponse<Movie>> DeleteMovie(int id)
        {
            APIResponse<Movie> response = new APIResponse<Movie>();

            var deletedMovie = await _movieService.DeleteMovieAsync(id);

            if (deletedMovie == null)
            {
                response.Error = new Error() { errorMessage = "Movie not found" };
                response.Status = HttpStatusCode.NotFound;
            }
            else
            {
                response.Status = HttpStatusCode.NoContent;
            }

            return response;
        }
    }
}