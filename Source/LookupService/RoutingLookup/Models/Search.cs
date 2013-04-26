using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class Search
	{
		public string RoutingNumber { get; set; }
		public string Name { get; set; }
		public string State { get; set; }
		public string City { get; set; }
	}
}