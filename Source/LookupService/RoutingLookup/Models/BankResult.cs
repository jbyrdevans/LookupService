using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class BankResult
	{
		public Search Search { get; set; }
		public Bank Bank { get; set; }
	}
}