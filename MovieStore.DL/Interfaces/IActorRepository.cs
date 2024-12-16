using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces;

public interface IActorRepository
{
    Actor? GetActorById(string actorId);
    List<Actor> GetActorsById(IEnumerable<string> actorIds);
}