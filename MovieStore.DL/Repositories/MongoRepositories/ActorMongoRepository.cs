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
        _actorCollection = database.GetCollection<Actor>(mongoDbConfiguration.CurrentValue.DatabaseName);
    }

    public Actor? GetActorById(string actorId)
    {
        return _actorCollection.Find(actor => actor.ID == actorId).FirstOrDefault();
    }

    public List<Actor> GetActorsById(IEnumerable<string> actorIds)
    {
        return _actorCollection.Find(actor => actorIds.Contains(actor.ID)).ToList();
    }
}