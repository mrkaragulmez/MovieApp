using MovieApp.Aspects;
using MovieApp.Infrastructure;
using System.Collections.Generic;

namespace MovieApp.Repositories
{
    public interface IMovieRepository  
    {
        public IEnumerable<Movie> GetMovies();
        public Movie GetMovie(string imdbId);
        public string PlayContent(string imdbId);
    }
}
