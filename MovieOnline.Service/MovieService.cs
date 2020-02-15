using MovieOnline.Data.Infrastructure;
using MovieOnline.Data.Repositories;
using MovieOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieOnline.Service
{
    public interface IMovieService
    {
        Movie Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        Movie Get(int id);
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Movie> GetAllByGenrePaging(int genre, int pageIndex, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        private IUnitOfWork _unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            this._movieRepository = movieRepository;
            this._unitOfWork = unitOfWork;
        }

        public Movie Add(Movie movie)
        {
            return _movieRepository.Add(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public Movie Get(int id)
        {
            return _movieRepository.GetSingleById(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public IEnumerable<Movie> GetAllByGenrePaging(int genre, int pageIndex, int pageSize, out int totalRow)
        {
            return _movieRepository.GetAllByGenre(genre, pageIndex, pageSize, out totalRow);
        }

        public IEnumerable<Movie> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _movieRepository.GetMultiPaging(x => x.Status == true, out totalRow, pageIndex, pageSize ); 
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Movie movie)
        {
            _movieRepository.Update(movie);
        }
    }
}
