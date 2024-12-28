using ExampleGraphQL.DAO;
using ExampleGraphQL.Models;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.Data
{
    public class Mutation
    {

        public async Task<Ticket> BuyTicket([Service] CinemaDbContext context, Guid sessionId, int seatNumber, decimal price)
        {
            var ticket = new Ticket
            {
                SessionId = sessionId,
                SeatNumber = seatNumber,
                Price = price,
                IsSold = true
            };
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();
            return ticket;
        }


        public async Task<Movie> AddMovie([Service] CinemaDbContext context, string title, string description, int duration)
        {
            var movie = new Movie
            {
                Title = title,
                Description = description,
                Duration = duration
            };
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
            return movie;
        }


        public async Task<Hall> AddHall([Service] CinemaDbContext context, string name, int capacity)
        {
            var hall = new Hall
            {
                Name = name,
                Capacity = capacity
            };
            context.Halls.Add(hall);
            await context.SaveChangesAsync();
            return hall;
        }


        public async Task<Session> AddSession([Service] CinemaDbContext context, DateTime startTime, Guid movieId, Guid hallId)
        {
            var session = new Session
            {
                StartTime = startTime,
                MovieId = movieId,
                HallId = hallId
            };
            context.Sessions.Add(session);
            await context.SaveChangesAsync();
            return session;
        }

        public async Task<Movie> DeleteMovie([Service] CinemaDbContext context, Guid id)
        {
            var movie = await context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new GraphQLException("Movie not found.");
            }

            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
            return movie;
        }

        public async Task<Hall> DeleteHall([Service] CinemaDbContext context, Guid id)
        {
            var hall = await context.Halls.FindAsync(id);
            if (hall == null)
            {
                throw new GraphQLException("Hall not found.");
            }

            context.Halls.Remove(hall);
            await context.SaveChangesAsync();
            return hall;
        }


        public async Task<Session> DeleteSession([Service] CinemaDbContext context, Guid id)
        {
            var session = await context.Sessions.FindAsync(id);
            if (session == null)
            {
                throw new GraphQLException("Session not found.");
            }

            context.Sessions.Remove(session);
            await context.SaveChangesAsync();
            return session;
        }

        public async Task<Ticket> DeleteTicket([Service] CinemaDbContext context, Guid id)
        {
            var ticket = await context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                throw new GraphQLException("Ticket not found.");
            }

            context.Tickets.Remove(ticket);
            await context.SaveChangesAsync();
            return ticket;
        }

        public IQueryable<Movie> GetAllMovies([Service] CinemaDbContext context)
        {
            return context.Movies;
        }

        public IQueryable<Hall> GetAllHalls([Service] CinemaDbContext context)
        {
            return context.Halls;
        }

        public IQueryable<Session> GetAllSessions([Service] CinemaDbContext context)
        {
            return context.Sessions.Include(s => s.Movie).Include(s => s.Hall);
        }

        public IQueryable<Ticket> GetAllTickets([Service] CinemaDbContext context)
        {
            return context.Tickets.Include(t => t.Session);
        }
    }
}
