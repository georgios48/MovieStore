﻿// using MovieStore.DL.Interfaces;
// using MovieStore.DL.StaticDB;
// using MovieStore.Models.DTO;
//
// namespace MovieStore.DL.Repositories
// {
//     internal class MovieRepository : IMovieRepository
//     {
//         public List<Movie> GetAllMovies()
//         {
//             return InMemoryDb.Movies;
//         }
//
//         public void AddMovie(Movie movie)
//         {
//             InMemoryDb.Movies.Add(movie);
//         }
//
//         public Movie? GetMovieById(string id)
//         {
//             return InMemoryDb.Movies.FirstOrDefault(m => m.Id == id);
//         }
//
//         public void DeleteMovie(int id)
//         {
//             throw new NotImplementedException();
//         }
//
//         public void DeleteMovie(string id)
//         {
//             var movie = InMemoryDb.Movies.FirstOrDefault(m => m.Id == id);
//
//             if (movie != null)
//             {
//                 InMemoryDb.Movies.Remove(movie);
//             }
//         }
//
//         public void UpdateMovie(Movie movie)
//         {
//             var movieToUpdate = InMemoryDb.Movies.FirstOrDefault(m => m.Id == movie.Id);
//             movieToUpdate!.Title = movie.Title;
//             movieToUpdate!.Year = movie.Year;
//         }
//     }
// }
