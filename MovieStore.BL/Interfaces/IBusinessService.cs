using MovieStore.Models.View;

namespace MovieStore.BL.Interfaces;

public interface IBusinessService
{
    IEnumerable<MoviesView> GetDetailedMovies();
}