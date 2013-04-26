using RoutingLookup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingLookup.Controllers
{
	public class ResultsController : Controller
	{
		public ActionResult Bank(string id)
		{
			var rc = new BankController();
			var bank = rc.Get(id);
			return View(bank);
		}

		public ActionResult BankList(Search search)
		{
			var sc = new SearchController();
			var banks = sc.Get(search);
			if (banks.Count() == 1)
			{
				return RedirectToAction("Bank", "Results", new { id = banks.First().RoutingNumber });
			}
			else
			{
				return View(banks);
			}
		}

		public ActionResult Search()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Search(Search search)
		{
			return RedirectToAction("Bank", "Results", new { id = search.RoutingNumber });
		}

		public ActionResult SearchAdvanced()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult SearchAdvanced(Search search)
		{
			return RedirectToAction("BankList", "Results", search);
		}
	}
}
