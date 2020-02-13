using MovieOnline.Data.Infrastructure;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data.Repositories
{
    public class GenreMovieRepository: RepositoryBase<GenreMovie>
    {
        public GenreMovieRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
