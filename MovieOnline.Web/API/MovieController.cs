using MovieOnline.Model.Models;
using MovieOnline.Service;
using MovieOnline.Web.Insfrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieOnline.Web.Insfrastructure.Extension;
using MovieOnline.Web.Models;
using AutoMapper;

namespace MovieOnline.Web.API
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiControllerBase
    {
        IMovieService _movieService;
        public MovieController(IErrorService errorService, IMovieService movieService) : base(errorService)

        {
            this._movieService = movieService;
        }

        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, Movie movie)
        {
            return CreattHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else{
                    Movie result = _movieService.Add(movie);
                    _movieService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, result);
                }
                return response;
            });
        }
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, Movie movie)
        {
            return CreattHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _movieService.Update(movie);
                    _movieService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreattHttpResponse(request, () =>{
                HttpResponseMessage response = null;
                var sources = _movieService.GetAll().ToList();
                
                response = request.CreateResponse(HttpStatusCode.OK, sources); 

                return response;
            });
        }
        // GET: api/Movie

        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, int pageIndex, int pageSize,int totalRow)
        {
            return CreattHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var listMovie = _movieService.GetAllPaging(pageIndex, pageSize, out totalRow);
                return response;
            });
        }


    }
}
