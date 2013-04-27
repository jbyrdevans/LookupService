using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RoutingLookup
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { controller = "BankController", id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			config.Filters.Add(new Filters.AllowCrossDomainFilterApi());
			config.Filters.Add(new Filters.UpdateFilterApi());

			//var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
			//config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
		}
	}
}
