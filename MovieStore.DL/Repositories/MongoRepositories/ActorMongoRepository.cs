using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieStore.DL.Interfaces;
using MovieStore.Models.Configurations;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories.MongoRepositories;

public class ActorMongoRepository : IActorRepository
{
    private readonly IMongoCollection<Actor> _actorCollection;

    public ActorMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.CurrentValue.ConnectionString);
        var database = client.GetDatabase(mongoDbConfiguration.CurrentValue.DatabaseName);
        _actorCollection = database.GetCollection<Actor>($"{nameof(Actor)}s");
    }

    public Actor? GetActorById(string actorId)
    {
        return _actorCollection.Find(actor => actor.Id == actorId).FirstOrDefault();
    }

    public List<Actor> GetActorsById(IEnumerable<string> actorIds)
    {
        var result =  _actorCollection.Find(actor => actorIds.Contains(actor.Id)).ToList();
        return result;
    }

    public void AddActorToMovie(string actorId, Movie movie)
    {
        var actor = GetActorById(actorId);

        if (actor != null)
        {
            movie.Actors.Add(actor.Id);
        }
        
    }
}