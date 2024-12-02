using MovieStore.Models.DTO;
using MovieStore.Models.View;

namespace MovieStore.Models.Responses;

public class GetDetailedMovieResponse
{
    IEnumerable<MoviesView> Movies { get; set; } = new List<MoviesView>();
}