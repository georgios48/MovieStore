using MovieStore.BL.Interfaces;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Responses;
using MovieStore.Models.View;

namespace MovieStore.BL.Services;

public class BusinessService : IBusinessService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IActorRepository _actorRepository;

    public BusinessService(IActorRepository actorRepository, IMovieRepository movieRepository)
    {
        _actorRepository = actorRepository;
        _movieRepository = movieRepository;
    }

    public IEnumerable<MoviesView> GetDetailedMovies()
    {
        var result = new List<MoviesView>();
        var allMovies = _movieRepository.GetAllMovies();

        foreach (var movie in allMovies)
        {
            var movieActors = new List<Actor>(movie.Actors.Count());
            var movieView = new MoviesView()
            {
                MovieId = movie.Id,
                MovieYear = movie.Year,
                MovieTitle = movie.Title,
            };
            // Append actors
            foreach (var actorId in movie.Actors)
            {
                var actorDto = _actorRepository.GetActorById(actorId);
                movieActors.Add(actorDto);
            }
            
            // append the actors to the movie
            movieView.Actors = movieActors;
            
            result.Add(movieView);
        }

        return result;
    }
}
