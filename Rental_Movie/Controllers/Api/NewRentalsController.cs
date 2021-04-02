using Rental_Movie.Dtos;
using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace Rental_Movie.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private static ApplicationDbContext _context;
		public NewRentalsController()
		{
            _context = new ApplicationDbContext();
		}
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
		{
            var customer = _context.Customers.Single
              (c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where
                (m => newRentalDto.movieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvaliable == 0)
                    return BadRequest("Movie is Not Avaliable!");
                
                movie.NumberAvaliable--;
                var rental = new Rental
                {

                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };
                _context.Rentals.Add(rental);

            }
          _context.SaveChanges();

            return Ok();

		}

        public IHttpActionResult GetRentals()
		{
            var rentals = _context.Rentals.Include(m => m.Movie)
                .Include(c => c.Customer)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rentals);
		}
    }
}
