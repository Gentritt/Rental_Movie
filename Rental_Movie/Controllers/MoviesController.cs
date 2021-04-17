using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Rental_Movie.Viewmodels;

namespace Rental_Movie.Controllers
{
    public class MoviesController : Controller
    {
        private static ApplicationDbContext _context;
		public MoviesController()
		{
            _context = new ApplicationDbContext();

		}
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View("Index");
            else
                return View("ReadOnlyList");
            //var customers = _context.Movies.Include(x => x.genre).ToList();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(x => x.genre).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
            
        }
        [Authorize(Roles= RolesName.Admin)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new MovieViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewmodel);
        }
        [Authorize(Roles = RolesName.Admin)]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
			{
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
             
            else
            {
                //If Movie Exits than update !
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                //movieInDb.DateAdded = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie.Id == 0)
                return HttpNotFound();

            var viewmodel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewmodel);

        }

    }

}