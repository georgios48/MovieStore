using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;

namespace MovieStore.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public Guid Id { get; set; }

        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            Id = Guid.NewGuid();
        }
        
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public Movie? GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

        public Actor? GetActorById(int id)
        {
            return _actorRepository.GetActorById(id);
        }
    }
}
