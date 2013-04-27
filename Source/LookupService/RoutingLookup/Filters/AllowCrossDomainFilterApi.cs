using RoutingLookup.Models;
using RoutingLookup.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace RoutingLookup.Filters
{
	public class AllowCrossDomainFilterApi : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext filterContext)
		{
			filterContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

			base.OnActionExecuted(filterContext);
		}
	}
}