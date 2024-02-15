using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAppProject.Entities;
using MovieTicketBookingAppProject.Services;

namespace MovieTicketBookingAppProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book Tickets")]
        public async Task<IActionResult> BookSeats(int id ,int seatsToBook)
        {
            try
            {
                var booking = await _bookingService.BookSeatsAsync(id, seatsToBook);
                return Ok(booking);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while booking seats.");
            }
            /*public async Task<ActionResult<Booking>> BookSeats(string movieTitle, int seatsToBook)
            {
                try
                {
                    var booking = await _bookingService.BookSeatsAsync(movieTitle, seatsToBook);
                    return Ok(booking);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }*/
        }
    }
}