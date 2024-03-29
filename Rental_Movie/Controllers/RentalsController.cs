﻿using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Rental_Movie.Viewmodels;

namespace Rental_Movie.Controllers
{
    public class RentalsController : Controller
    {
        private static ApplicationDbContext _context;
		public RentalsController()
		{
            _context = new ApplicationDbContext();
		}

        [Authorize(Roles = RolesName.Admin)]
        public ActionResult New()
        {
            return View();
        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Index()
		{
            return View();
		}
        [HttpPost]
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Save(Rental rental)
        {

            var viewModel = new RentalViewModel
            {
                Rental = rental,
                customers = _context.Customers.ToList(),
                movies = _context.Movies.ToList()

            };

            if (rental.Id == 0)
                _context.Rentals.Add(rental);
            
            else
            {
               //Update the database when a movie is returned
                var rentalInDb = _context.Rentals.Include(x=> x.Customer).Include(m=> m.Movie).SingleOrDefault(x => x.Id == rental.Id);
                rentalInDb.DateReturned = rental.DateReturned;
                rentalInDb.Movie.NumberInStock++;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Rentals");
        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Edit(int id)
		{
            var rental = _context.Rentals.Include(x=> x.Customer).Include(m=> m.Movie).SingleOrDefault(x => x.Id == id);
            if (rental == null)
                return HttpNotFound();
            return View("DateReturnedForm", rental);
		}
    }
}