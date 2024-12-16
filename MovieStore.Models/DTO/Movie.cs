namespace MovieStore.Models.DTO
{
    public class Movie
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public IEnumerable<string> Actors { get; set; } = new List<string>();
    }
}
