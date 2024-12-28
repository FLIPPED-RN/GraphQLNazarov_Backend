using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;
        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Movie> GetAllMovies()
        {
            return db.Movies.AsQueryable();
        }
        public Movie GetMovieById(Guid id)
        {
            return db.Movies.FirstOrDefault(m => m.Id == id);
        }
    }
}
