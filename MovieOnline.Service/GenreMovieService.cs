using MovieOnline.Data.Infrastructure;
using MovieOnline.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Service
{
    public interface IGenreMovieService
    {
        void Add(int movieId, int genreId);
        void SaveChanges();
    }
    public class GenreMovieService : IGenreMovieService
    {
        IGenreMovieRepository _genreMovieRepository;
        IUnitOfWork _unitOfWork;
        
        public GenreMovieService(IGenreMovieRepository genreMovieRepository, IUnitOfWork unitOfWork)
        {
            this._genreMovieRepository = genreMovieRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(int movieId, int genreId)
        {
            _genreMovieRepository.Add(movieId, genreId);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
