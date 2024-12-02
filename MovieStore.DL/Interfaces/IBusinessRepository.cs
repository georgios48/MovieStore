using MovieStore.Models.DTO;
using MovieStore.Models.Responses;

namespace MovieStore.DL.Interfaces;

public interface IBusinessRepository
{
    GetDetailedMovieResponse GetDetailedMovie();
}