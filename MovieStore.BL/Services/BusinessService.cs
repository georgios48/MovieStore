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

    public void AddActor(string movieId, string actorId)
    {
        var movie = _movieRepository.GetMovieById(movieId);

        if (movie == null)
        {
            throw new Exception($"Movie with id: {movieId} does not exist");
        }
        
        _actorRepository.AddActorToMovie(actorId, movie);
        
        _movieRepository.UpdateMovie(movie);
    }

    public IEnumerable<MoviesView> GetDetailedMovies()
    {
        var result = new List<MoviesView>();
        var allMovies = _movieRepository.GetAllMovies();

        foreach (var movie in allMovies)
        {
            var movieView = new MoviesView()
            {
                MovieId = movie.Id,
                MovieYear = movie.Year,
                MovieTitle = movie.Title,
            };
            // Append actors
            var actors = _actorRepository.GetActorsById(movie.Actors);

            // Set the actors to the movie
            movieView.Actors = actors;
            
            result.Add(movieView);
        }

        return result;
    }
}

