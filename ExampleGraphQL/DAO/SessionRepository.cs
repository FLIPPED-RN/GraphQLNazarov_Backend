using ExampleGraphQL.Data;
using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.DAO
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CinemaDbContext _db;

        public SessionRepository(CinemaDbContext db)
        {
            _db = db;
        }

        public IQueryable<Session> GetSessionsByDate(DateTime startDate, DateTime endDate)
        {
            return _db.Sessions
                .Where(s => s.StartTime >= startDate && s.StartTime <= endDate)
                .Include(s => s.Movie)
                .Include(s => s.Hall);
        }

        public IQueryable<Session> GetSessionsByTime(DateTime time)
        {
            return _db.Sessions
                .Where(s => s.StartTime.TimeOfDay == time.TimeOfDay)
                .Include(s => s.Movie)
                .Include(s => s.Hall);
        }

        public IQueryable<Ticket> GetTicketsBySession(Guid sessionId, bool isSold)
        {
            return _db.Tickets
                .Where(t => t.SessionId == sessionId && t.IsSold == isSold);
        }

        public decimal CalculateRevenueForSession(Guid sessionId)
        {
            return _db.Tickets
                .Where(t => t.SessionId == sessionId && t.IsSold)
                .Sum(t => t.Price);
        }

        public decimal CalculateLossForSession(Guid sessionId)
        {
            return _db.Tickets
                .Where(t => t.SessionId == sessionId && !t.IsSold)
                .Sum(t => t.Price);
        }

        public decimal CalculateRevenueForPeriod(DateTime startDate, DateTime endDate)
        {
            return _db.Tickets
                .Where(t => t.Session.StartTime >= startDate && t.Session.StartTime <= endDate && t.IsSold)
                .Sum(t => t.Price);
        }

        public decimal CalculateLossForPeriod(DateTime startDate, DateTime endDate)
        {
            return _db.Tickets
                .Where(t => t.Session.StartTime >= startDate && t.Session.StartTime <= endDate && !t.IsSold)
                .Sum(t => t.Price);
        }

        public decimal CalculateRevenueForMovie(Guid movieId)
        {
            return _db.Tickets
                .Where(t => t.Session.MovieId == movieId && t.IsSold)
                .Sum(t => t.Price);
        }

        public IQueryable<SessionTicketsInfo> GetTicketsInfoForMovie(Guid movieId)
        {
            return _db.Sessions
                .Where(s => s.MovieId == movieId)
                .Select(s => new SessionTicketsInfo
                {
                    SessionId = s.Id,
                    SoldTicketsCount = s.Tickets.Count(t => t.IsSold),
                    AvailableTicketsCount = s.Tickets.Count(t => !t.IsSold)
                });
        }
    }
}
