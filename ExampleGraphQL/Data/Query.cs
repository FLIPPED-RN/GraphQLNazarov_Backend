using ExampleGraphQL.DAO;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.Data
{
    public class Query
    {
        // Выдать репертуар на заданный период времени
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Session> GetRepertoireByDate(
            [Service] ISessionRepository sessionRepository,
            DateTime startDate,
            DateTime endDate) =>
            sessionRepository.GetSessionsByDate(startDate, endDate);

        //получение фильмов all
        public IQueryable<Movie> GetAllMovies([Service] CinemaDbContext context)
        {
            return context.Movies;
        }

        public IQueryable<Ticket> GetAllTickets([Service] CinemaDbContext context)
        {
            return context.Tickets;
        }

        public IQueryable<Hall> GetAllHalls([Service] CinemaDbContext context)
        {
            return context.Halls;
        }

        // Сформировать список свободных мест на заданный киносеанс
        public IQueryable<Ticket> GetAvailableTickets(
            [Service] ISessionRepository sessionRepository,
            Guid sessionId) =>
            sessionRepository.GetTicketsBySession(sessionId, isSold: false);

        // Сформировать список занятых мест на заданный киносеанс
        public IQueryable<Ticket> GetSoldTickets(
            [Service] ISessionRepository sessionRepository,
            Guid sessionId) =>
            sessionRepository.GetTicketsBySession(sessionId, isSold: true);

        // Выдать список кинофильмов на заданное (в течение суток) время
        public IQueryable<Movie> GetMoviesByTime(
            [Service] ISessionRepository sessionRepository,
            DateTime time) =>
            sessionRepository.GetSessionsByTime(time)
                .Select(s => s.Movie)
                .Distinct();

        // Рассчитать стоимость проданных билетов на заданный киносеанс
        public decimal CalculateRevenueForSession(
            [Service] ISessionRepository sessionRepository,
            Guid sessionId) =>
            sessionRepository.CalculateRevenueForSession(sessionId);

        // Рассчитать стоимость непроданных билетов на заданный киносеанс
        public decimal CalculateLossForSession(
            [Service] ISessionRepository sessionRepository,
            Guid sessionId) =>
            sessionRepository.CalculateLossForSession(sessionId);

        // Рассчитать стоимость проданных билетов на заданный период времени
        public decimal CalculateRevenueForPeriod(
            [Service] ISessionRepository sessionRepository,
            DateTime startDate,
            DateTime endDate) =>
            sessionRepository.CalculateRevenueForPeriod(startDate, endDate);

        // Рассчитать потери кинотеатра на заданный период времени
        public decimal CalculateLossForPeriod(
            [Service] ISessionRepository sessionRepository,
            DateTime startDate,
            DateTime endDate) =>
            sessionRepository.CalculateLossForPeriod(startDate, endDate);

        // Для фильма из репертуара рассчитать стоимость проданных билетов
        public decimal CalculateRevenueForMovie(
            [Service] ISessionRepository sessionRepository,
            Guid movieId) =>
            sessionRepository.CalculateRevenueForMovie(movieId);

        // Для фильма из репертуара рассчитать количество проданных и непроданных билетов для каждого сеанса
        public IQueryable<SessionTicketsInfo> GetTicketsInfoForMovie(
            [Service] ISessionRepository sessionRepository,
            Guid movieId) =>
            sessionRepository.GetTicketsInfoForMovie(movieId);
    }

    public class SessionTicketsInfo
    {
        public Guid SessionId { get; set; }
        public int SoldTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }
    }
}
