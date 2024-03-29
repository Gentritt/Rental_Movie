﻿using System.Web;
using System.Web.Optimization;

namespace Rental_Movie
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/lib").Include(
						"~/Scripts/jquery-{version}.js",
						  "~/Scripts/bootstrap.js",
						  "~/Scripts/bootbox.js",
						  "~/Scripts/DataTables/jquery.dataTables.js",
						  "~/Scripts/DataTables/dataTables.bootstrap.js",
						  "~/Scripts/toastr.js",
						  "~/Scripts/moment.js",
						  "~/Scripts/typeahead.bundle.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			//		"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap-flatly.css",
					  "~/Content/DataTables/css/dataTables.bootstrap.css",
					  "~/Content/site.css",
					  "~/Content/toastr.css",
					  "~/Content/typeahead.css"));
		}
	}
}
