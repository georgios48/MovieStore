using MovieStore.DL.Interfaces;
using MovieStore.DL.StaticDB;
using MovieStore.Models.DTO;

namespace MovieStore.DL.Repositories;

public class ActorRepository : IActorRepository
{
    public Actor? GetActorById(int actorId)
    {
        return InMemoryDb.Actor.FirstOrDefault(a => a.ID == actorId);
    }
}