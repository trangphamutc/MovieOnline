using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    
    public interface IMovieRepository: IRepository<Movie>
    {
        IEnumerable<Movie> GetAllByGenre(int gener, int pageIndex, int pageSize, out int totalRow);
    }
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(DbFactory dbFactory) 
            :base(dbFactory)
        {

        }

        public IEnumerable<Movie> GetAllByGenre(int gener, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from m in DbContext.Movies
                        join g in DbContext.GenreMovies
                        on m.Id equals g.MovieId
                        where g.GenreId == gener
                        orderby m.NameVietNamese
                        select m;

            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }

       
    }
}
