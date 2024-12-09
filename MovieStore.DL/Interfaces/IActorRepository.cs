using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces;

public interface IActorRepository
{
    Actor? GetActorById(int actorId);
    List<Actor> GetActorsById(IEnumerable<int> actorIds);
}