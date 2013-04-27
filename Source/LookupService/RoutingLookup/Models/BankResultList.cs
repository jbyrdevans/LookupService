using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class BankResultList: PagedList
	{
		public Search Search { get; set; }
		public IEnumerable<Bank> Banks { get; set; }
		public override string Url { get; set; }
	}
}