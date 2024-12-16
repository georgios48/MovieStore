using MovieStore.Models.DTO;
using MovieStore.Models.View;

namespace MovieStore.BL.Interfaces;

public interface IBusinessService
{
    IEnumerable<MoviesView> GetDetailedMovies();
    void AddActor(string movieId, string actorId);
}