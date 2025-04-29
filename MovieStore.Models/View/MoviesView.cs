using MovieStore.Models.DTO;

namespace MovieStore.Models.View;

public class MoviesView
{
    public string MovieId { get; set; }

    public string MovieTitle { get; set; } = string.Empty;

    public int MovieYear { get; set; }

    public List<Actor> Actors { get; set; } = [];
    public DateTime DateInserted { get; set; }
}