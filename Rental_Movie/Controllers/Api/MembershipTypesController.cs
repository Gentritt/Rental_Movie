using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rental_Movie.Controllers.Api
{
    public class MembershipTypesController : ApiController
    {
        private static ApplicationDbContext _context;
		public MembershipTypesController()
		{
            _context = new ApplicationDbContext();
		}
        //Get/membershiptypes/
        public IHttpActionResult GetMemberships()
		{
            var memberships=  _context.membershipTypes.ToList();
            return Ok(memberships);
		}



    }
}
