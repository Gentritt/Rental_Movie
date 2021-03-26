using AutoMapper;
using Rental_Movie.Dtos;
using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

namespace Movie_Rental.Controllers.Api
{
	public class CustomersController : ApiController
	{
		private static ApplicationDbContext _context;
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}
		//Get/customers/
		public IHttpActionResult GetCustomers(string query = null)
		{
			var customersQuery = _context.Customers.Include(c => c.MembershipType);
			if (!String.IsNullOrWhiteSpace(query))
				customersQuery = customersQuery.Where(c => c.Name.Contains(query));
			var customerDtos = customersQuery.ToList()
				.Select(Mapper.Map<Customer, CustomerDto>);
			return Ok(customerDtos);
		}

		//Get/customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
			if (customer == null)
				return NotFound();
			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}


		//Post/Customers
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerdto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var customerdb = Mapper.Map<CustomerDto, Customer>(customerdto); //mapping Dto back to our domain object
			_context.Customers.Add(customerdb);
			_context.SaveChanges();
			customerdto.Id = customerdb.Id;
			return Created(new Uri(Request.RequestUri + "/" + customerdb.Id), customerdto);

		}
		[HttpPut]
		public void UpdateCustomer(int id, CustomerDto customerdto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			var customerinDb = _context.Customers.SingleOrDefault(x => x.Id == id);

			if (customerinDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			Mapper.Map(customerdto, customerinDb);
			_context.SaveChanges();

		}
		[HttpDelete]

		public void DeleteCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

			if (customer == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			_context.Customers.Remove(customer);
			_context.SaveChanges();
		}

	}
}
