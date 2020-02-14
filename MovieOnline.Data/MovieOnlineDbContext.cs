using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Data
{
    public class MovieOnlineDbContext : DbContext 
    {
        public MovieOnlineDbContext() : base("MovieOnlineConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //khai bao table
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Genre> Genres { set; get; }
        public DbSet<GenreMovie> GenreMovies { set; get; }
        public DbSet<Error> Errors { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
