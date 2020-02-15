using MovieOnline.Model.Models;
using MovieOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieOnline.Web.Insfrastructure.Extension
{
    public static class EntityExtensions
    {
        public static void UpdateMovie(this Movie movie, MovieViewModel movieViewModel)
        {
            movie.Id = movieViewModel.Id;
            movie.NameVietNamese = movieViewModel.NameVietNamese;
            movie.NameOriginal = movieViewModel.NameOriginal;
            movie.Description = movieViewModel.Description;
            movie.CreatedDate = movieViewModel.CreatedDate;

        }

        public static void UpdateGenre(this Genre genre, GenreViewModel genreView)
        {
            genre.Id = genreView.Id;
            genre.Name = genreView.Name;
            genre.Status = genreView.Status;
        }

        public static void UpdateGenreMovie(this GenreMovie genreMovie, GenreMovieViewModel genreMovieView)
        {
            genreMovie.MovieId = genreMovieView.MovieId;
            genreMovie.GenreId = genreMovieView.GenreId;
        }
    }
}