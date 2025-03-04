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
        
        public async Task<List<Movie>> GetAllMovies()
        {
            var result = await _movieRepository.GetAllMovies();
            return result;
        }

        public async Task AddMovie(Movie movie)
        {
            await _movieRepository.AddMovie(movie);
        }

        public async Task<Movie?> GetMovieById(string id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        public async Task DeleteMovie(string id)
        {
            await _movieRepository.DeleteMovie(id);
        }

        public async Task UpdateMovie(Movie movie)
        {
            await _movieRepository.UpdateMovie(movie);
        }

        public async Task<Actor?> GetActorById(string id)
        {
            var result =  await _actorRepository.GetActorById(id.ToString());
            return result;
        }
    }
}
