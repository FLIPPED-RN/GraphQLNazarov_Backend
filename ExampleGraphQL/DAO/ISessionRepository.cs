using ExampleGraphQL.Data;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface ISessionRepository
    {
        IQueryable<Session> GetSessionsByDate(DateTime startDate, DateTime endDate);
        IQueryable<Session> GetSessionsByTime(DateTime time);
        IQueryable<Ticket> GetTicketsBySession(Guid sessionId, bool isSold);
        decimal CalculateRevenueForSession(Guid sessionId);
        decimal CalculateLossForSession(Guid sessionId);
        decimal CalculateRevenueForPeriod(DateTime startDate, DateTime endDate);
        decimal CalculateLossForPeriod(DateTime startDate, DateTime endDate);
        decimal CalculateRevenueForMovie(Guid movieId);
        IQueryable<SessionTicketsInfo> GetTicketsInfoForMovie(Guid movieId);
    }
}
