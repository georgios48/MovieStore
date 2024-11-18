namespace MovieStore.Models.Request;

public class UpdateMovieRequest
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int Year { get; set; }
}