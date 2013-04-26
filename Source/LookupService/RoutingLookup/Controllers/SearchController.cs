using RoutingLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RoutingLookup.Controllers
{
	public class SearchController : ApiController
	{
		// GET search?name=bank+name&state=UT&city=west+valley+city
		public IEnumerable<Bank> Get([FromUri]Search search)
		{
			var context = new BankEntities();
			var results = context.Banks.AsQueryable();
			if (!String.IsNullOrEmpty(search.Name))
			{
				results = results.Where(b => b.Name.Contains(search.Name));
			}
			if (!String.IsNullOrEmpty(search.State))
			{
				results = results.Where(b => b.State == search.State);
			}
			if (!String.IsNullOrEmpty(search.City))
			{
				results = results.Where(b => b.City == search.City);
			}
			return results;
		}
	}
}