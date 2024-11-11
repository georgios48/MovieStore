using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;

namespace MovieStore.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public Guid Id { get; set; }

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            Id = Guid.NewGuid();
        }
        
        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }
    }
}
