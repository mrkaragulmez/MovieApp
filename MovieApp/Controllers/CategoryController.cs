using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Repositories;

namespace MovieApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        public CategoryController(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }

        [ResponseCache(Duration = 36000)]
        [Route("List")]
        [HttpGet]
        public IActionResult List()
        {
            return Ok(movieRepository.GetMovies());
        }

        [ResponseCache(Duration = 36000)]
        [Route("Detail/{imdbId}")]
        [HttpGet]
        public IActionResult Detail(string imdbId)
        {
            return Ok(movieRepository.GetMovie(imdbId));
        }
    }
}
