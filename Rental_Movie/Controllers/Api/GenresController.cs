using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rental_Movie.Controllers.Api
{
    public class GenresController : ApiController
    {
        private static ApplicationDbContext _context;
		public GenresController()
		{
            _context = new ApplicationDbContext();
		}

        public IHttpActionResult GetGenres()
		{
            var genres = _context.Genres.ToList();
            return Ok(genres);
		}

        public IHttpActionResult GetGenre(int id)
		{
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);
            if (genre == null)
                return NotFound();
            return Ok(genre);
		}
        [HttpPost]
        public Genre createGenre(Genre genre)
		{
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre;
		}

        [HttpDelete]
        public void DeleteGenre(int id)
		{
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);
            if (genre == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
		}


    }
}
