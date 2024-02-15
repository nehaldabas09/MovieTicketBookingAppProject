using MovieTicketBookingAppProject.Models;

namespace MovieTicketBookingAppProject.Entities
{
    public class Booking
    {
       
        public int BookingId { get; set; }
        public int ScheduleId { get; set; }
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public int SeatsBooked { get; set; }
        public DateTime BookingDateTime { get; set; }

  

        public string MovieTitle { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
    }
}