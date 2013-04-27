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
			return View(new BankResult() { Search = null, Bank = bank });
		}

		public ActionResult BankList(Search search)
		{
			var sc = new SearchController();
			var banks = sc.Get(search);
			if (banks.Count() == 1)
			{
				return View("Bank",  new BankResult() { Search = search, Bank = banks.First() });
			}
			else
			{
				var total = banks.Count();
				var pageLen = 10;
				var nonPagedSearch = new Search(search);
				return View(new BankResultList()
				{
					Search = search,
					Banks = banks.Skip((search.PageNumber.Value - 1) * pageLen).Take(pageLen),
					TotalResults = total,
					CurrentPage = search.PageNumber.Value,
					PageLength = pageLen,
					TotalPages = (int)Math.Ceiling((decimal)total / (decimal)pageLen),
					Url = Url.Action("BankList", "Results", nonPagedSearch)
				});
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
