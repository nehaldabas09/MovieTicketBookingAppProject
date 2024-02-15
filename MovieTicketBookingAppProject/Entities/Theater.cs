namespace MovieTicketBookingAppProject.Models
{
    // A class to represent a theater
public class Theater
{
    public int TheaterId { get; set; } 
    public string TheaterName { get; set; } 
    public int Capacity { get; set; } 
    public string Location { get; set; } 
   /* public List<Schedule> Schedules { get; set; } // A list of schedules for the movies in the theater*/
}
}
