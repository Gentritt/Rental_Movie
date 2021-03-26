using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.Viewmodels
{
	public class MovieViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }
	}
}