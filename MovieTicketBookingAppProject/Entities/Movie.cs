using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MovieTicketBookingAppProject.Entities
{
    // class of movie
    public class Movie
    {

            public int Id { get; set; } 
            public string Title { get; set; } 
            public string Genre { get; set; } 
            public string Director { get; set; } 
            public int Duration { get; set; } 
            public bool IsActive { get; set; }

        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }


    }

    public class APIResponse<T> where T : class
    {
        public T data { get; set; }
        public Error Error { get; set; }
        public HttpStatusCode Status { get; set; }
    }

    public class Error
    {
        public string errorMessage { get; set; }
    }
}
