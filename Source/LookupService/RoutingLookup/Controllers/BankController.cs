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
	public class BankController : ApiController
	{
		// GET bank
		public IEnumerable<Bank> Get()
		{
			return new Bank[] { new Bank() { Name = "Bank 1", RoutingNumber = "011011111" }, new Bank() { Name = "Bank 2", RoutingNumber = "011022222" } };
		}

		// GET bank/011000015
		public Bank Get(string id)
		{
			var context = new BankEntities();
			return context.Banks.Find(id);
		}
	}
}