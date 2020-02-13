using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    public interface IMovieRepository
    {
        
    }
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(DbFactory dbFactory) 
            :base(dbFactory)
        {

        }

    }
}
