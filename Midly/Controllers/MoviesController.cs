using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Midly.Models;
using System.Data.Entity;
using Midly.ViewModels;

namespace Midly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _applicationDbContext = new ApplicationDbContext();


        //Initilization
        public MoviesController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        //Disposing the aappDbContext object
        protected override void Dispose(bool disposing)
        {
            _applicationDbContext.Dispose();
        }

        //[GET: Movies]
        public ActionResult Index()
        {
            //var movie = _applicationDbContext.Movies.Include(m => m.Genre).ToList();
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _applicationDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var moviegenreViewModel = new MovieGenreViewModel
                {
                    Movie = movie,
                    Genre = _applicationDbContext.Genres
                };
                return View("MovieEditFrom", moviegenreViewModel);
            }
        }
           
        /// <summary>
        /// Creation of new movie form
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
            {
            var genres = _applicationDbContext.Genres.ToList();

            var viewModel = new MovieGenreViewModel()
            {
                Genre = genres
            };

            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            
            if(movie.Id == 0)
            {
                var addMovie = movie;
                addMovie.GenreId = movie.Genre.Id;
                addMovie.AddDate = DateTime.Now;

                _applicationDbContext.Movies.Add(addMovie);
                _applicationDbContext.SaveChanges();
                //return View("Details");
            }
            return View("Index");

        }

        [ValidateAntiForgeryToken]
        public ActionResult EditedMovieFrom(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genreList = _applicationDbContext.Genres.ToList();
                var moviegenreViewModel = new MovieGenreViewModel
                {
                    Movie = movie,
                    Genre = genreList
                };
                return View("MovieEditFrom", moviegenreViewModel);
            }
            if (movie.Id != 0)
            {
                    var updatedMovie = _applicationDbContext.Movies.Single(x => x.Id == movie.Id);
                    updatedMovie.Name = movie.Name;
                    updatedMovie.Stock = movie.Stock;
                    updatedMovie.GenreId = movie.GenreId;

                    //_applicationDbContext.Movies.Add(movie);
                    _applicationDbContext.SaveChanges();

            }            
            return RedirectToAction("Index", "Movies");

        }

    }
}