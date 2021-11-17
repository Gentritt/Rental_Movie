using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Rental_Movie.Viewmodels;
using System.Data.Entity.Validation;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Rental_Movie.Azure;
using Microsoft.AspNetCore.Http.Internal;

namespace Rental_Movie.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private static ApplicationDbContext _context;
        private IAmazonS3 _client;
        private BlobManager _blobManager;
		public CustomersController()
		{
            _context = new ApplicationDbContext();
            _client = new AmazonS3Client();
            _blobManager = new BlobManager("riinvest");
            _blobManager.BlobContainerInit();
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
                return View("CustomerForm",viewmodel);
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
   //         _context.SaveChanges();
			//try
			//{
			//	_context.SaveChanges();
			//}


			//catch (Exception ex)
			//{
			//	ModelState.AddModelError("Unable to save changes", ex);
			//	foreach (var error in ex.EntityValidationErrors)
			//	{
			//		foreach (var propertyError in error.ValidationErrors)
			//		{
			//			Console.WriteLine($"{propertyError.PropertyName} had the following issue: {propertyError.ErrorMessage}");
			//		}
			//	}
			//}
			_context.SaveChanges();

			_client.PutObject(new PutObjectRequest()
			{
				BucketName = "riinvest",
				Key = $"gent/customers/{customer.Id}.json",
				ContentBody = JsonConvert.SerializeObject(customer)

			});

			var customer1 = _context.Customers.OrderByDescending(x => x.Id).FirstOrDefault();

            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(customer1));
            //var stream = new MemoryStream(bytes);
         
            AzureUpload(new Dictionary<string, byte[]> { { $"{customer1.Id.ToString()}.json", bytes } } );

             //stream.Dispose();


            return RedirectToAction("Index", "Customers");

        }
        public void AzureUpload(Dictionary<string, byte[]> files)
        {
             _blobManager.UploadFile(files);
            
        }


        [HttpPost]
        public async Task AzureUploadInputFile(HttpPostedFileBase files)
        {
			await _blobManager.UploadInputFiles(files);

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

            _client.PutObject(new PutObjectRequest()
            {
                BucketName = "riinvest",
                Key = $"gent/customers/{id}.json",
                ContentBody = JsonConvert.SerializeObject(customer)

            });
            return View("CustomerForm", viewModel);
        }
    }
}