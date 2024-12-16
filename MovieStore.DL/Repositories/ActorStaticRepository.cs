using MovieStore.DL.Interfaces;
using MovieStore.DL.StaticDB;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories;

public class ActorStaticRepository : IActorRepository
{
    public Actor? GetActorById(string actorId)
    {
        return InMemoryDb.Actor.FirstOrDefault(a => a.ID == actorId);
    }

    public List<Actor> GetActorsById(IEnumerable<string> actorIds)
    {
        return InMemoryDb.Actor.Where(a => actorIds.Contains(a.ID)).ToList();
    }
}