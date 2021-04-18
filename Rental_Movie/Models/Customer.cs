using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public MembershipType MembershipType { get; set; }
		[Display(Name = "Membership type: ")]
		public int MembershipTypeId { get; set; }
		public bool IsSubscribedToNewsLetter { get; set; }

		//[MinimumAge(18,ErrorMessage ="Please enter a valid Birthdate")]
		[Min18YearsCustomer]
		[Display(Name = "Birth Date: ")]
		public DateTime? Birthdate { get; set; }
	}
}