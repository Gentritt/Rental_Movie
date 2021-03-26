using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Models
{
	public class Movie
	{

		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public DateTime DateAdded { get; set; }
		public Genre genre { get; set; }
		[Display(Name = "Genre")]
		[Required]
		public int GenreId { get; set; }
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		public byte NumberInStock { get; set; }
	}
}