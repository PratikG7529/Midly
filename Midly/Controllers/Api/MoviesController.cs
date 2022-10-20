using AutoMapper;
using Midly.Dtos;
using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Midly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _applicationDbContext;

        public MoviesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _applicationDbContext.Movies.Include(m => m.Genre)
                .ToList().Select(Mapper.Map<Movie,MovieDto>);
            return Ok(movies);
        }

        [HttpGet]
        public MovieDto GetMovie(int id)
        {
            var movie = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == id);
            return Mapper.Map<Movie,MovieDto>(movie);
        }

        [HttpPut]
        public void UpdateMovie(MovieDto moviedto,int id)
        {
           if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           var movieInDbDetails = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDbDetails == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(moviedto,movieInDbDetails);

            ////updating movie details
            //movieInDbDetails.Name = movie.Name;
            //movieInDbDetails.Stock = movie.Stock;
            //movie.ReleaseDate = movie.ReleaseDate;

            //_applicationDbContext.Movies.Add(movieInDbDetails);
            _applicationDbContext.SaveChanges();

        }

        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //Here we are add data from MovieDto to Movie
            var movietomoviedto = Mapper.Map<MovieDto, Movie>(moviedto);

            _applicationDbContext.Movies.Add(movietomoviedto);
            _applicationDbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movietomoviedto.Id), moviedto);
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDbDetails = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDbDetails == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _applicationDbContext.Movies.Remove(movieInDbDetails);
            _applicationDbContext.SaveChanges();
        }


    }
}
