using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Rental_Movie.Viewmodels;
using System.Data.Entity.Validation;

namespace Rental_Movie.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private static ApplicationDbContext _context;
		public CustomersController()
		{
            _context = new ApplicationDbContext();
		}
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View();
        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var customer = new NewCustomerViewModel
            {
                membershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", customer);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
			if (!ModelState.IsValid)
			{

                var viewmodel = new NewCustomerViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.membershipTypes.ToList()
                };
			}
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customer.MembershipTypeId = customer.MembershipTypeId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    foreach (var propertyError in error.ValidationErrors)
                    {
                        Console.WriteLine($"{propertyError.PropertyName} had the following issue: {propertyError.ErrorMessage}");
                    }
                }
            }
            //_context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                membershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}