using System.ComponentModel.DataAnnotations;
using MovieTicketBookingAppProject.Entities;

namespace MovieTicketBookingAppProject.Models
{
    public class Screenings
    {
        
        [Key] public int ScheduleId { get; set; } 
        public int MovieId { get; set; } 
        public int TheaterId { get; set; } 
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public Movie Movie { get; set; }

        public virtual Theater Theater { get; set; }

    }
}
