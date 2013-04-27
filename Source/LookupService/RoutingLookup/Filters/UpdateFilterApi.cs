using RoutingLookup.Models;
using RoutingLookup.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace RoutingLookup.Filters
{
	public class UpdateFilterApi : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext filterContext)
		{
			UpdateProcessor processor = new UpdateProcessor();
			BankEntities context = new Models.BankEntities();
			processor.Update(context);

			base.OnActionExecuted(filterContext);
		}
	}
}