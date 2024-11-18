using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.BL.Interfaces;
using MovieStore.Models.DTO;
using MovieStore.Models.Request;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAllMovies();
        }

        [HttpPost("Add")]
        public void Add(AddMovieRequest movieRequest)
        {
            var movieDto = _mapper.Map<Movie>(movieRequest);
            _movieService.AddMovie(movieDto);
        }

        [HttpGet("GetById")]
        public Movie? GetById(int id)
        {
            return _movieService.GetMovieById(id);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _movieService.DeleteMovie(id);
        }

        [HttpPut("Update")]
        public void Update(UpdateMovieRequest movieRequest)
        {
            var movieDto = _mapper.Map<Movie>(movieRequest);
            _movieService.UpdateMovie(movieDto);
        }
    }
}
