using Moq;
using MovieStore.BL.Services;
using MovieStore.DL.Interfaces;
using MovieStore.Models.DTO;

namespace MovieService.Tests;

public class BusinessServiceTests
{
    private Mock<IMovieRepository> _mockMovieRepository;
    private Mock<IActorRepository> _mockActorRepository;

    public BusinessServiceTests()
    {
        _mockActorRepository = new Mock<IActorRepository>();
        _mockMovieRepository = new Mock<IMovieRepository>();
    }

    private List<Movie> _movies = new List<Movie>
    {
        new Movie
        {
            Id = Guid.NewGuid().ToString(), Title = "The Shawshank Redemption", Actors = ["Actor 1", "Actor 2"]
        },
    };

    private List<Actor> _actors = new List<Actor>
    {
        new Actor
        {
            Name = "Actor 1", Id = "3dd6277f-bde8-4d77-8958-91600ccb579e"
        },
    };

    [Fact]
    public void GetDetailedMovies_Ok()
    {
        // Setup
        List<string> actorsIds = [_actors[0].Id];
        
        _mockMovieRepository
            .Setup(x => x.GetAllMovies())
            .Returns(_movies);

        _mockActorRepository
            .Setup(x => x.GetActorsById(actorsIds));
        
        // Inject
        var businessService = new BusinessService(_mockActorRepository.Object, _mockMovieRepository.Object);
        
        // Act
        var result = businessService.GetDetailedMovies();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(_movies.Count, result.Count());
    }
}