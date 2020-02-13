using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Movie> GetMoviesWithGenre(int genreID);
    }
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
        public IEnumerable<Movie> GetMoviesWithGenre(int genreID)
        {
            List<GenreMovie> genreMovie = this.DbContext.GenreMovies.Where(x => x.GenreId == genreID).ToList();
            List<Movie> listMovie = new List<Movie>();
            foreach(var movie in genreMovie)
            {
                listMovie = this.DbContext.Movies.Where(t => t.Id == movie.MovieId).ToList();
            }
            return listMovie;
        }
    }
}
