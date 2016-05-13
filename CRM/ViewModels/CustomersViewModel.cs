using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Models;

namespace CRM.ViewModels
{
	public class CustomersViewModel
	{
		public List<Customer> Customers { get; set; }
		public Customer SelectedCustomer { get; set; }
		public Address SelectedAddress { get; set; }
		public string DisplayMode { get; set; }

		public Address newAddress { get; set; }

	}
}