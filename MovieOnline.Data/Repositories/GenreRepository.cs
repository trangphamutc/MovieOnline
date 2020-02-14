using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    public interface IGenreRepository:IRepository<Genre>
    {
        IEnumerable<Genre> GetGendersOfMovie(int movieId);
    }
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<Genre> GetGendersOfMovie(int movieId)
        {
            var query = from g in DbContext.Genres
                        join gm in DbContext.GenreMovies
                        on g.Id equals gm.GenreId
                        where (gm.MovieId == movieId)
                        select g;
            return query;
        }
    }
}
