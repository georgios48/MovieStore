using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Configurations;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories.MongoRepositories;

public class MovieMongoRepository : IMovieRepository
{
    private readonly IMongoCollection<Movie> _moviesCollection;

    public MovieMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.CurrentValue.ConnectionString);
        var database = client.GetDatabase(mongoDbConfiguration.CurrentValue.DatabaseName);
        _moviesCollection = database.GetCollection<Movie>($"{nameof(Movie)}s");
    }
    public List<Movie> GetAllMovies()
    {
        return _moviesCollection.Find(movie => true).ToList();
    }

    public void AddMovie(Movie movie)
    {
        movie.Id = Guid.NewGuid().ToString();
        _moviesCollection.InsertOne(movie);
    }

    public Movie? GetMovieById(string id)
    {
        return _moviesCollection.Find(movie => movie.Id == id).FirstOrDefault();
    }

    public void DeleteMovie(string id)
    {
        _moviesCollection.DeleteOne(movie => movie.Id == id);
    }
    
    public void UpdateMovie(Movie movie)
    {
        _moviesCollection.ReplaceOne(movieToEdit => true, movie);
    }
}