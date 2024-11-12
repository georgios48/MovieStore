﻿using MovieStore.Models.DTO;

namespace MovieStore.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);

        Movie? GetMovieById(int id);
        void DeleteMovie(int id);
        //void UpdateMovie(Movie movie);
    }
}
