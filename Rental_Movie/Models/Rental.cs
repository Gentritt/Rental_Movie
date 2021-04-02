using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Models
{
	public class Rental
	{
		public int Id { get; set; }
		[Required]
		public Customer Customer { get; set; }
		[Required]
		public Movie Movie { get; set; }
		//public int Movie_Id { get; set; }
		//public int Customer_Id { get; set; }
		[DataType(DataType.Date)]
		public DateTime? DateRented { get; set; }
		public DateTime? DateReturned { get; set; }

	}
}