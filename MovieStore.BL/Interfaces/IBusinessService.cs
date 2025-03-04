using MovieStore.Models.DTO;
using MovieStore.Models.View;

namespace MovieStore.BL.Interfaces;

public interface IBusinessService
{
    Task<IEnumerable<MoviesView>> GetDetailedMovies();
    Task AddActor(string movieId, string actorId);
}