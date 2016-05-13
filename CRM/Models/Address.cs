using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM.Models
{
	public class Address
	{
		public int AddressId { get; set; }

		public string AddressGlobalName
		{
			get { return Street + " " + HouseNumber + ", " + PostalCode + Place; }
		}

		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public string PostalCode { get; set; }
		public string Place { get; set; }

		// Relationship to Customer
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
	}
}