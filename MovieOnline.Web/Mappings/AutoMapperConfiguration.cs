using AutoMapper;
using MovieOnline.Model.Models;
using MovieOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieOnline.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static  void Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieViewModel>();
                cfg.CreateMap<Genre, GenreViewModel>();
                cfg.CreateMap<GenreMovie, GenreMovieViewModel>();
            });
            configuration.CompileMappings();

        }
    }
}