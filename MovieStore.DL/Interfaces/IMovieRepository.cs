using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task AddMovie(Movie movie);

        Task<Movie?> GetMovieById(string id);
        Task DeleteMovie(string id);
        Task UpdateMovie(Movie movie);
    }
}
