using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    public interface IGenreMovieRepository : IRepository<GenreMovie>
    {
        void Add(int movieId, int genreId);
    }
    public class GenreMovieRepository :RepositoryBase<GenreMovie>, IGenreMovieRepository
    {

        public GenreMovieRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public void Add(int movieId, int genreId)
        {
            GenreMovie gm = new GenreMovie();
            gm.GenreId = genreId;
            gm.MovieId = movieId;
            
            DbContext.GenreMovies.Add(gm);
        }
    }
}
