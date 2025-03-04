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

    public async Task AddActor(string movieId, string actorId)
    {
        var movie = await _movieRepository.GetMovieById(movieId);

        if (movie == null)
        {
            throw new Exception($"Movie with id: {movieId} does not exist");
        }
        
        _actorRepository.AddActorToMovie(actorId, movie);
        
        await _movieRepository.UpdateMovie(movie);
    }

    public async Task<IEnumerable<MoviesView>> GetDetailedMovies()
    {
        var allMovies = await _movieRepository.GetAllMovies();

        // Create tasks to process movies in parallel
        var movieTasks = allMovies.Select(async movie =>
        {
            var movieView = new MoviesView()
            {
                MovieId = movie.Id,
                MovieYear = movie.Year,
                MovieTitle = movie.Title,
            };

            // Fetch actors asynchronously
            var actorsTask = movie.Actors.Select(actorId => _actorRepository.GetActorById(actorId));

            // Assign actors to the movie
            var actors = await Task.WhenAll(actorsTask);
            movieView.Actors = actors.ToList();
        
            return movieView;
        }).ToList();

        // Wait for all tasks to complete and return the results
        return await Task.WhenAll(movieTasks);
    }
}

