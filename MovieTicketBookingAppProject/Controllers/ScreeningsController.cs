using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAppProject.Services;



namespace MovieTicketBookingAppProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningsController : ControllerBase
    {
        private readonly IScreeningsService _screeningsService;
        
        public ScreeningsController(IScreeningsService screeningsService)
        {
            _screeningsService = screeningsService;
        }

        [HttpGet("{movieTitle}")]
        /* public async Task<IActionResult> GetStartTimeByMovieTitle(string movieTitle)
         {
             var startTime = await _screeningsService.GetStartTimeByMovieTitleAsync(movieTitle);

             if (startTime == null)
             {
                 return NotFound("Movie not found or no schedule available.");
             }

             return Ok(startTime);
         }*/

        /*public async Task<IActionResult> GetStartTimeByMovieTitle(string movieTitle)
        {
            var scheduleTimes = await _screeningsService.GetScheduleTimesByMovieTitleAsync(movieTitle);

            if (scheduleTimes.StartTime == null)
            {
                return NotFound("Movie not found or no schedule available.");
            }

            return Ok(scheduleTimes);
        }*/
        public async Task<IActionResult> GetStartTimeByMovieTitle(string movieTitle)
        {
            var (startTime, endTime) = await _screeningsService.GetScheduleTimesByMovieTitleAsync(movieTitle);

            if (startTime == null)
            {
                return NotFound("Movie not found or no schedule available.");
            }

            return Ok(new { StartTime = startTime, EndTime = endTime });
        }
    }
}
