
using System;
using MovieTicketBookingAppProject.Entities;




namespace MovieTicketBookingAppProject.Services
{

    public interface IBookingService
    {
        Task<Booking> BookSeatsAsync(int id, int seatsToBook);
    }

}
