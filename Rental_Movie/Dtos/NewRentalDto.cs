﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.Dtos
{
	public class NewRentalDto
	{
		public int CustomerId { get; set; }
		public List<int> movieIds { get; set; }
	}
}