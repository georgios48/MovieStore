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
    public async Task<List<Movie>> GetAllMovies()
    {
        var result = await _moviesCollection.FindAsync(movie => true);
        return result.ToList();
    }

    public async Task AddMovie(Movie movie)
    {
        movie.Id = Guid.NewGuid().ToString();
        await _moviesCollection.InsertOneAsync(movie);
    }

    public async Task<Movie?> GetMovieById(string id)
    {
        var result = await _moviesCollection.FindAsync(movie => movie.Id == id);
        return result.FirstOrDefault();
    }

    public async Task DeleteMovie(string id)
    {
        await _moviesCollection.DeleteOneAsync(movie => movie.Id == id);
    }
    
    public async Task UpdateMovie(Movie movie)
    {
        await _moviesCollection.ReplaceOneAsync(movieToEdit => true, movie);
    }
}