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
        [Authorize(Roles = RolesName.Admin)]
        public IHttpActionResult GetMemberships()
		{
            var memberships=  _context.membershipTypes.ToList();
            return Ok(memberships);
		}
        [Authorize(Roles = RolesName.Admin)]
        public IHttpActionResult getMembership(int id)
		{

            var membership = _context.membershipTypes.SingleOrDefault(x => x.Id == id);
            if (membership == null)
                return NotFound();
            return Ok(membership);
		}

        [HttpPost]
        [Authorize(Roles = RolesName.Admin)]
        public MembershipType createMembership(MembershipType membership)
		{
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.membershipTypes.Add(membership);
            _context.SaveChanges();
            return membership;

		}
        [HttpDelete]
        [Authorize(Roles = RolesName.Admin)]
        public void DeleteMembership(int id)
		{
            var membership = _context.membershipTypes.SingleOrDefault(x => x.Id == id);
            if (membership == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.membershipTypes.Remove(membership);
            _context.SaveChanges();
		}




    }
}
