using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class Search
	{
		public Search()
		{
			PageNumber = 1;
		}
		public Search(Search s)
		{
			RoutingNumber = s.RoutingNumber;
			Name = s.Name;
			State = s.State;
			City = s.City;
		}
		public string RoutingNumber { get; set; }
		public string Name { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public Nullable<int> PageNumber { get; set; }
	}
}