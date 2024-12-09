using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);

        Movie? GetMovieById(string id);
        void DeleteMovie(string id);
        void UpdateMovie(Movie movie);
    }
}
