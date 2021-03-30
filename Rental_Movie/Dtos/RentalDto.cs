using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Dtos
{
	public class RentalDto
	{
		public int Id { get; set; }
		[Required]
		public CustomerDtoTest Customer { get; set; }
		public MovieDtoTest Movie { get; set; }
		public DateTime DateRented { get; set; }
		public DateTime? DateReturned { get; set; }
	}
}