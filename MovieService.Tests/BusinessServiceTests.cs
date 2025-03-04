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
        
        new Actor
        {
            Name = "Actor 14", Id = "3dd6277f-bde8-4d77-8958-91600ccb89e"
        },
    };

    [Fact]
    public async Task GetDetailedMovies_Ok()
    {
        // Setup
        List<string> actorsIds = [_actors[0].Id];
        
        _mockMovieRepository
            .Setup(x => x.GetAllMovies())
            .ReturnsAsync(_movies);

        _mockActorRepository
            .Setup(x => x.GetActorById(actorsIds[0]))
            .ReturnsAsync(_actors.FirstOrDefault(a => a.Id == _actors[0].Id));
        
        // Inject
        var businessService = new BusinessService(_mockActorRepository.Object, _mockMovieRepository.Object);
        
        // Act
        var result = await businessService.GetDetailedMovies();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(_movies.Count, result.Count());
    }

    [Fact]
    public async Task AddActor_Ok()
    {
        // Setup
        List<string> actorsIds = [_actors[1].Id];
        
        _mockMovieRepository
            .Setup(x => x.GetMovieById(_movies[0].Id))
            .ReturnsAsync(_movies[0]);

        _mockActorRepository
            .Setup(x => x.GetActorById(actorsIds[0]));
            
        
        // Inject
        var businessService = new BusinessService(_mockActorRepository.Object, _mockMovieRepository.Object);
        
        // Act
        await businessService.AddActor(_movies[0].Id, actorsIds[0]);
        
        // Assert
        Assert.Equal(2, _movies[0].Actors.Count);
    }
    
    [Fact]
    public async Task AddActor_MovieDoesNotExist_ThrowsException()
    {
        // Setup
        List<string> actorsIds = [_actors[1].Id];
        
        // Arrange
        _mockMovieRepository
            .Setup(x => x.GetMovieById(_movies[0].Id))
            .ReturnsAsync((Movie)null!);
        
        // Inject
        var businessService = new BusinessService(_mockActorRepository.Object, _mockMovieRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => businessService.AddActor(_movies[0].Id, actorsIds[0]));
        
        Assert.Equal($"Movie with id: {_movies[0].Id} does not exist", exception.Message);
        
    }
}