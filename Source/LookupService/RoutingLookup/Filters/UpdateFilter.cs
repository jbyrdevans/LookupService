using RoutingLookup.Models;
using RoutingLookup.Processors;
using System.Web.Mvc;

namespace RoutingLookup.Filters
{
	public class UpdateFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
			UpdateProcessor processor = new UpdateProcessor();
			BankEntities context = new Models.BankEntities();
			processor.Update(context);

            base.OnActionExecuting(filterContext);
        }
	}
}