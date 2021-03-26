using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental_Movie.Models
{
	public class Min18YearsCustomer:ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;
			if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;
			if (customer.Birthdate == null)
				return new ValidationResult("Birthdate is Required");

			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
			return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old for membership");
		}
	}
}