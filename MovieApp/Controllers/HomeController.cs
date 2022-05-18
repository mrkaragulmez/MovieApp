using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Repositories;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        
        public HomeController(IMovieRepository _movieRepository)
        {
            movieRepository = _movieRepository;
        }

        [ResponseCache(Duration = 36000)]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(movieRepository.GetMovies());
        }
    }
}
