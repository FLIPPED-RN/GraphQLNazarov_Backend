using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using ExampleGraphQL;

namespace ExampleGraphQL
{
    public class CinemaDbContext:DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
