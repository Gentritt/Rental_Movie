using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.Viewmodels
{
	public class RentalViewModel
	{
		public Rental Rental { get; set; }
		public IEnumerable<Customer> customers { get; set; }
		public IEnumerable<Movie> movies { get; set; }
	}
}