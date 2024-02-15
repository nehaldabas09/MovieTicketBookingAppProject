using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAppProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TheaterController : ControllerBase
{
    private readonly ITheaterService _theaterService;

    public TheaterController(ITheaterService theaterService)
    {
        _theaterService = theaterService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Theater>>> GetAllTheaters()
    {
        try
        {
            var theaters = await _theaterService.GetAllTheatersAsync();
            return Ok(theaters);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

   /* [HttpGet("{theaterId}")]
    public async Task<ActionResult<Theater>> GetTheaterById(int theaterId)
    {
        try
        {
            var theater = await _theaterService.GetTheaterByIdAsync(theaterId);
            if (theater == null)
            {
                return NotFound("Theater not found.");
            }
            return Ok(theater);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }*/
}
