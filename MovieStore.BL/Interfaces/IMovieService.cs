using MovieStore.Models.DTO;

namespace MovieStore.BL.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();

        void AddMovie(Movie movie);
        Movie? GetMovieById(string id);
        void DeleteMovie(string id);
        void UpdateMovie(Movie movie);
        Actor? GetActorById(string id);
    }
}
