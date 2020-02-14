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
    public interface IGenreService
    {
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(int id);
        Genre Get(int id);
        IEnumerable<Genre> GetAll();
        IEnumerable<Genre> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Genre> GetGendersWithMovieId(int movieId);
        void SaveChanges();
    }
    public class GenreService : IGenreService
    {
        IGenreRepository _genreRepository;
        IUnitOfWork _unitOfWork;
        
        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            this._genreRepository = genreRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Genre genre)
        {
            _genreRepository.Add(genre);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        public Genre Get(int id)
        {
            return _genreRepository.GetSingleById(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public IEnumerable<Genre> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _genreRepository.GetMultiPaging(x => x.Status == true, out totalRow, pageIndex, pageSize);
        }


        public IEnumerable<Genre> GetGendersWithMovieId(int movieId)
        {
            return _genreRepository.GetGendersOfMovie(movieId);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
