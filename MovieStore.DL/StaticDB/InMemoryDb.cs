using MovieStore.Models.DTO;

namespace MovieStore.DL.StaticDB
{
    internal static class InMemoryDb
    {
        public static List<Actor> Actor = new List<Actor>
        {
            new Actor
            {
                ID = 1,
                Name = "John Doe"
            },
            new Actor
            {
                ID = 2,
                Name = "Some Name"
            }
        };
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Year = 1994,
                Actors = new List<int>
                {
                    1, 2
                }
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Year = 1972,
                Actors = new List<int>
                {
                    3, 4
                }
            },
            new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                Year = 2008,
                Actors = new List<int>
                {
                    5, 6
                }
            },
        };
    }
}