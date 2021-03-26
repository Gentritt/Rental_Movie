using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.Viewmodels
{
	public class NewCustomerViewModel
	{
		public IEnumerable<MembershipType> membershipTypes { get; set; }
		public Customer Customer { get; set; }
	}
}