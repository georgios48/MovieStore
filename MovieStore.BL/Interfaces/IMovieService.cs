using MovieStore.Models.DTO;

namespace MovieStore.BL.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();

        void AddMovie(Movie movie);
        Movie? GetMovieById(int id);
        void DeleteMovie(int id);
        void UpdateMovie(Movie movie);
        Actor? GetActorById(int id);
    }
}
