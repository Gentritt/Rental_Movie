using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rental_Movie.Controllers
{
    public class MembershipTypesController : Controller
    {
        private static ApplicationDbContext _context;
		public MembershipTypesController()
		{
            _context = new ApplicationDbContext();
		}
        // GET: MembershipTypes
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RolesName.Admin)]
        public ActionResult New (MembershipType membershipType)
		{
            return View("MembershipTypeForm");
		}

        [HttpPost]
        [Authorize(Roles = RolesName.Admin)]
        public ActionResult Save(MembershipType membershipType)
		{
            if (membershipType.Id == 0)
                _context.membershipTypes.Add(membershipType);
			else
			{
                var membershipindb = _context.membershipTypes.Single(c => c.Id == membershipType.Id);

                membershipindb.Name = membershipType.Name;
                membershipindb.SignUpFee = membershipType.SignUpFee;
                membershipindb.DiscountRate = membershipType.DiscountRate;
                membershipindb.DurationInMonths = membershipType.DurationInMonths;
			}
            _context.SaveChanges();
            return RedirectToAction("Index", "MembershipTypes");
                

		}
    }
}