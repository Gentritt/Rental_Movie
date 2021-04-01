using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Models
{
	public class MembershipType
	{
		//[Required(ErrorMessage ="Write A name")]
		//[StringLength(255)]
		public string Name { get; set; }
		public int Id { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }
		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
}