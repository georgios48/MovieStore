using MovieStore.DL.Interfaces;
using MovieStore.DL.StaticDB;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories;

public class ActorStaticRepository : IActorRepository
{
    public Actor? GetActorById(int actorId)
    {
        return InMemoryDb.Actor.FirstOrDefault(a => a.ID == actorId);
    }

    public List<Actor> GetActorsById(IEnumerable<int> actorIds)
    {
        return InMemoryDb.Actor.Where(a => actorIds.Contains(a.ID)).ToList();
    }
}