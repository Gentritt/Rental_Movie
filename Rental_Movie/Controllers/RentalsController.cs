using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rental_Movie.Controllers
{
    public class RentalsController : Controller
    {

        [Authorize(Roles = RolesName.Admin)]
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Index()
		{
            return View();
		}
    }
}