using ExampleGraphQL.Models;
using Faker;
using ExampleGraphQL;

namespace ExampleGraphQL.Data
{
    public static class DataSeeder
    {
        public static void SeedData(CinemaDbContext db)
        {
            if (!db.Movies.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var movie = new Movie
                    {
                        Title = Lorem.Sentence(),
                        Description = Lorem.Paragraphs(3).FirstOrDefault(),
                        Duration = 90 + i * 10,
                        Sessions = new List<Session>()
                    };
                    db.Movies.Add(movie);

                    var hall = new Hall
                    {
                        Name = $"Hall {i}",
                        Capacity = 100 + i * 10
                    };
                    db.Halls.Add(hall);

                    var session = new Session
                    {
                        StartTime = DateTime.UtcNow.AddHours(i),
                        EndTime = DateTime.UtcNow.AddHours(i).AddMinutes(movie.Duration),
                        Movie = movie,
                        Hall = hall
                    };

                    for (int j = 1; j <= 10; j++)
                    {
                        var ticket = new Ticket
                        {
                            SeatNumber = j,
                            IsSold = j % 2 == 0, 
                            Price = 500,
                            Session = session
                        };
                        db.Tickets.Add(ticket);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
