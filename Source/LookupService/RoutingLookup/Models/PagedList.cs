using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutingLookup.Models
{
	public class PagedList
	{
		public int TotalResults { get; set; }
		public int TotalPages { get; set; }
		public int PageLength { get; set; }
		public int CurrentPage { get; set; }
		public virtual string Url { get; set; }
	}
}