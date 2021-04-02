using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rental_Movie.Controllers
{
    public class GenresController : Controller
    {
        private static ApplicationDbContext _context;
		public GenresController()
		{
            _context = new ApplicationDbContext();
		}
        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
		{
            return View("GenreForm");
		}

        [HttpPost]
        public ActionResult Save(Genre genre)
		{
            if (genre.Id == 0)
                _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index", "Genres");
		}
    }
}