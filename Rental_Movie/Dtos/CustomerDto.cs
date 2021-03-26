using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Dtos
{
	public class CustomerDto
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public bool IsSubscribedToNewsLetter { get; set; }
		public membershipTypeDto membershipType { get; set; }
		public int MembershipTypeId { get; set; }
		//[Min18YearsCustomer]
		public DateTime? Birthdate { get; set; }
	}
}