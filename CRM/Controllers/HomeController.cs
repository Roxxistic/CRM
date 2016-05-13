using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.ViewModels;

namespace CRM.Controllers
{
	public class HomeController : Controller
	{
		private CrmDbContext db = new CrmDbContext();
		public ActionResult Index()
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = null;
			return View(model);
		}
		[HttpPost]
		public ActionResult New()
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = null;
			model.DisplayMode = "WriteOnly";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Insert(Customer obj)
		{
			db.Customers.Add(obj);
			db.SaveChanges();

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(obj.CustomerId);
			model.DisplayMode = "ReadOnly";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Select(int id)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(id);
			model.DisplayMode = "ReadOnly";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Edit(int id)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(id);
			model.DisplayMode = "ReadWrite";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Update(Customer obj)
		{
			Customer existing = db.Customers.Find(obj.CustomerId);
			existing.CompanyName = obj.CompanyName;
			existing.ContactName = obj.ContactName;
			existing.Country = obj.Country;
			db.SaveChanges();

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = existing;
			model.DisplayMode = "ReadOnly";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			Customer existing = db.Customers.Find(id);
			db.Customers.Remove(existing);
			db.SaveChanges();

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = null;
			model.DisplayMode = "";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Cancel(int id)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.DisplayMode = "ReadOnly";
			return View("Index", model);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}