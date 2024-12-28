using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAllMovies();
        Movie GetMovieById(Guid id);
    }
}
