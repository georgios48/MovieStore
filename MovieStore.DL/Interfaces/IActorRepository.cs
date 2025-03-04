using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces;

public interface IActorRepository
{
    Task<Actor?> GetActorById(string actorId);
    Task<List<Actor>> GetActorsById(IEnumerable<string> actorIds);
    void AddActorToMovie(string actorId, Movie movie);
}