using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.ViewModels;

namespace CRM.Controllers
{
	public class CustomerController : Controller
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
			model.DisplayMode = "CustomerNew";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult NewSave(Customer obj)
		{
			db.Customers.Add(obj);
			db.SaveChanges();

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(obj.CustomerId);
			model.DisplayMode = "CustomerDetails";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Select(int id)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(id);
			model.DisplayMode = "CustomerDetails";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Edit(int id)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(id);
			model.DisplayMode = "CustomerEdit";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult EditSave(Customer obj)
		{
			Customer existing = db.Customers.Find(obj.CustomerId);
			existing.CompanyName = obj.CompanyName;
			existing.ContactName = obj.ContactName;
			existing.Country = obj.Country;
			db.SaveChanges();

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = existing;
			model.DisplayMode = "CustomerDetails";
			return View("Index", model);
		}
		[HttpPost]
		public ActionResult AddAddress(int customerId)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = db.Customers.Find(customerId);
			model.newAddress = new Address();
			model.newAddress.CustomerId = customerId;
			model.DisplayMode = "AddressNew";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult AddAddressSave(Address address)
		{
			db.Addresses.Add(address);
			db.SaveChanges();


			Customer customer = db.Customers.Find(address.CustomerId);

			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedCustomer = customer;
			model.DisplayMode = "CustomerDetails";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult EditAddress(int addressId)
		{
			CustomersViewModel model = new CustomersViewModel();
			model.Customers = db.Customers.ToList();
			model.SelectedAddress = db.Addresses.Find(addressId);
			model.SelectedCustomer = db.Customers.Find(model.SelectedAddress.CustomerId);
			model.DisplayMode = "AddressEdit";
			return View("Index", model);
		}

		[HttpPost]
		public ActionResult EditAddressSave(Address address)
		{
			CustomersViewModel model = new CustomersViewModel();
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
			model.DisplayMode = "CustomerDetails";
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