using Microsoft.Extensions.Caching.Memory;
using MovieApp.Aspects;
using MovieApp.Infrastructure.Database;
using MovieApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Services
{
    public class Movie : IMovieRepository
    {
        DatabaseProvider context = new DatabaseProvider();

        [LogAspect]
        public Infrastructure.Movie GetMovie(string imdbId)
        {
            return context.Movies.FirstOrDefault(x => x.ImdbID == imdbId);
        }

        [LogAspect]
        public IEnumerable<Infrastructure.Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        [LogAspect]
        public string PlayContent(string imdbId)
        {
            Infrastructure.Movie movie = context.Movies.FirstOrDefault(x => x.ImdbID == imdbId);
            return movie.Poster;
            //Poster is dummy field. Normally, this method have to return play content
        }
    }
}
